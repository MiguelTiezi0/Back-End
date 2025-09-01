using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TCC_2025.Banco_de_Dados;

namespace SeuProjeto.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDataContext _context;

        public AuthController(ApplicationDataContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Primeiro, tenta encontrar na tabela Funcionário
            var funcionario = _context.Funcionario
                .FirstOrDefault(f => f.Usuario == request.Usuario && f.Senha == request.Senha);

            if (funcionario != null)
            {
                return Ok(new
                {
                    Id = funcionario.Id,
                    Nome = funcionario.Nome,
                    Usuario = funcionario.Usuario,
                    NivelAcesso = funcionario.NivelAcesso
                });
            }

            // Depois, tenta encontrar na tabela Cliente
            var cliente = _context.Cliente
                .FirstOrDefault(c => c.Usuario == request.Usuario && c.Senha == request.Senha);

            if (cliente != null)
            {
                return Ok(new
                {
                    Id = cliente.Id,
                    Nome = cliente.Nome,
                    Usuario = cliente.Usuario,
                    NivelAcesso = "Cliente"
                });
            }

            // Se não achou em nenhuma tabela
            return Unauthorized(new { message = "Usuário ou senha inválidos" });
        }
    }

    // DTO (Data Transfer Object) para receber os dados do frontend
    public class LoginRequest
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
