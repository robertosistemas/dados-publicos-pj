using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NidaTech.DadosPublicos.Controllers;
using NidaTech.DadosPublicos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NidaTech.DadosPublicos.Web.Controllers
{
    public class MatrizFilialController : DadosPublicosControllerBase
    {

        private readonly IMatrizFilialAppService _matrizFilialAppService;

        public MatrizFilialController(IMatrizFilialAppService matrizFilialAppService)
        {
            _matrizFilialAppService = matrizFilialAppService;
        }

        // GET: MatrizFilialController
        public async Task<ActionResult> Index()
        {
            var output = await _matrizFilialAppService.GetAllAsync(new Abp.Application.Services.Dto.PagedAndSortedResultRequestDto());
            return View(output.Items);
        }

        // GET: MatrizFilialController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MatrizFilialController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MatrizFilialController/Create
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

        // GET: MatrizFilialController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MatrizFilialController/Edit/5
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

        // GET: MatrizFilialController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MatrizFilialController/Delete/5
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
