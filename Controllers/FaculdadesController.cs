using Microsoft.AspNetCore.Mvc;
using ProjetoGR.Data;
using ProjetoGR.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;

namespace ProjetoGR.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FaculdadesController : ControllerBase
    {


        private readonly DataContext _context;
        public FaculdadesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("MostrarTodos")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Faculdade> lista = await _context.Faculdades.ToListAsync();
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
                Faculdade a = await _context.Faculdades.FirstOrDefaultAsync(pBusca => pBusca.Id == id);

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
                Faculdade aRemover = await _context.Faculdades.FirstOrDefaultAsync(a => a.Id == id);

                _context.Faculdades.Remove(aRemover);
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