using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models
{
    public class SucursalModel
    {
        public int idSucursal { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? nombreSucursal { get; set; }

        [Required(ErrorMessage = "El campo Dirección es obligatorio")]
        public string? direccionSucursal { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio")]
        public string? telefonoSucursal { get; set; }
    }
}
