using Abp.Domain.Entities;

namespace NidaTech.DadosPublicos.Modelos
{
    public class AtividadeEconomicaSecundariaModelo : Entity<int>
    {
        public string Cnpj { get; set; }
        public int AtividadeEconomicaId { get; set; }
    }
}
