using Abp.Application.Services.Dto;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class Logico : EntityDto<int>
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
