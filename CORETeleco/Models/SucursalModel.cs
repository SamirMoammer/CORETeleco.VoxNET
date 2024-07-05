using System;
using System.ComponentModel.DataAnnotations;
namespace CORETeleco.Models
{
    public class SucursalModel
    {
        public int IdSucursal { get; set; }

        [Required]
        public string? nombreSucursal { get; set; }

        [Required]
        public string? direccionSucursal { get; set; }

        [Required]
        public string? telefonoSucursal { get; set; }
    }

}