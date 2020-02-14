using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FileCore.Models;
using FileCore.Repositories;

namespace FileCore.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class EvidenciaController : Controller
    {
        public IActionResult Index()
        {
            EvidenciasRepository repos = new EvidenciasRepository();
            return View(repos.GetAll());
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Evidencias evidencia)
        {
            if(evidencia != null && ModelState.IsValid)
            {
                if(string.IsNullOrWhiteSpace(evidencia.Nombre))
                {
                    ModelState.AddModelError("Error", "El nombre no debe estar vacio.");
                    return View(evidencia);
                }
                if(string.IsNullOrWhiteSpace(evidencia.Tipo))
                {
                    ModelState.AddModelError("Error", "El tipo no debe estar vacio.");
                    return View(evidencia);
                }
                if (evidencia.Orden <= 0)
                {
                    ModelState.AddModelError("Error", "El orden no puede ser menor o igual a .");
                    return View(evidencia);
                }

                try
                {
                    EvidenciasRepository repos = new EvidenciasRepository();
                    repos.InsertEvidencia(evidencia);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                    return View(evidencia);
                    throw;
                }
            }

            return RedirectToAction("Index", "Administrador");
        }

        public IActionResult Editar(int id)
        {
            EvidenciasRepository repos = new EvidenciasRepository();
            var evidencia = repos.GetById(id);

            if (evidencia != null)
                return View(evidencia);

            return RedirectToAction("Index", "Administrador");
        }

        //[HttpPost]
        //public IActionResult Editar(Evidencias evidencia)
        //{

        //}
    }
}