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
            DepartamentoRepository repos = new DepartamentoRepository();
            return View(repos.GetDepartamentosViewModel());
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(DepartamentoViewModel departamento)
        {
            if (departamento != null && ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(departamento.Nombre))
                {
                    ModelState.AddModelError("Error", "El nombre no debe estar vacio.");
                    return View(departamento);
                }

                if (departamento.Nombre.Length > 80)
                {
                    ModelState.AddModelError("Error", "El nombre solo puede contener 80 caracteres como maximo");
                    return View(departamento);
                }

                try
                {
                    DepartamentoRepository repos = new DepartamentoRepository();
                    repos.InsertDepartamento(departamento);
                    return RedirectToAction("Index", "Administrador");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                    return View(departamento);
                }
            }

            return View(departamento);
        }

        public IActionResult Editar(int Id)
        {
            DepartamentoRepository repos = new DepartamentoRepository();
            var departamento = repos.GetDepartamentoById(Id);

            if (departamento != null)
                return View(departamento);
            else
            return RedirectToAction("Index", "Administrador");
        }

        [HttpPost]
        public IActionResult Editar(DepartamentoViewModel departamento)
        {
            if (departamento != null && ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(departamento.Nombre))
                {
                    ModelState.AddModelError("Error", "El nombre no debe estar vacio.");
                    return View(departamento);
                }

                if (departamento.Nombre.Length > 80)
                {
                    ModelState.AddModelError("Error", "El nombre solo puede contener 80 caracteres como maximo");
                    return View(departamento);
                }

                try
                {
                    DepartamentoRepository repos = new DepartamentoRepository();
                    repos.UpdateDepartamento(departamento);
                    return RedirectToAction("Index", "Administrador");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                    return View(departamento);
                }
            }
            return View(departamento);
        }


        public IActionResult Delete(int Id)
        {
            DepartamentoRepository repos = new DepartamentoRepository();
            var Vdepartamento = repos.GetById(Id);

            if (Vdepartamento != null)
                repos.Delete(Vdepartamento);
            
            return RedirectToAction("Index", "Administrador");
        }
    }
}