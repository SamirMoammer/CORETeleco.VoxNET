using Microsoft.AspNetCore.Mvc;
using CORETeleco.Datos;
using CORETeleco.Models;
using System;

namespace CORETeleco.Controllers
{
    public class ContratoController : Controller
    {
        ContratoDatos _ContratoDatos = new ContratoDatos();

        public IActionResult Listar()
        {
            var oLista = _ContratoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContratoModel oContrato)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ContratoDatos.Guardar(oContrato);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int idContrato)
        {
            var oContrato = _ContratoDatos.Obtener(idContrato);
            return View(oContrato);
        }

        [HttpPost]
        public IActionResult Editar(ContratoModel oContrato)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ContratoDatos.Editar(oContrato);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idContrato)
        {
            var oContrato = _ContratoDatos.Obtener(idContrato);
            return View(oContrato);
        }

        [HttpPost]
        public IActionResult Eliminar(ContratoModel oContrato)
        {
            var respuesta = _ContratoDatos.Eliminar(oContrato.idContrato);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
