using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using NidaTech.DadosPublicos.Modelos;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    [AbpAuthorize]
    public class MotivoSituacaoCadastralAppService :
        DadosPublicosCrudAppServiceBase<
            MotivoSituacaoCadastralModelo,
            MotivoSituacaoCadastral,
            int,
            PagedAndSortedResultRequestDto,
            MotivoSituacaoCadastralCriar,
            MotivoSituacaoCadastralAtualizar>,
        IMotivoSituacaoCadastralAppService
    {
        public MotivoSituacaoCadastralAppService(IRepository<MotivoSituacaoCadastralModelo, int> repository)
            : base(repository)
        {

        }
    }
}
