using ProjetoGR.Models.Enuns;

namespace ProjetoGR.Models
{
    public class Faculdade
    {
        public int Id { get; set; }
        public string NomeFaculdade { get; set; } 
        public string Descrição { get; set; }
        public DateTime DataInicio { get; set; } 
        public DateTime DataTermino { get; set; } 
        public TipoUrgencia TipoUrgencia { get; set; }
        public List<Usuario> Usuario { get; set; }
    }
}