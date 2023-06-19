using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoGR.Models;
using ProjetoGR.Models.Enuns;
using ProjetoGR.Utils;
using System;

namespace ProjetoGR.Data
{
    public class DataContext : DbContext
    {
          public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Estagio> Estagios { get; set; }
        public DbSet<Faculdade> Faculdades { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.Entity<Curso>().HasData
            (
            new Curso (){ Id = 1, NomeCurso = "Introdução à Programação em Python", Descrição = "Um curso introdutório de programação em Python.", DataInicio = new DateTime(2023, 7, 1), DataTermino = new DateTime(2023, 7, 30), TipoUrgencia = TipoUrgencia.Média },
            new Curso (){ Id = 2, NomeCurso = "Desenvolvimento Web com HTML e CSS", Descrição = "Aprenda a criar sites utilizando HTML e CSS.", DataInicio = new DateTime(2023, 8, 15), DataTermino = new DateTime(2023, 9, 15), TipoUrgencia = TipoUrgencia.Baixa },
            new Curso (){ Id = 3, NomeCurso = "JavaScript Avançado", Descrição = "Aprofunde seus conhecimentos em JavaScript e aprenda técnicas avançadas de programação.", DataInicio = new DateTime(2023, 9, 1), DataTermino = new DateTime(2023, 10, 15), TipoUrgencia = TipoUrgencia.Alta },
            new Curso (){ Id = 4, NomeCurso = "Introdução à Ciência de Dados com Python", Descrição = "Um curso introdutório sobre ciência de dados utilizando a linguagem Python.", DataInicio = new DateTime(2023, 7, 10), DataTermino = new DateTime(2023, 8, 5), TipoUrgencia = TipoUrgencia.Média },
            new Curso (){ Id = 5, NomeCurso = "Desenvolvimento de Aplicações Android", Descrição = "Aprenda a criar aplicativos para dispositivos Android utilizando Java e Android Studio.", DataInicio = new DateTime(2023, 8, 20), DataTermino = new DateTime(2023, 9, 30), TipoUrgencia = TipoUrgencia.Alta },
            new Curso (){ Id = 6, NomeCurso = "Programação Orientada a Objetos em C#", Descrição = "Aprenda os conceitos de programação orientada a objetos utilizando a linguagem C#.", DataInicio = new DateTime(2023, 9, 5), DataTermino = new DateTime(2023, 10, 5), TipoUrgencia = TipoUrgencia.Média },
            new Curso (){ Id = 7, NomeCurso = "Desenvolvimento Full Stack com Node.js e React", Descrição = "Aprenda a desenvolver aplicações web full stack utilizando Node.js no backend e React no frontend.", DataInicio = new DateTime(2023, 8, 1), DataTermino = new DateTime(2023, 9, 30), TipoUrgencia = TipoUrgencia.Alta },
            new Curso (){ Id = 8, NomeCurso = "Introdução à Inteligência Artificial", Descrição = "Um curso introdutório sobre os fundamentos e aplicações da inteligência artificial.", DataInicio = new DateTime(2023, 10, 1), DataTermino = new DateTime(2023, 9, 30), TipoUrgencia = TipoUrgencia.Alta}

            );
            Usuario user = new Usuario();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[]salt);
            user.Id = 1;
            user.Username = "PrimeiroUsuario";
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.Perfil = "chefe";
            user.Email = "seuEmail@gmail.com";
            

            modelBuilder.Entity<Usuario>().HasData(user);            
            //Fim da criação do usuário padrão.   

            //Define que se o Perfil não for informado, o valor padrão será jogador
            modelBuilder.Entity<Usuario>().Property(u => u.Perfil).HasDefaultValue("colaboradores");
      
            
            modelBuilder.Entity<Faculdade>().HasData
            (
            new Faculdade()
            {
                Id = 1,
                NomeFaculdade = "Faculdade de Ciência da Computação",
                Descrição = "Faculdade focada em cursos de ciência da computação e desenvolvimento de software.",
                DataInicio = new DateTime(2023, 9, 1),
                DataTermino = new DateTime(2027, 6, 30),
                TipoUrgencia = TipoUrgencia.Alta
            },
            new Faculdade()
            {
                Id = 2,
                NomeFaculdade = "Faculdade de Engenharia de Software",
                Descrição = "Faculdade especializada em cursos de engenharia de software e desenvolvimento ágil.",
                DataInicio = new DateTime(2023, 8, 15),
                DataTermino = new DateTime(2028, 7, 31),
                TipoUrgencia = TipoUrgencia.Alta
            },
            new Faculdade()
            {
                Id = 3,
                NomeFaculdade = "Faculdade de Sistemas de Informação",
                Descrição = "Faculdade com enfoque em cursos de sistemas de informação e gestão de projetos de TI.",
                DataInicio = new DateTime(2023, 9, 1),
                DataTermino = new DateTime(2027, 6, 30),
                TipoUrgencia = TipoUrgencia.Baixa
            }  
            );
            modelBuilder.Entity<Estagio>().HasData(
            new Estagio()
            {
                Id = 1,
                NomeEmpresa = "Empresa ABC",
                DataInicio = new DateTime(2023, 7, 1),
                DataTermino = new DateTime(2023, 12, 31),
                TipoUrgencia = TipoUrgencia.Baixa
            },
            new Estagio()
            {
                Id = 2,
                NomeEmpresa = "Empresa XYZ",
                DataInicio = new DateTime(2023, 8, 15),
                DataTermino = new DateTime(2024, 2, 29),
                TipoUrgencia = TipoUrgencia.Média
            },
            new Estagio()
            {
                Id = 3,
                NomeEmpresa = "Empresa 123",
                DataInicio = new DateTime(2023, 9, 1),
                DataTermino = new DateTime(2024, 3, 31),
                TipoUrgencia = TipoUrgencia.Alta
            },
            new Estagio()
            {
                Id = 4,
                NomeEmpresa = "Empresa ABCD",
                DataInicio = new DateTime(2023, 10, 1),
                DataTermino = new DateTime(2024, 3, 31),
                TipoUrgencia = TipoUrgencia.Média
            },
            new Estagio(){Id = 5,NomeEmpresa = "Empresa XYZW",DataInicio = new DateTime(2023, 11, 15),DataTermino = new DateTime(2024, 6, 30),TipoUrgencia = TipoUrgencia.Baixa},
            new Estagio(){Id = 6,NomeEmpresa = "Empresa 1234",DataInicio = new DateTime(2024, 1, 1),DataTermino = new DateTime(2024, 7, 31),TipoUrgencia = TipoUrgencia.Alta}
   
);


        }

    }
}