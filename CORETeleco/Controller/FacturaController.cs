using Microsoft.AspNetCore.Mvc;
using CORETeleco.Datos;
using CORETeleco.Models;
using System;

namespace CORETeleco.Controllers
{
    public class FacturaController : Controller
    {
        FacturaDatos _FacturaDatos = new FacturaDatos();

        public IActionResult Listar()
        {
            var oLista = _FacturaDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(FacturaModel oFactura)
        {
            if (!ModelState.IsValid)
                return View();

            oFactura.fechaFactura = DateTime.Now; // Asigna la fecha actual
            var respuesta = _FacturaDatos.Guardar(oFactura);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int idFactura)
        {
            var oFactura = _FacturaDatos.Obtener(idFactura);
            return View(oFactura);
        }

        [HttpPost]
        public IActionResult Editar(FacturaModel oFactura)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _FacturaDatos.Editar(oFactura);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idFactura)
        {
            var oFactura = _FacturaDatos.Obtener(idFactura);
            return View(oFactura);
        }

        [HttpPost]
        public IActionResult Eliminar(FacturaModel oFactura)
        {
            var respuesta = _FacturaDatos.Eliminar(oFactura.idFactura);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
