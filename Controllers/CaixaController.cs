using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TCC_2025.Banco_de_Dados;
using TCC_2025.Models;

namespace TCC_2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaixaController : ControllerBase
    {
        private readonly ApplicationDataContext _context;

        public CaixaController(ApplicationDataContext context)
        {
            _context = context;
        }

        [HttpPost("abrir")]
        public async Task<IActionResult> AbrirCaixa([FromBody] DtoAbertura dto)
        {
            // Verifica se já existe caixa aberto
            var caixaAberto = await _context.Caixa
                .FirstOrDefaultAsync(c => c.Aberto);

            if (caixaAberto != null)
            {
                return BadRequest("Já existe um caixa aberto.");
            }

            var novoCaixa = new Caixa
            {
                DataAbertura = DateTime.Now,
                ValorAbertura = dto.ValorAbertura,
                Aberto = true
            };

            _context.Caixa.Add(novoCaixa);
            await _context.SaveChangesAsync();

            return Ok(novoCaixa);
        }
        [HttpPost("fechar")]
        public async Task<IActionResult> FecharCaixa([FromBody] DtoFechamento dto)
        {
            var caixa = await _context.Caixa
                .FirstOrDefaultAsync(c => c.Aberto);

            if (caixa == null)
                return BadRequest("Não há caixa aberto.");

            caixa.DataFechamento = DateTime.Now;
            caixa.ValorFechamento = dto.ValorFechamento;
            caixa.Aberto = false;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                caixa.Id,
                caixa.DataAbertura,
                caixa.DataFechamento,
                caixa.ValorAbertura,
                caixa.ValorFechamento
            });
        }

    }
}
