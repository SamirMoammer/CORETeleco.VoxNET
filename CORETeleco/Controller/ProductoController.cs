using Microsoft.AspNetCore.Mvc;
using CORETeleco.Datos;
using CORETeleco.Models;
using System;

namespace CORETeleco.Controllers
{
    public class ProductoController : Controller
    {
        ProductoDatos _ProductoDatos = new ProductoDatos();

        public IActionResult Listar()
        {
            var oLista = _ProductoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ProductoModel oProducto)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ProductoDatos.Guardar(oProducto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int idProducto)
        {
            var oProducto = _ProductoDatos.Obtener(idProducto);
            return View(oProducto);
        }

        [HttpPost]
        public IActionResult Editar(ProductoModel oProducto)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ProductoDatos.Editar(oProducto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idProducto)
        {
            var oProducto = _ProductoDatos.Obtener(idProducto);
            return View(oProducto);
        }

        [HttpPost]
        public IActionResult Eliminar(ProductoModel oProducto)
        {
            var respuesta = _ProductoDatos.Eliminar(oProducto.idProducto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}

