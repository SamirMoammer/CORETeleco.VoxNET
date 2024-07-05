using System;
using System.ComponentModel.DataAnnotations;
namespace CORETeleco.Models
{
    public class CategoriaModel
    {
        public int IdCategoriaProducto { get; set; }

        [Required]
        public string? categoriaProducto { get; set; }
    }
}

