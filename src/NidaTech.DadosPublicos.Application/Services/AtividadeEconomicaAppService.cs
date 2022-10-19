using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using NidaTech.DadosPublicos.Modelos;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    [AbpAuthorize]
    public class AtividadeEconomicaAppService :
        DadosPublicosCrudAppServiceBase<
            AtividadeEconomicaModelo,
            AtividadeEconomica,
            int,
            PagedAndSortedResultRequestDto,
            AtividadeEconomicaCriar,
            AtividadeEconomicaAtualizar>,
        IAtividadeEconomicaAppService
    {
        public AtividadeEconomicaAppService(IRepository<AtividadeEconomicaModelo, int> repository)
            : base(repository)
        {

        }
    }
}
