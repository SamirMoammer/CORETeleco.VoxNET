using Microsoft.AspNetCore.Mvc;
using CORETeleco.Models;
using CORETeleco.Datos;
using System.Collections.Generic;

namespace CORETeleco.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaDatos _CategoriaDatos = new CategoriaDatos();

        public IActionResult Listar()
        {
            List<CategoriaModel> Categoria = _CategoriaDatos.Listar();
            return View(Categoria);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(CategoriaModel Categoria)
        {
            if (!ModelState.IsValid)
                return View();

            bool respuesta = _CategoriaDatos.Guardar(Categoria);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int id)
        {
            CategoriaModel categoria = _CategoriaDatos.Obtener(id);
            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Editar(CategoriaModel Categoria)
        {
            if (!ModelState.IsValid)
                return View();

            bool respuesta = _CategoriaDatos.Editar(Categoria);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int id)
        {
            CategoriaModel categoria = _CategoriaDatos.Obtener(id);
            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Eliminar(CategoriaModel categoria)
        {
            bool respuesta = _CategoriaDatos.Eliminar(categoria.idCategoriaProducto);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
