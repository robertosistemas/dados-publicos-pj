using Abp.Domain.Entities;

namespace NidaTech.DadosPublicos.Modelos
{
    public class OpcaoSimplesModelo : Entity<int>
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
