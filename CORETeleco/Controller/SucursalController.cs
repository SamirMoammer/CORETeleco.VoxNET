using Microsoft.AspNetCore.Mvc;
using CORETeleco.Datos;
using CORETeleco.Models;

namespace CORETeleco.Controllers
{
    public class SucursalController : Controller
    {
        SucursalDatos _SucursalDatos = new SucursalDatos();

        public IActionResult Listar()
        {
            var oLista = _SucursalDatos.Listar();
            return View(oLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(SucursalModel oSucursal)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _SucursalDatos.Guardar(oSucursal);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int idSucursal)
        {
            var oSucursal = _SucursalDatos.Obtener(idSucursal);
            return View(oSucursal);
        }

        [HttpPost]
        public IActionResult Editar(SucursalModel oSucursal)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _SucursalDatos.Editar(oSucursal);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int idSucursal)
        {
            var oSucursal = _SucursalDatos.Obtener(idSucursal);
            return View(oSucursal);
        }

        [HttpPost]
        public IActionResult Eliminar(SucursalModel oSucursal)
        {
            var respuesta = _SucursalDatos.Eliminar(oSucursal.idSucursal);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
