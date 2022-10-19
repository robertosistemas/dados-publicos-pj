using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using NidaTech.DadosPublicos.Modelos;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    [AbpAuthorize]
    public class NaturezaJuridicaAppService :
        DadosPublicosCrudAppServiceBase<
            NaturezaJuridicaModelo,
            NaturezaJuridica,
            int,
            PagedAndSortedResultRequestDto,
            NaturezaJuridicaCriar,
            NaturezaJuridicaAtualizar>,
        INaturezaJuridicaAppService
    {
        public NaturezaJuridicaAppService(IRepository<NaturezaJuridicaModelo, int> repository)
            : base(repository)
        {

        }
    }
}