using Abp.Application.Services.Dto;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class SeekSortedRequest : LimitedResultRequestDto, ISeekSortedRequest, ILimitedResultRequest, ISortedResultRequest
    {
        public virtual string Sorting { get; set; }
        public virtual string ReferenceValues { get; set; }
        public virtual string Direction { get; set; } = "Asc";
    }
}
