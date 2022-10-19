using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using NidaTech.DadosPublicos.Modelos;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    [AbpAuthorize]
    public class OpcaoSimplesAppService :
        DadosPublicosCrudAppServiceBase<
            OpcaoSimplesModelo,
            OpcaoSimples,
            int,
            PagedAndSortedResultRequestDto,
            OpcaoSimplesCriar,
            OpcaoSimplesAtualizar>,
        IOpcaoSimplesAppService
    {
        public OpcaoSimplesAppService(IRepository<OpcaoSimplesModelo, int> repository)
            : base(repository)
        {

        }
    }
}