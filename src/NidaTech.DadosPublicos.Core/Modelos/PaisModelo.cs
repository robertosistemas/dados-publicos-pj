using Abp.Domain.Entities;

namespace NidaTech.DadosPublicos.Modelos
{
    public class PaisModelo : Entity<int>
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int QuantidadeEmpresasAtivas { get; set; }
        public int QuantidadeEmpresasInativas { get; set; }
    }
}
