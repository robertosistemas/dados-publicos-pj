using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NidaTech.DadosPublicos.Controllers;
using NidaTech.DadosPublicos.Services;
using NidaTech.DadosPublicos.Services.Dto;
using System.Threading.Tasks;

namespace NidaTech.DadosPublicos.Web.Controllers
{
    public class MunicipiosController : DadosPublicosControllerBase
    {
        private readonly IMunicipioAppService _municipioAppService;

        public MunicipiosController(IMunicipioAppService municipioAppService) : base()
        {
            _municipioAppService = municipioAppService;
        }

        // GET: MunicipiosController
        public async Task<ActionResult> Index()
        {
            var filtro = new PagedAndSortedResultRequestDto()
            {
                Sorting = "Id",
                MaxResultCount = 10
            };
            var municipios = await _municipioAppService.GetAllAsync(filtro);
            return View(municipios.Items);
        }

        // GET: MunicipiosController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var filtro = new Municipio()
            {
                Id = id
            };
            var municipio = await _municipioAppService.GetAsync(filtro);
            return View(municipio);
        }

        // GET: MunicipiosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MunicipiosController/Create
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

        // GET: MunicipiosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MunicipiosController/Edit/5
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

        // GET: MunicipiosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MunicipiosController/Delete/5
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
