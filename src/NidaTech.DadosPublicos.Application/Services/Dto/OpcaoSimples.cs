using Abp.Application.Services.Dto;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class OpcaoSimples : EntityDto<int>
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
