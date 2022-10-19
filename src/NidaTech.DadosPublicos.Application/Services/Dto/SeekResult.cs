using Abp.Application.Services.Dto;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public class SeekResult<T> : PagedResultDto<T>, ISeekResult<T>, IPagedResult<T>, IListResult<T>, IHasTotalCount
    {
        public virtual bool HasNext { get; set; }
        public virtual bool HasPrevious { get; set; }
        public virtual string FirstValues { get; set; }
        public virtual string LastValues { get; set; }
        public virtual string Direction { get; set; } = "ASC";
    }
}
