using Microsoft.AspNetCore.Mvc;
using CORETeleco.Models;
using CORETeleco.Datos;
using System.Collections.Generic;

namespace CORETeleco.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoDatos _ProductoDatos = new ProductoDatos();

        public IActionResult Listar()
        {
            List<ProductoModel> Productos = _ProductoDatos.Listar();
            return View(Productos);
        }

        public IActionResult Guardar()
        {
            ViewBag.Categorias = _ProductoDatos.ObtenerCategorias();
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ProductoModel Producto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = _ProductoDatos.ObtenerCategorias();
                return View(Producto);
            }

            bool respuesta = _ProductoDatos.Guardar(Producto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
            {
                ViewBag.Categorias = _ProductoDatos.ObtenerCategorias();
                return View(Producto);
            }
        }

        public IActionResult Editar(int id)
        {
            ProductoModel Producto = _ProductoDatos.Obtener(id);
            if (Producto == null)
                return NotFound();

            ViewBag.Categorias = _ProductoDatos.ObtenerCategorias();
            return View(Producto);
        }

        [HttpPost]
        public IActionResult Editar(ProductoModel Producto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = _ProductoDatos.ObtenerCategorias();
                return View(Producto);
            }

            bool respuesta = _ProductoDatos.Editar(Producto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
            {
                ViewBag.Categorias = _ProductoDatos.ObtenerCategorias();
                return View(Producto);
            }
        }

        public IActionResult Eliminar(int id)
        {
            ProductoModel Producto = _ProductoDatos.Obtener(id);
            if (Producto == null)
                return NotFound();

            return View(Producto);
        }

        [HttpPost]
        public IActionResult Eliminar(ProductoModel Producto)
        {
            bool respuesta = _ProductoDatos.Eliminar(Producto.idProducto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View(Producto);
        }

    }
}
