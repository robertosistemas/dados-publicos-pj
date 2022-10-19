using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NidaTech.DadosPublicos.Services.Dto;

namespace NidaTech.DadosPublicos.Services
{
    public interface IAtividadeEconomicaAppService :
        IAsyncCrudAppService< //Define métodos para CRUD
            AtividadeEconomica, // Usado para mostrar Atividades Economicas
            int, // Chave primária da entidade Atividade Economica
            PagedAndSortedResultRequestDto, // Usado para paginar/Ordenar
            AtividadeEconomicaCriar, // Usado para criar uma Atividade Economica
            AtividadeEconomicaAtualizar> // Usado para atualizar uma Atividade Economica
    {

    }
}
