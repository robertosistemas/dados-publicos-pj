using Abp.Application.Services.Dto;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public interface ISeekSortedRequest : ILimitedResultRequest, ISortedResultRequest
    {
        string ReferenceValues { get; set; }
        string Direction { get; set; }
    }
}
