using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    public interface IControleImportacaoAppService :
        IAsyncCrudAppService<
            ControleImportacao,
            int,
            PagedAndSortedResultRequestDto,
            ControleImportacaoCriar,
            ControleImportacaoAtualizar>
    {

    }
}
