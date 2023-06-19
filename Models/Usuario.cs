using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ProjetoGR.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Idade { get; set; }
        public TimeSpan TempoEstudo { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string PasswordString { get; set; }
        public string Perfil { get; set; }
        public DateTime? DataAcesso { get; set; } 
         [NotMapped] // para não salvar no banco de dados essa informação 
        
        public List<Curso> Cursos { get; set; }
        public List<Faculdade> Faculdades { get; set; }
        public List<Estagio> Estagios { get; set; }

    }
}