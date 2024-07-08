using Microsoft.AspNetCore.Mvc;
using CORETeleco.Models;
using CORETeleco.Datos;
using System.Collections.Generic;

namespace CORETeleco.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoDatos _productoDatos = new ProductoDatos();

        public IActionResult Listar()
        {
            List<ProductoModel> productos = _productoDatos.Listar();
            return View(productos);
        }

        public IActionResult Guardar()
        {
            ViewBag.Categorias = _productoDatos.ObtenerCategorias();
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ProductoModel producto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = _productoDatos.ObtenerCategorias();
                return View(producto);
            }

            bool respuesta = _productoDatos.Guardar(producto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
            {
                ViewBag.Categorias = _productoDatos.ObtenerCategorias();
                return View(producto);
            }
        }

        public IActionResult Editar(int id)
        {
            ProductoModel producto = _productoDatos.Obtener(id);
            if (producto == null)
                return NotFound();

            ViewBag.Categorias = _productoDatos.ObtenerCategorias();
            return View(producto);
        }

        [HttpPost]
        public IActionResult Editar(ProductoModel producto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = _productoDatos.ObtenerCategorias();
                return View(producto);
            }

            bool respuesta = _productoDatos.Editar(producto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
            {
                ViewBag.Categorias = _productoDatos.ObtenerCategorias();
                return View(producto);
            }
        }

        public IActionResult Eliminar(int id)
        {
            ProductoModel producto = _productoDatos.Obtener(id);
            if (producto == null)
                return NotFound();

            return View(producto);
        }

        [HttpPost]
        public IActionResult Eliminar(ProductoModel producto)
        {
            bool respuesta = _productoDatos.Eliminar(producto.idProducto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View(producto);
        }

    }
}
