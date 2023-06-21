using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoGR.Models;
using ProjetoGR.Models.Enuns;
using ProjetoGR.Utils;
using System;
using ProjetoGR.Data;
using Microsoft.AspNetCore.Mvc;



namespace ProjetoGR.Controllers

{
    
    
    [ApiController]
    [Route("[Controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;
        public UsuariosController(DataContext context)
        {
            _context = context;
        }
       private async Task<bool> UsuarioExistente(string username)
        {
            if (await _context.Usuarios.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }
        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario user)
        {
            try{
                if(await UsuarioExistente(user.Username))
                throw new System.Exception("Nome de usiario ja existente!");

                Criptografia.CriarPasswordHash(user.PasswordString, out byte[] hash, out byte[] salt);
                user.PasswordString = string.Empty;
                user.PasswordHash = hash;
                user.PasswordSalt = salt;
                await _context.Usuarios.AddAsync(user);
                await _context.SaveChangesAsync();

                return Ok(user.Id);
            }
            catch(System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario usuario = await _context.Usuarios
                   .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado.");
                }
                else if (!Criptografia.VerificarPasswordHash(credenciais.PasswordString, usuario.PasswordHash, usuario.PasswordSalt))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else
                {
                    usuario.DataAcesso = System.DateTime.Now;
                    _context.Usuarios.Update(usuario);
                    await _context.SaveChangesAsync(); //Confirma a alteração no banco
                    
                    
                    return Ok(usuario);
                    
                }
            }
            catch (System.Exception ex)
            { 
                return BadRequest(ex.Message); 
            }
        }

        //Método para alteração de Senha.
        [HttpPut("AlterarSenha")]
        public async Task<IActionResult> AlterarSenhaUsuario(Usuario credenciais)
        {
            try
            {
                Usuario usuario = await _context.Usuarios //Busca o usuário no banco através do login
                   .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(credenciais.Username.ToLower()));

                if (usuario == null) //Se não achar nenhum usuário pelo login, retorna mensagem.
                    throw new System.Exception("Usuário não encontrado.");

                Criptografia.CriarPasswordHash(credenciais.PasswordString, out byte[] hash, out byte[] salt);
                usuario.PasswordHash = hash; //Se o usuário existir, executa a criptografia (linha 122)
                usuario.PasswordSalt = salt; //guardando o hash e o salt nas propriedades do usuário (linhas 123/124)

                _context.Usuarios.Update(usuario);
                int linhasAfetadas = await _context.SaveChangesAsync(); //Confirma a alteração no banco
                return Ok(linhasAfetadas); //Retorna as linhas afetadas (Geralmente sempre 1 linha msm)
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetUsuarios()
        {
            try
            {
                //List exigirá o using System.Collections.Generic
                List<Usuario> lista = await _context.Usuarios.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetUsuario(int usuarioId)
        {
            try
            {
                //List exigirá o using System.Collections.Generic
                Usuario usuario = await _context.Usuarios //Busca o usuário no banco através do Id
                   .FirstOrDefaultAsync(x => x.Id == usuarioId);

                return Ok(usuario);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetByLogin/{login}")]
        public async Task<IActionResult> GetUsuario(string login)
        {
            try
            {
                //List exigirá o using System.Collections.Generic
                Usuario usuario = await _context.Usuarios //Busca o usuário no banco através do login
                   .FirstOrDefaultAsync(x => x.Username.ToLower() == login.ToLower());

                return Ok(usuario);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
         [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Usuario uRemove = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);

                _context.Usuarios.Remove(uRemove);
                int linhasAfetedas = await _context.SaveChangesAsync();
                return Ok(linhasAfetedas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("MostrarTodos")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Usuario> lista = await _context.Usuarios.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
         public async Task<IActionResult> Update(Usuario novoUsuario)
            {
                try
                {
            
                    
                    if (novoUsuario.Id == null)
                    {
                        return BadRequest("Usuario não encontrado"); // Caso o registro não seja encontrado
                    }

                    
                    _context.Usuarios.Update(novoUsuario);
                    int linhasAfetadas = await _context.SaveChangesAsync();

                    return Ok(linhasAfetadas);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPost]
        public async Task<IActionResult> Update(Curso novoCurso)
        {
            try
            {
                if (novoCurso.Id == null)
                    {
                        return BadRequest("Curso não encontrado"); // Caso o registro não seja encontrado
                    }

                Usuario u = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == novoCurso.Id);

                if (u == null)
                   throw new System.Exception("Não existe personagem com Id informado");
                
                
                 Curso buscaCurso = await _context.Cursos.FirstOrDefaultAsync(c => c.Id == novoCurso.Id);

                if (buscaCurso != null)
                    throw new Exception("O Personagem informado já contém uma arma atribuída a ele.");

                    _context.Cursos.Update(novoCurso);
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