using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NidaTech.DadosPublicos.Controllers;
using NidaTech.DadosPublicos.Services;
using NidaTech.DadosPublicos.Services.Dto;
using System.Threading.Tasks;

namespace NidaTech.DadosPublicos.Web.Controllers
{
    public class UnidadesFederacaoController : DadosPublicosControllerBase
    {
        private readonly IUnidadeFederacaoAppService _unidadeFederacaoAppService;

        public UnidadesFederacaoController(IUnidadeFederacaoAppService unidadeFederacaoAppService) : base()
        {
            _unidadeFederacaoAppService = unidadeFederacaoAppService;
        }

        // GET: UnidadesFederacaoController
        public async Task<ActionResult> Index()
        {
            var filtro = new UnidadeFederacaoRequest()
            {
                Mostrar = true,
                Sorting = "Id",
                MaxResultCount = 10
            };
            var unidadeFederacaos = await _unidadeFederacaoAppService.GetAllAsync(filtro);
            return View(unidadeFederacaos.Items);
        }

        // GET: UnidadesFederacaoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var filtro = new UnidadeFederacao()
            {
                Id = id
            };
            var unidadeFederacao = await _unidadeFederacaoAppService.GetAsync(filtro);
            return View(unidadeFederacao);
        }

        // POST: UnidadesFederacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PesquisarEmpresas(string PesquisaEmpresasInput)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UnidadesFederacaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnidadesFederacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UnidadesFederacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UnidadesFederacaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UnidadesFederacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UnidadesFederacaoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
