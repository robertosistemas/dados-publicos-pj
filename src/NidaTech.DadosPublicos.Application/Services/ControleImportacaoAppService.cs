using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using NidaTech.DadosPublicos.Modelos;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    [AbpAuthorize]
    public class ControleImportacaoAppService :
        DadosPublicosCrudAppServiceBase<
            ControleImportacaoModelo,
            ControleImportacao,
            int,
            PagedAndSortedResultRequestDto,
            ControleImportacaoCriar,
            ControleImportacaoAtualizar>,
        IControleImportacaoAppService
    {
        public ControleImportacaoAppService(IRepository<ControleImportacaoModelo, int> repository)
            : base(repository)
        {

        }
    }
}
