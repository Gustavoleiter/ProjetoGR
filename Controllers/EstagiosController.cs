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
                public async Task<IActionResult> Add(Estagio novoEstagio)
                {   
                try
                {
                    // Verifica se o ID já existe no banco de dados
                    bool idExists = await _context.Estagios.AnyAsync(e => e.Id == novoEstagio.Id);
                    if (idExists)
                    {
                        return BadRequest("O ID do Estagio já está em uso");
                    }

                    await _context.Estagios.AddAsync(novoEstagio);
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
            
                    
                    if (novoEstagio.Id == null)
                    {
                        return BadRequest("Estagio não encontrado"); // Caso o registro não seja encontrado
                    }

                    
                    _context.Estagios.Update(novoEstagio);
                    int linhasAfetadas = await _context.SaveChangesAsync();

                    return Ok(linhasAfetadas);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

    }
}