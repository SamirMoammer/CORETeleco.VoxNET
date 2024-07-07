using CORETeleco.Datos;
using CORETeleco.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CORETeleco.Controllers
{
    public class ContratoController : Controller
    {
        private readonly ClienteDatos _ClienteDatos;
        private readonly ServicioDatos _ServicioDatos;
        private readonly ContratoDatos _ContratoDatos;

        public ContratoController()
        {
            _ClienteDatos = new ClienteDatos();
            _ServicioDatos = new ServicioDatos();
            _ContratoDatos = new ContratoDatos();
        }

        [HttpGet]
        public IActionResult InsertarContrato()
        {
            // Obtener listas de clientes y servicios
            var Cliente = _ClienteDatos.Listar();
            var Servicio = _ServicioDatos.Listar();

            // Pasar las listas a la vista a través de ViewBag
            ViewBag.Cliente = new SelectList(Cliente, "idCliente", "nombreCliente");
            ViewBag.Servicio = new SelectList(Servicio, "idServicio", "nombreServicio");

            return View(new ContratoModel());
        }

        [HttpPost]
        public IActionResult Guardar(ContratoModel Contrato)
        {
            if (ModelState.IsValid)
            {
                bool rpta;
                if (Contrato.idContrato == 0)
                {
                    // Nuevo contrato
                    rpta = _ContratoDatos.Guardar(Contrato);
                }
                else
                {
                    // Editar contrato
                    rpta = _ContratoDatos.Editar(Contrato);
                }

                if (rpta)
                {
                    return RedirectToAction("Listar");
                }
                else
                {
                    ModelState.AddModelError("", "No se pudo guardar el contrato");
                }
            }

            // Obtener listas de clientes y servicios nuevamente en caso de error
            ViewBag.Cliente = new SelectList(_ClienteDatos.Listar(), "idCliente", "nombreCliente");
            ViewBag.Servicio = new SelectList(_ServicioDatos.Listar(), "idServicio", "nombreServicio");

            return View("Guardar", Contrato);
        }

        // Otros métodos del controlador...
    }
}