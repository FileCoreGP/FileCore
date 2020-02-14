using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FileCore.Repositories;
using FileCore.Models;

namespace FileCore.Areas.Administrador.Controllers
{
    [Area("Administrador")]
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            CategoriasRepository repos = new CategoriasRepository();
            return View(repos.GetCategoriasViewModel());
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(CategoriaViewModel categoria)
        {
            if (categoria!=null)
            {
                string error = Validar(categoria);

                if (error != "")
                {
                    ModelState.AddModelError("Error", error);
                    return View(categoria);
                }

                try
                {
                    CategoriasRepository repos = new CategoriasRepository();
                    repos.InsertCategoria(categoria);
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                    return View(categoria);
                }
            }
            return RedirectToAction("Index", "Administrador/Categoria");
        }

        public IActionResult Editar(int Id)
        {
            CategoriasRepository repos = new CategoriasRepository();
            var categoria = repos.GetCategoriaViewModelById(Id);
            if (categoria!=null)
            {
                return View(categoria);
            }
            return RedirectToAction("Index", "Administrador/Categoria");
        }

        [HttpPost]

        public IActionResult Editar(CategoriaViewModel categoria)
        {
            if (categoria != null)
            {
                string error = Validar(categoria);

                if (error != "")
                {
                    ModelState.AddModelError("Error", error);
                    return View(categoria);
                }

                try
                {
                    CategoriasRepository repos = new CategoriasRepository();
                    repos.UpdateCategoria(categoria);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Error", ex.Message);
                    return View(categoria);
                }
            }
            return RedirectToAction("Index", "Administrador/Categoria");

        }

        public IActionResult Delete(int Id)
        {
            CategoriasRepository repos = new CategoriasRepository();
            var categoria = repos.GetById(Id);
            if (categoria != null)
                repos.Delete(categoria);

            return RedirectToAction("Index", "Administrador/Categoria");
        }

        string Validar(CategoriaViewModel categoria)
        {
            if (string.IsNullOrEmpty(categoria.Nombre))
                return "El nombre no debe estar vacio";

            if (string.IsNullOrWhiteSpace(categoria.Descripcion))
                return "La descripción no debe estar vacia";

            if (categoria.Nombre.Length > 20)
                return "El Nombre solo puede contener 20 caracteres como maximo";

            if (categoria.Descripcion.Length > 80)
                return "La Descripción solo puede contener 80 caracteres como maximo";

            return "";
        }

    }
}