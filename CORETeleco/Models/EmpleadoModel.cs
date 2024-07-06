using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models
{
    public class EmpleadoModel
    {
        public int idEmpleado { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? nombreEmpleado { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string? apellidoEmpleado { get; set; }

        [Required(ErrorMessage = "El campo Password es obligatorio")]
        [DataType(DataType.Password)]
        public string? passwordEmpleado { get; set; }

        [Required(ErrorMessage = "El campo Rol es obligatorio")]
        public int idRol { get; set; }

        public string? nombreRol { get; set; } // Para mostrar el nombre del rol
    }
}
