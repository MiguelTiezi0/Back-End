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
    public class Itens_CompraController : ControllerBase
    {
        private readonly ApplicationDataContext _context;

        public Itens_CompraController(ApplicationDataContext context)
        {
            _context = context;
        }

        // GET: api/Itens_Compra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Itens_Compra>>> GetItens_Compra()
        {
            return await _context.Itens_Compra.ToListAsync();
        }

        // GET: api/Itens_Compra/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Itens_Compra>> GetItens_Compra(int id)
        {
            var itens_Compra = await _context.Itens_Compra.FindAsync(id);

            if (itens_Compra == null)
            {
                return NotFound();
            }

            return itens_Compra;
        }

        // PUT: api/Itens_Compra/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItens_Compra(int id, Itens_Compra itens_Compra)
        {
            if (id != itens_Compra.Id)
            {
                return BadRequest();
            }

            _context.Entry(itens_Compra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Itens_CompraExists(id))
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

        // POST: api/Itens_Compra
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Itens_Compra>> PostItens_Compra(Itens_Compra itens_Compra)
        {
            _context.Itens_Compra.Add(itens_Compra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItens_Compra", new { id = itens_Compra.Id }, itens_Compra);
        }

        // DELETE: api/Itens_Compra/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItens_Compra(int id)
        {
            var itens_Compra = await _context.Itens_Compra.FindAsync(id);
            if (itens_Compra == null)
            {
                return NotFound();
            }

            _context.Itens_Compra.Remove(itens_Compra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Itens_CompraExists(int id)
        {
            return _context.Itens_Compra.Any(e => e.Id == id);
        }
    }
}
