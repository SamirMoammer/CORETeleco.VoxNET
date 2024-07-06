using Microsoft.AspNetCore.Mvc;
using CORETeleco.Datos;
using CORETeleco.Models;

namespace CORETeleco.Controllers
{
    public class ComprobanteController : Controller
    {
        ComprobanteDatos _ComprobanteDatos = new ComprobanteDatos();

        public IActionResult Listar()
        {
            var oLista = _ComprobanteDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ComprobanteModel oComprobante)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ComprobanteDatos.Guardar(oComprobante);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int idTipoComprobante)
        {
            var oComprobante = _ComprobanteDatos.Obtener(idTipoComprobante);
            return View(oComprobante);
        }

        [HttpPost]
        public IActionResult Editar(ComprobanteModel oComprobante)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ComprobanteDatos.Editar(oComprobante);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idTipoComprobante)
        {
            var oComprobante = _ComprobanteDatos.Obtener(idTipoComprobante);
            return View(oComprobante);
        }

        [HttpPost]
        public IActionResult Eliminar(ComprobanteModel oComprobante)
        {
            var respuesta = _ComprobanteDatos.Eliminar(oComprobante.idTipoComprobante);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}


