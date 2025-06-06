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
    public class Itens_VendaController : ControllerBase
    {
        private readonly ApplicationDataContext _context;

        public Itens_VendaController(ApplicationDataContext context)
        {
            _context = context;
        }

        // GET: api/Itens_Venda
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Itens_Venda>>> GetItens_Venda()
        {
            return await _context.Itens_Venda.ToListAsync();
        }

        // GET: api/Itens_Venda/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Itens_Venda>> GetItens_Venda(int id)
        {
            var itens_Venda = await _context.Itens_Venda.FindAsync(id);

            if (itens_Venda == null)
            {
                return NotFound();
            }

            return itens_Venda;
        }

        // PUT: api/Itens_Venda/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItens_Venda(int id, Itens_Venda itens_Venda)
        {
            if (id != itens_Venda.Id)
            {
                return BadRequest();
            }

            _context.Entry(itens_Venda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Itens_VendaExists(id))
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

        // POST: api/Itens_Venda
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Itens_Venda>> PostItens_Venda(Itens_Venda itens_Venda)
        {
            _context.Itens_Venda.Add(itens_Venda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItens_Venda", new { id = itens_Venda.Id }, itens_Venda);
        }

        // DELETE: api/Itens_Venda/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItens_Venda(int id)
        {
            var itens_Venda = await _context.Itens_Venda.FindAsync(id);
            if (itens_Venda == null)
            {
                return NotFound();
            }

            _context.Itens_Venda.Remove(itens_Venda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Itens_VendaExists(int id)
        {
            return _context.Itens_Venda.Any(e => e.Id == id);
        }
    }
}
