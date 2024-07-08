using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models
{
    public class ClienteModel
    {
        public int idCliente { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string nombreCliente { get; set; }

        [Required(ErrorMessage = "El campo Dirección es obligatorio")]
        public string direccionCliente { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio")]
        public string telefonoCliente { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
        public string correoCliente { get; set; }

        [Required(ErrorMessage = "El campo Cédula es obligatorio")]
        public string cedulaCliente { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        [StringLength(64, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
        public string passwordCliente { get; set; }
    }
}
