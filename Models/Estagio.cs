using ProjetoGR.Models.Enuns;

namespace ProjetoGR.Models
{
    public class Estagio
    {
        public int Id { get; set; }
        public string NomeEmpresa { get; set; } 
        public DateTime DataInicio { get; set; } 
        public DateTime DataTermino { get; set; } 
        public TipoUrgencia TipoUrgencia { get; set; }
    }
}