using System;
using System.ComponentModel.DataAnnotations;
namespace CORETeleco.Models
{
    public class ProductoModel
    {
        public int IdProducto { get; set; }

        [Required]
        public string? nombreProducto { get; set; }

        [Required]
        public string? descripcionProducto { get; set; }

        [Required]
        public decimal precioProducto { get; set; }

        public bool disponibilidadProducto { get; set; }

        public int IdCategoriaProducto { get; set; }
    }
}
