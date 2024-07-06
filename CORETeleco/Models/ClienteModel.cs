using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models
{
    public class ClienteModel
    {
        public int idCliente { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? nombreCliente { get; set; }

        [Required(ErrorMessage = "El campo Dirección es obligatorio")]
        public string? direccionCliente { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio")]
        [RegularExpression(@"^\d{8,15}$", ErrorMessage = "El Teléfono debe contener entre 8 y 15 dígitos")]
        public string? telefonoCliente { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El Correo no tiene un formato válido")]
        public string? correoCliente { get; set; }

        [Required(ErrorMessage = "El campo Cédula es obligatorio")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "La Cédula debe contener exactamente 13 dígitos")]
        public string? cedulaCliente { get; set; }

        public string? passwordCliente { get; set; }
    }
}
