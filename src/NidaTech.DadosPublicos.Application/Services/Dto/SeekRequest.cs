using Abp.Application.Services.Dto;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class SeekRequest : LimitedResultRequestDto, ISeekRequest, ILimitedResultRequest
    {
        public virtual string ReferenceValues { get; set; }
        public virtual string Direction { get; set; } = "Asc";
    }
}
