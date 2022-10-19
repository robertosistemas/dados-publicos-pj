using NidaTech.DadosPublicos.Services.Dto;
using System.Threading.Tasks;

namespace NidaTech.DadosPublicos
{
    public interface IDadosPublicosCrudAppServiceBase<TEntityDto>
    {
        Task<SeekResult<TEntityDto>> GetAllItemsAsync(SeekSortedRequest input);
    }
}
