using Abp.Application.Services.Dto;

namespace NidaTech.DadosPublicos.Services.Dto
{
    public interface ISeekResult<T> : IPagedResult<T>, IListResult<T>, IHasTotalCount
    {
        bool HasNext { get; set; }
        bool HasPrevious { get; set; }
        string FirstValues { get; set; }
        string LastValues { get; set; }
        string Direction { get; set; }
    }
}
