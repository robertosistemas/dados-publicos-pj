using Abp.Application.Services.Dto;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class AtividadeEconomicaSecundaria : EntityDto<int>
    {
        public string Cnpj { get; set; }
        public int AtividadeEconomicaId { get; set; }
    }
}
