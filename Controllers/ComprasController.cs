using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_2025.Banco_de_Dados;
using TCC_2025.Models;

namespace TCC_2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly ApplicationDataContext _context;

        public ComprasController(ApplicationDataContext context)
        {
            _context = context;
        }

        // GET: api/Compras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compra>>> GetCompra()
        {
            return await _context.Compra.ToListAsync();
        }

        // GET: api/Compras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compra>> GetCompra(int id)
        {
            var compra = await _context.Compra.FindAsync(id);

            if (compra == null)
            {
                return NotFound();
            }

            return compra;
        }

        // PUT: api/Compras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompra(int id, Compra compra)
        {
            if (id != compra.Id)
            {
                return BadRequest();
            }

            _context.Entry(compra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Compras
        [HttpPost]
        public async Task<ActionResult<Compra>> PostCompra(Compra compra)
        {
            _context.Compra.Add(compra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompra", new { id = compra.Id }, compra);
        }

        // DELETE: api/Compras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompra(int id)
        {
            var compra = await _context.Compra.FindAsync(id);
            if (compra == null)
                return NotFound();

            // Busca os itens da compra
            var itensCompra = await _context.Itens_Compra
                .Where(ic => ic.CompraId == id)
                .ToListAsync();

            // Remove os itens relacionados
            _context.Itens_Compra.RemoveRange(itensCompra);

            // Remove a compra
            _context.Compra.Remove(compra);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Novo endpoint: exclui todos os itens de uma compra, sem excluir a compra.
        /// Útil para edição (reset dos itens).
        /// </summary>
        /// 

        // DELETE: api/Itens_Compra/deleteByCompra/
        [HttpDelete("deleteByCompra/{compraId}")]
        public async Task<IActionResult> DeleteByCompra(int compraId)
        {
            var itens = await _context.Itens_Compra
                .Where(i => i.CompraId == compraId) // ajuste o nome da propriedade se for diferente
                .ToListAsync();

            // Retorna NoContent mesmo que não existam itens — evita que o frontend interprete como erro
            if (!itens.Any())
                return NoContent();

            _context.Itens_Compra.RemoveRange(itens);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool CompraExists(int id)
        {
            return _context.Compra.Any(e => e.Id == id);
        }
    }
}
