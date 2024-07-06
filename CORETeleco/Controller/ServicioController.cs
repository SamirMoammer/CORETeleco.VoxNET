using Microsoft.AspNetCore.Mvc;
using CORETeleco.Datos;
using CORETeleco.Models;

namespace CORETeleco.Controllers
{
    public class ServicioController : Controller
    {
        ServicioDatos _ServicioDatos = new ServicioDatos();

        public IActionResult Listar()
        {
            var oLista = _ServicioDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ServicioModel oServicio)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ServicioDatos.Guardar(oServicio);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int idServicio)
        {
            var oServicio = _ServicioDatos.Obtener(idServicio);
            return View(oServicio);
        }

        [HttpPost]
        public IActionResult Editar(ServicioModel oServicio)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ServicioDatos.Editar(oServicio);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idServicio)
        {
            var oServicio = _ServicioDatos.Obtener(idServicio);
            return View(oServicio);
        }

        [HttpPost]
        public IActionResult Eliminar(ServicioModel oServicio)
        {
            var respuesta = _ServicioDatos.Eliminar(oServicio.idServicio);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
