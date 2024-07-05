using System;
using System.ComponentModel.DataAnnotations;
namespace CORETeleco.Models
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }

        [Required]
        public string? nombreCliente { get; set; }

        [Required]
        public string? direccionCliente { get; set; }

        [Required]
        public string?telefonoCliente { get; set; }

        [Required]
        public string? correoCliente { get; set; }

        [Required]
        public string? cedulaCliente { get; set; }

        [Required]
        public string? passwordCliente { get; set; }
    }
}