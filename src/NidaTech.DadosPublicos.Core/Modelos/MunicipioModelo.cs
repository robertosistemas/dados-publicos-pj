using Abp.Domain.Entities;

namespace NidaTech.DadosPublicos.Modelos
{
    public class MunicipioModelo : Entity<int>
    {
        public string Codigo { get; set; }
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }
        public int? UnidadeFederacaoId { get; set; }
        public int QuantidadeEmpresasAtivas { get; set; }
        public int QuantidadeEmpresasInativas { get; set; }
    }
}
