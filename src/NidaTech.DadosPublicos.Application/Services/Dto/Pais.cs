using Abp.Application.Services.Dto;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class Pais : EntityDto<int>
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int QuantidadeEmpresasAtivas { get; set; }
        public int QuantidadeEmpresasInativas { get; set; }
    }
}
