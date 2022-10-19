using Abp.Application.Services.Dto;
using Abp.Domain.Uow;
using Microsoft.AspNetCore.Mvc;
using NidaTech.DadosPublicos.Services;
using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace NidaTech.DadosPublicos.Web.Views.Shared.Components.UnidadeFederacao
{
    public class UnidadeFederacaoViewComponent : DadosPublicosViewComponent
    {
        public IUnidadeFederacaoAppService _unidadeFederacaoAppService { get; set; }
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UnidadeFederacaoViewComponent(IUnidadeFederacaoAppService unidadeFederacaoAppService, IUnitOfWorkManager unitOfWorkManager) : base()
        {
            _unidadeFederacaoAppService = unidadeFederacaoAppService;
            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            this.ViewBag.IdDiv = string.IsNullOrWhiteSpace(id) ? "UnidadeFederacaoDiv" : $"{id}Div";
            this.ViewBag.IdTable = string.IsNullOrWhiteSpace(id) ? "UnidadeFederacaoTable" : $"{id}Table";

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

            var model = new UnidadeFederacaoViewModel
            {
                UnidadesFederacao = unidadesFederacao.Items
            };

            return View(model);

        }
    }
}
