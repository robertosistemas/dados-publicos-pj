using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NidaTech.DadosPublicos.Services.Dto;
using System.Threading.Tasks;

namespace NidaTech.DadosPublicos.Services
{
    public interface ILogicoAppService :
        IAsyncCrudAppService<
            Logico,
            int,
            PagedAndSortedResultRequestDto,
            LogicoCriar,
            LogicoAtualizar>
    {
        Task<PagedResultDto<Logico>> GetItemsAsync(PagedAndSortedResultRequestDto input);
    }
}
