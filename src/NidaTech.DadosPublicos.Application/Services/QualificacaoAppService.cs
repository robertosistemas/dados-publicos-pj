using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using NidaTech.DadosPublicos.Modelos;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    [AbpAuthorize]
    public class QualificacaoAppService :
        DadosPublicosCrudAppServiceBase<
            QualificacaoModelo,
            Qualificacao,
            int,
            PagedAndSortedResultRequestDto,
            QualificacaoCriar,
            QualificacaoAtualizar>,
        IQualificacaoAppService
    {
        public QualificacaoAppService(IRepository<QualificacaoModelo, int> repository)
            : base(repository)
        {

        }
    }
}