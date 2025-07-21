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
    public class VendaController : ControllerBase
    {
        private readonly ApplicationDataContext _context;

        public VendaController(ApplicationDataContext context)
        {
            _context = context;
        }

        // GET: api/Venda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> GetVenda()
        {
            return await _context.Venda.ToListAsync();
        }

        // GET: api/Venda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> GetVenda(int id)
        {
            var venda = await _context.Venda.FindAsync(id);

            if (venda == null)
            {
                return NotFound();
            }

            return venda;
        }

        // PUT: api/Venda/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenda(int id, Venda venda)
        {
            if (id != venda.Id)
            {
                return BadRequest();
            }

            _context.Entry(venda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendaExists(id))
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

        // POST: api/Venda
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Venda>> PostVenda(Venda venda)
        {
            venda.DataVenda = DateTime.Now;
            _context.Venda.Add(venda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenda", new { id = venda.Id }, venda);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenda(int id)
        {
            // Busca a venda
            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
                return NotFound();

            // Busca os itens da venda
            var itensVenda = await _context.Itens_Venda
                .Where(iv => iv.VendaId == id)
                .ToListAsync();

            // Para cada item, devolve ao estoque
            foreach (var item in itensVenda)
            {
                var produto = await _context.Produto.FindAsync(item.ProdutoId);
                if (produto != null)
                {
                    produto.Quantidade += item.Quantidade;
                }
            }

            // Remove os itens da venda
            _context.Itens_Venda.RemoveRange(itensVenda);

            // Remove a venda
            _context.Venda.Remove(venda);

            await _context.SaveChangesAsync();

            return NoContent();
        }


private bool VendaExists(int id)
        {
            return _context.Venda.Any(e => e.Id == id);
        }
    }
}
