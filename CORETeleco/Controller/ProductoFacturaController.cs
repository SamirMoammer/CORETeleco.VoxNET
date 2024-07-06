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

        public IActionResult Agregar(int idFactura)
        {
            ViewData["idFactura"] = idFactura;
            // Aquí podrías incluir lógica para obtener la lista de productos disponibles
            // y enviarla a la vista de agregar.
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(int idFactura, ProductoFacturaModel oProductoFactura)
        {
            if (!ModelState.IsValid)
                return View();

            _ProductoFacturaDatos.Guardar(idFactura, oProductoFactura.idProducto, oProductoFactura.cantidad);
            return RedirectToAction("Listar", new { idFactura });
        }

        [HttpPost]
        public IActionResult Eliminar(int idFactura, ProductoFacturaModel oProductoFactura)
        {
            _ProductoFacturaDatos.Eliminar(idFactura, oProductoFactura.idProducto);
            return RedirectToAction("Listar", new { idFactura });
        }
    }
}
