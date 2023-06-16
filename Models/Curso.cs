using ProjetoGR.Models.Enuns;

namespace ProjetoGR.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string NomeCurso { get; set; } 
        public string Descrição { get; set; }
        public DateTime DataInicio { get; set; } 
        public DateTime DataTermino { get; set; } 
        public TipoUrgencia TipoUrgencia { get; set; }
    }
}