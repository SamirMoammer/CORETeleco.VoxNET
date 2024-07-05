using System;
using System.ComponentModel.DataAnnotations;
namespace CORETeleco.Models
{
    public class EmpleadoModel
    {
        public int IdEmpleado { get; set; }

        [Required]
        public string? nombreEmpleado { get; set; }

        [Required]
        public string? apellidoEmpleado { get; set; }

        [Required]
        public string? passwordEmpleado { get; set; }

        public int IdRol { get; set; }
    }
}
