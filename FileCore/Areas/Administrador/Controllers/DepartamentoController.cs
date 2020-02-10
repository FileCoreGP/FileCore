using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileCore.Models;
using FileCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FileCore.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class DepartamentoController : Controller
    {
        public IActionResult Index()
        {
            DepartamentosRepository repos = new DepartamentosRepository();
            return View(repos.GetAll());
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Departamento departamento)
        {
            if (departamento != null && ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(departamento.Nombre))
                {
                    ModelState.AddModelError("Error", "El nombre no debe estar vacio.");
                    return View(departamento);
                }

                try
                {
                    DepartamentosRepository repos = new DepartamentosRepository();
                    repos.InsertDepartamento(departamento);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                    return View(departamento);
                }
            }

            return RedirectToAction("Index","Administrador");
        }

        public IActionResult Editar(int Id) 
        {
            DepartamentosRepository repos = new DepartamentosRepository();
            var departamaento = repos.GetById(Id);

            if (departamaento != null)
                return View(departamaento);

            return RedirectToAction("Index","Administrador");
        }

        [HttpPost]
        public IActionResult Editar(Departamento departamento)
        {
            if (departamento != null && ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(departamento.Nombre))
                {
                    ModelState.AddModelError("Error","El nombre no debe estar vacio.");
                    return View(departamento);
                }

                try
                {
                    DepartamentosRepository repos = new DepartamentosRepository();
                    repos.UpdateDepartamento(departamento);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                    return View(departamento);
                }
            }
            return RedirectToAction("Index","Administrador");
        }


        public IActionResult Delete(int Id)
        {
            DepartamentosRepository repos = new DepartamentosRepository();
            var departamento = repos.GetById(Id);

            if (departamento != null)
                repos.Delete(departamento);

            return RedirectToAction("Index","Administrador");
        }
    }
}