using Abp.Domain.Entities;

namespace NidaTech.DadosPublicos.Modelos
{
    public class QualificacaoModelo : Entity<int>
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string ColetadoAtualmente { get; set; }
    }
}
