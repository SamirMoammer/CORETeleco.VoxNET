using Microsoft.AspNetCore.Mvc;
using CORETeleco.Datos;
using CORETeleco.Models;

namespace CORETeleco.Controllers
{
    public class RolController : Controller
    {
        RolDatos _RolDatos = new RolDatos();

        public IActionResult Listar()
        {
            var oLista = _RolDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(RolModel oRol)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _RolDatos.Guardar(oRol);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int idRol)
        {
            var oRol = _RolDatos.Obtener(idRol);
            return View(oRol);
        }

        [HttpPost]
        public IActionResult Editar(RolModel oRol)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _RolDatos.Editar(oRol);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idRol)
        {
            var oRol = _RolDatos.Obtener(idRol);
            return View(oRol);
        }

        [HttpPost]
        public IActionResult Eliminar(RolModel oRol)
        {
            var respuesta = _RolDatos.Eliminar(oRol.idRol);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
