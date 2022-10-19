using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using NidaTech.DadosPublicos.Modelos;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    [AbpAuthorize]
    public class SituacaoCadastralAppService :
        DadosPublicosCrudAppServiceBase<
            SituacaoCadastralModelo,
            SituacaoCadastral,
            int,
            PagedAndSortedResultRequestDto,
            SituacaoCadastralCriar,
            SituacaoCadastralAtualizar>,
        ISituacaoCadastralAppService
    {
        public SituacaoCadastralAppService(IRepository<SituacaoCadastralModelo, int> repository)
            : base(repository)
        {

        }
    }
}