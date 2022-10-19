using Abp.Application.Services.Dto;
using Abp.Domain.Uow;
using Microsoft.AspNetCore.Mvc;
using NidaTech.DadosPublicos.Services;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace NidaTech.DadosPublicos.Web.Views.Shared.Components.UnidadeFederacaoChart
{
    public class UnidadeFederacaoChartViewComponent : DadosPublicosViewComponent
    {
        public IUnidadeFederacaoAppService _unidadeFederacaoAppService { get; set; }
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UnidadeFederacaoChartViewComponent(IUnidadeFederacaoAppService unidadeFederacaoAppService, IUnitOfWorkManager unitOfWorkManager) : base()
        {
            _unidadeFederacaoAppService = unidadeFederacaoAppService;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            this.ViewBag.IdDiv = string.IsNullOrWhiteSpace(id) ? "UnidadeFederacaoChartDiv" : $"{id}ChartDiv";
            this.ViewBag.IdCanvas = string.IsNullOrWhiteSpace(id) ? "UnidadeFederacaoChartCanvas" : $"{id}ChartCanvas";

            var filtro = new Services.Dto.UnidadeFederacaoRequest()
            {
                Mostrar = true,
                Sorting = "Nome",
                MaxResultCount = 50
            };

            PagedResultDto<Services.Dto.UnidadeFederacao> unidadesFederacao;
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                unidadesFederacao = await _unidadeFederacaoAppService.GetAllAsync(filtro);
                unitOfWork.Complete();
            }

            this.ViewBag.EstadosFormatados = unidadesFederacao.Items
                .Select(og =>
                {
                    dynamic eo = new ExpandoObject();
                    eo.Id = og.Id;
                    eo.Nome = og.Nome;
                    eo.Quantidade = (double)og.QuantidadeEmpresasAtivas / 1000000;
                    eo.QuantidadeTexto = $"{eo.Quantidade:0.00} {(eo.Quantidade <= 1 ? "Milhão" : "Milhões")}";
                    return eo;
                }).ToArray();

            var model = new UnidadeFederacaoChartViewModel
            {
                UnidadesFederacao = unidadesFederacao.Items
            };

            return View(model);
        }
    }
}
