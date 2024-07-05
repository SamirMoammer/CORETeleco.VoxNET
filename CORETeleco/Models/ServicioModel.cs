using System;
using System.ComponentModel.DataAnnotations;
namespace CORETeleco.Models
{
    public class ServicioModel
    {
        public int IdServicio { get; set; }

        [Required]
        public string? nombreServicio { get; set; }

        [Required]
        public string? descripcionServicio { get; set; }

        [Required]
        public decimal precioServicio { get; set; }
    }
}
