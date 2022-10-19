using Abp.Application.Services.Dto;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public interface ISeekRequest : ILimitedResultRequest
    {
        string ReferenceValues { get; set; }
        string Direction { get; set; }
    }
}
