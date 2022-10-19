using Abp.Application.Services.Dto;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class UnidadeFederacao : EntityDto<int>
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int? PaisId { get; set; }
        public int QuantidadeEmpresasAtivas { get; set; }
        public int QuantidadeEmpresasInativas { get; set; }
        public bool Mostrar { get; set; } = true;
    }
}
