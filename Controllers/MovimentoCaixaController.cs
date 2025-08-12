using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TCC_2025.Banco_de_Dados;
using TCC_2025.Models;

namespace TCC_2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentoCaixaController : ControllerBase
    {
        private readonly ApplicationDataContext _context;

        public MovimentoCaixaController(ApplicationDataContext context)
        {
            _context = context;
        }

        [HttpGet("por-caixa/{caixaId}")]
        public async Task<IActionResult> GetPorCaixa(int caixaId)
        {
            var movimentos = await _context.MovimentoCaixa
                .Where(m => m.CaixaId == caixaId)
                .OrderBy(m => m.Data)
                .ToListAsync();

            return Ok(movimentos);
        }

        [HttpGet("todos")]
        public async Task<IActionResult> GetTodos()
        {
            var movimentos = await _context.MovimentoCaixa
                .Include(m => m.Caixa)
                .OrderByDescending(m => m.Data)
                .ToListAsync();

            return Ok(movimentos);
        }
    }
}
