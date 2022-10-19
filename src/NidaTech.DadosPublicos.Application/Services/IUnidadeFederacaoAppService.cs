using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    public interface IUnidadeFederacaoAppService :
        IAsyncCrudAppService<
            UnidadeFederacao,
            int,
            UnidadeFederacaoRequest,
            UnidadeFederacaoCriar,
            UnidadeFederacaoAtualizar>
    {

    }
}
