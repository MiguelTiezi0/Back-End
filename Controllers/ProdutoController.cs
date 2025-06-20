using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_2025.Banco_de_Dados;
using TCC_2025.Models;

namespace TCC_2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ApplicationDataContext _context;

        public ProdutoController(ApplicationDataContext context)
        {
            _context = context;
        }

        // GET: api/Produto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProduto()
        {
            return await _context.Produto.ToListAsync();
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _context.Produto.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // PUT: api/Produto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
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

        // POST: api/Produto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            produto.DataCadastro = DateTime.Now;
            _context.Produto.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.Id == id);
        }
        [HttpGet("GerarEtiquetaPorId/{id}")]
        public IActionResult GerarEtiquetaPorId(int id)
        {
            // 1. Busca o produto no banco de dados
            var produto = _context.Produto.FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return NotFound("Produto não encontrado");

            // 2. Configura o gerador de código de barras
            var barcodeWriter = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions { Height = 100, Width = 300, Margin = 10 }
            };

            // 3. Gera os pixels do código de barras
            var pixelData = barcodeWriter.Write(produto.CodigoDeBarras);

            // 4. Converte os pixels para Base64
            using (var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb))
            using (var ms = new MemoryStream())
            {
                // Copia os pixels para o bitmap
                var bitmapData = bitmap.LockBits(
                    new Rectangle(0, 0, pixelData.Width, pixelData.Height),
                    ImageLockMode.WriteOnly,
                    PixelFormat.Format32bppRgb
                );
                try
                {
                    System.Runtime.InteropServices.Marshal.Copy(
                        pixelData.Pixels,
                        0,
                        bitmapData.Scan0,
                        pixelData.Pixels.Length
                    );
                }
                finally
                {
                    bitmap.UnlockBits(bitmapData);
                }

                // Salva o bitmap em MemoryStream como PNG
                bitmap.Save(ms, ImageFormat.Png);
                string barcodeBase64 = Convert.ToBase64String(ms.ToArray()); // Conversão crítica!

                // 5. Retorna a resposta
                return Ok(new
                {
                    CodigoBarrasImagem = barcodeBase64, // Agora definido corretamente
                    NomeProduto = produto.Descricao,
                    Preco = produto.PreçoVenda,
                    CodigoBarrasTexto = produto.CodigoDeBarras
                });
            }
        }
    }
}
