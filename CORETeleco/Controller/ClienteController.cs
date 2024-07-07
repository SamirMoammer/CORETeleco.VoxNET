using CORETeleco.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CORETeleco.Controllers
{
    public class ClienteController : Controller
    {
        // Aquí se puede implementar un repositorio o servicio para manejar los datos del cliente
        private List<ClienteModel> Cliente = new List<ClienteModel>();

        // GET: Cliente/InsertarCliente
        public IActionResult InsertarCliente()
        {
            return View();
        }

        // POST: Cliente/InsertarCliente
        [HttpPost]
        public IActionResult InsertarCliente(ClienteModel cliente)
        {
            try
            {
                // Aquí podrías agregar la lógica para guardar el cliente en la base de datos o donde corresponda
                Cliente.Add(cliente);
                return RedirectToAction("Listar");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al insertar el cliente: " + ex.Message);
                return View(cliente);
            }
        }

        // GET: Cliente/Listar
        public IActionResult Listar()
        {
            return View(Cliente);
        }
    }
}
