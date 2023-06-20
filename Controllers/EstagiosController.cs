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

        [HttpPost]
        public async Task<IActionResult> Add(Curso novoEstagio)
        {
            try
            {
                if(novoEstagio.Id != null)
                {
                    throw new Exception("Id do Estagio tem que ser valido");

                }
                await _context.Personagens.AddAsync(novoEstagio);
                await _context.SaveChangesAsync();

                return Ok(novoEstagio.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Estagio novoEstagio)
        {
            try
            {
                Estagio e = await _context.Personagens.FirstOrDefaultAsync (eBusca => eBusca.Id == id);
                if(novoEstagio.Id = e )
                {
                    _context.Personagens.Update(novoPersonagem);
                int linhasAfetedas = await _context.SaveChangesAsync();

                return Ok(linhasAfetedas);
                    
                }
                throw new Exception("Id de curso inexistente ");
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}