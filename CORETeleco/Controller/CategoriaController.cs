using Microsoft.AspNetCore.Mvc;
using CORETeleco.Datos;
using CORETeleco.Models;

namespace CORETeleco.Controllers
{
    public class CategoriaController : Controller
    {
        CategoriaDatos _CategoriaDatos = new CategoriaDatos();

        public IActionResult Listar()
        {
            var oLista = _CategoriaDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(CategoriaModel oCategoria)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _CategoriaDatos.Guardar(oCategoria);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int idCategoriaProducto)
        {
            var oCategoria = _CategoriaDatos.Obtener(idCategoriaProducto);
            return View(oCategoria);
        }

        [HttpPost]
        public IActionResult Editar(CategoriaModel oCategoria)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _CategoriaDatos.Editar(oCategoria);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idCategoriaProducto)
        {
            var oCategoria = _CategoriaDatos.Obtener(idCategoriaProducto);
            return View(oCategoria);
        }

        [HttpPost]
        public IActionResult Eliminar(CategoriaModel oCategoria)
        {
            var respuesta = _CategoriaDatos.Eliminar(oCategoria.idCategoriaProducto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}


