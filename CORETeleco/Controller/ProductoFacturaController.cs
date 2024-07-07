using Microsoft.AspNetCore.Mvc;
using CORETeleco.Datos;
using CORETeleco.Models;

namespace CORETeleco.Controllers
{
    public class ProductoFacturaController : Controller
    {
        ProductoFacturaDatos _ProductoFacturaDatos = new ProductoFacturaDatos();

        public IActionResult Listar(int idFactura)
        {
            var oLista = _ProductoFacturaDatos.Listar(idFactura);
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

            var respuesta = _ProductoFacturaDatos.Guardar(oProductoFactura);

            if (respuesta)
                return RedirectToAction("Listar", new { idFactura = oProductoFactura.idFactura });
            else
                return View();
        }

        public IActionResult Editar(int idFactura, int idProducto)
        {
            var oProductoFactura = new ProductoFacturaModel { idFactura = idFactura, idProducto = idProducto };
            return View(oProductoFactura);
        }

        [HttpPost]
        public IActionResult Editar(ProductoFacturaModel oProductoFactura)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ProductoFacturaDatos.Editar(oProductoFactura);

            if (respuesta)
                return RedirectToAction("Listar", new { idFactura = oProductoFactura.idFactura });
            else
                return View();
        }

        public IActionResult Eliminar(int idFactura, int idProducto)
        {
            var oProductoFactura = new ProductoFacturaModel { idFactura = idFactura, idProducto = idProducto };
            return View(oProductoFactura);
        }

        [HttpPost]
        public IActionResult Eliminar(ProductoFacturaModel oProductoFactura)
        {
            var respuesta = _ProductoFacturaDatos.Eliminar(oProductoFactura.idFactura, oProductoFactura.idProducto);

            if (respuesta)
                return RedirectToAction("Listar", new { idFactura = oProductoFactura.idFactura });
            else
                return View();
        }
    }
}
