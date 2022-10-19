using Abp.Domain.Entities;

namespace NidaTech.DadosPublicos.Modelos
{
    public class MotivoSituacaoCadastralModelo : Entity<int>
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
