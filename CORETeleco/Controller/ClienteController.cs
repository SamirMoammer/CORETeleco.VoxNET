using Microsoft.AspNetCore.Mvc;
using CORETeleco.Datos;
using CORETeleco.Models;

namespace CORETeleco.Controllers
{
    public class ClienteController : Controller
    {
        ClienteDatos _ClienteDatos = new ClienteDatos();

        public IActionResult Listar()
        {
            var oLista = _ClienteDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ClienteModel oCliente)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ClienteDatos.Guardar(oCliente);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int idCliente)
        {
            var oCliente = _ClienteDatos.Obtener(idCliente);
            return View(oCliente);
        }

        [HttpPost]
        public IActionResult Editar(ClienteModel oCliente)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ClienteDatos.Editar(oCliente);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idCliente)
        {
            var oCliente = _ClienteDatos.Obtener(idCliente);
            return View(oCliente);
        }

        [HttpPost]
        public IActionResult Eliminar(ClienteModel oCliente)
        {
            var respuesta = _ClienteDatos.Eliminar(oCliente.idCliente);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
