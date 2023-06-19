using Microsoft.AspNetCore.Mvc;
using ProjetoGR.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;
using ProjetoGR.Models;


namespace ProjetoGR.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class EstagioSController : ControllerBase
    {

        private readonly DataContext _context;

        public EstagioSController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("MostrarTodos")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Estagio> lista = await _context.Estagios.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Estagio a = await _context.Estagios.FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Estagio aRemover = await _context.Estagios.FirstOrDefaultAsync(a => a.Id == id);

                _context.Estagios.Remove(aRemover);
                int linhasAfetedas = await _context.SaveChangesAsync();
                return Ok(linhasAfetedas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}