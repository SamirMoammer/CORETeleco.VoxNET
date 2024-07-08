using Microsoft.AspNetCore.Mvc;
using CORETeleco.Datos;
using CORETeleco.Models;

namespace CORETeleco.Controllers
{
    public class ProductoFacturaController : Controller
    {
        private readonly ProductoFacturaDatos _productoFacturaDatos = new ProductoFacturaDatos();

        public IActionResult Listar()
        {
            var oLista = _productoFacturaDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ProductoFacturaModel oProductoFactura)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _productoFacturaDatos.Guardar(oProductoFactura);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int idFactura, int idProducto)
        {
            var oProductoFactura = _productoFacturaDatos.Obtener(idFactura, idProducto);
            return View(oProductoFactura);
        }

        [HttpPost]
        public IActionResult Editar(ProductoFacturaModel oProductoFactura)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _productoFacturaDatos.Editar(oProductoFactura);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idFactura, int idProducto)
        {
            var oProductoFactura = _productoFacturaDatos.Obtener(idFactura, idProducto);
            return View(oProductoFactura);
        }

        [HttpPost]
        public IActionResult Eliminar(ProductoFacturaModel oProductoFactura)
        {
            var respuesta = _productoFacturaDatos.Eliminar(oProductoFactura.idFactura, oProductoFactura.idProducto);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
