using Abp.Domain.Entities;

namespace NidaTech.DadosPublicos.Modelos
{
    public class AtividadeEconomicaModelo : Entity<int>
    {
        public string CodigoSecao { get; set; }
        public string NomeSecao { get; set; }
        public string CodigoDivisao { get; set; }
        public string NomeDivisao { get; set; }
        public string CodigoGrupo { get; set; }
        public string NomeGrupo { get; set; }
        public string CodigoClasse { get; set; }
        public string NomeClasse { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeEmpresasAtivas { get; set; }
        public int QuantidadeEmpresasInativas { get; set; }
    }
}
