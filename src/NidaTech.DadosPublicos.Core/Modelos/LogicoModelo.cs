using Abp.Domain.Entities;

namespace NidaTech.DadosPublicos.Modelos
{
    public class LogicoModelo : Entity<int>
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
