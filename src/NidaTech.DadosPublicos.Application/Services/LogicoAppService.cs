using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using NidaTech.DadosPublicos.Modelos;
using NidaTech.DadosPublicos.Services.Dto;
using System.Threading.Tasks;

namespace NidaTech.DadosPublicos.Services
{
    [AbpAuthorize]
    public class LogicoAppService :
        DadosPublicosCrudAppServiceBase<
            LogicoModelo,
            Logico,
            int,
            PagedAndSortedResultRequestDto,
            LogicoCriar,
            LogicoAtualizar>,
        ILogicoAppService
    {
        public LogicoAppService(IRepository<LogicoModelo, int> repository)
            : base(repository)
        {

        }

        [AbpAllowAnonymous]
        public virtual Task<PagedResultDto<Logico>> GetItemsAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetAllAsync(input);
        }

    }
}