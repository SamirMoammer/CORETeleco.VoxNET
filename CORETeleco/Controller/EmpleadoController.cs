using Microsoft.AspNetCore.Mvc;
using CORETeleco.Datos;
using CORETeleco.Models;
using System;

namespace CORETeleco.Controllers
{
    public class EmpleadoController : Controller
    {
        EmpleadoDatos _EmpleadoDatos = new EmpleadoDatos();

        public IActionResult Listar()
        {
            var oLista = _EmpleadoDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(EmpleadoModel oEmpleado)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _EmpleadoDatos.Guardar(oEmpleado);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int idEmpleado)
        {
            var oEmpleado = _EmpleadoDatos.Obtener(idEmpleado);
            return View(oEmpleado);
        }

        [HttpPost]
        public IActionResult Editar(EmpleadoModel oEmpleado)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _EmpleadoDatos.Editar(oEmpleado);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idEmpleado)
        {
            var oEmpleado = _EmpleadoDatos.Obtener(idEmpleado);
            return View(oEmpleado);
        }

        [HttpPost]
        public IActionResult Eliminar(EmpleadoModel oEmpleado)
        {
            var respuesta = _EmpleadoDatos.Eliminar(oEmpleado.idEmpleado);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
