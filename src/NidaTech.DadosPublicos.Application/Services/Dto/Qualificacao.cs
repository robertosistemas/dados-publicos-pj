using Abp.Application.Services.Dto;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class Qualificacao : EntityDto<int>
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string ColetadoAtualmente { get; set; }
    }
}
