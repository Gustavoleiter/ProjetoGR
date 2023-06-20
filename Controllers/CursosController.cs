using ProjetoGR.Models;
using Microsoft.EntityFrameworkCore;
using System;
using ProjetoGR.Data;
using ProjetoGR.Models.Enuns;
using Microsoft.AspNetCore.Mvc;





namespace ProjetoGR.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CursosController : ControllerBase
    {
        
        private readonly DataContext _context;

        public CursosController(DataContext context)
        {
            _context = context;
        }
        
        
        
        
        
        [HttpGet("MostrarTodos")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Curso> lista = await _context.Cursos.ToListAsync();
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
                Curso a = await _context.Cursos.FirstOrDefaultAsync(pBusca => pBusca.Id == id);

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
                Curso aRemover = await _context.Cursos.FirstOrDefaultAsync(a => a.Id == id);

                _context.Cursos.Remove(aRemover);
                int linhasAfetedas = await _context.SaveChangesAsync();
                return Ok(linhasAfetedas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
       [HttpPost]
        public async Task<IActionResult> Add(Curso novoCurso)
        {
            try
            {
                if(novoCurso.Id != null)
                {
                    throw new Exception("Id do curso tem que ser valido");

                }
                await _context.Personagens.AddAsync(novoCurso);
                await _context.SaveChangesAsync();

                return Ok(novoCurso.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
