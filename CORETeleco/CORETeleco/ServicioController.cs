
using Microsoft.AspNetCore.Mvc;
using CORETeleco.Datos;
using CORETeleco.Models;

namespace CRUD_CORE.Controllers
{
    public class ServicioController : Controller
    {

        ServicioDatos _ServicioDatos = new ServicioDatos();

        public IActionResult ListarServicios()
        {
            //Mostrara una lista de servicios
            var oListaServicios = _ServicioDatos.ListarServicios();

            return View(oListaServicios);
        }

        public IActionResult InsertarServicio()
        {
            //Solo debevuelve la vista
            return View();
        }

        [HttpPost]
        public IActionResult InsertarServicio(ServicioModel oServicio)
        {
            //Recibe el objeto para guardarlo en la bd

           var respuesta = _ServicioDatos.InsertarServicio(oServicio);

            if (respuesta)
                return RedirectToAction("ListarServicios");
            else
                return View();
        }
    }
}
 
