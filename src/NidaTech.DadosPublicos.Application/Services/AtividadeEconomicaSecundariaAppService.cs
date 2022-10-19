using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using NidaTech.DadosPublicos.Modelos;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    [AbpAuthorize]
    public class AtividadeEconomicaSecundariaAppService :
        DadosPublicosCrudAppServiceBase<
            AtividadeEconomicaSecundariaModelo,
            AtividadeEconomicaSecundaria,
            int,
            PagedAndSortedResultRequestDto,
            AtividadeEconomicaSecundariaCriar,
            AtividadeEconomicaSecundariaAtualizar>,
        IAtividadeEconomicaSecundariaAppService
    {
        public AtividadeEconomicaSecundariaAppService(IRepository<AtividadeEconomicaSecundariaModelo, int> repository)
            : base(repository)
        {

        }
    }
}
