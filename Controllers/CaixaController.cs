using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
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
            var caixaAberto = await _context.Caixa.FirstOrDefaultAsync(c => c.Aberto);
            if (caixaAberto != null)
                return BadRequest("Já existe um caixa aberto.");

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
            var caixa = await _context.Caixa.FirstOrDefaultAsync(c => c.Aberto);
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

        [HttpPost("entrada")]
        public async Task<IActionResult> AdicionarEntrada([FromBody] DtoMovimentoCaixa dto)
        {
            var caixaAberto = await _context.Caixa.FirstOrDefaultAsync(c => c.Aberto);
            if (caixaAberto == null)
                return BadRequest("Não há caixa aberto.");

            var movimento = new MovimentoCaixa
            {
                CaixaId = caixaAberto.Id,
                Valor = Math.Abs(dto.Valor),
                Tipo = "Entrada",
                Descricao = dto.Descricao,
                Data = DateTime.Now
            };

            _context.MovimentoCaixa.Add(movimento);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                movimento.Id,
                movimento.Descricao,
                movimento.Valor,
                movimento.Tipo,
                movimento.Data
            });
        }

        [HttpPost("saida")]
        public async Task<IActionResult> AdicionarSaida([FromBody] DtoMovimentoCaixa dto)
        {
            var caixaAberto = await _context.Caixa.FirstOrDefaultAsync(c => c.Aberto);
            if (caixaAberto == null)
                return BadRequest("Não há caixa aberto.");

            var movimento = new MovimentoCaixa
            {
                CaixaId = caixaAberto.Id,
                Valor = dto.Tipo == "Saída" ? -Math.Abs(dto.Valor) : Math.Abs(dto.Valor),
                Tipo = dto.Tipo,
                Descricao = dto.Descricao,
                Data = DateTime.Now
            };

            _context.MovimentoCaixa.Add(movimento);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                movimento.Id,
                movimento.Descricao,
                movimento.Valor,
                movimento.Tipo,
                movimento.Data
            });
        }

        [HttpGet("aberto")]
        public async Task<IActionResult> GetCaixaAberto()
        {
            var caixa = await _context.Caixa
                .Include(c => c.Movimentos)
                .FirstOrDefaultAsync(c => c.Aberto);

            if (caixa == null)
                return NotFound("Não há caixa aberto.");

            decimal totalMovimentacoes = caixa.Movimentos?.Sum(m => m.Valor) ?? 0;
            decimal valorAtual = caixa.ValorAbertura + totalMovimentacoes;

            return Ok(new
            {
                caixa.Id,
                caixa.DataAbertura,
                caixa.ValorAbertura,
                TotalMovimentacoes = totalMovimentacoes,
                ValorAtual = valorAtual
            });
        }
    }
}
