using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models
{
    public class ProductoModel
    {
        public int idProducto { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        public string? nombreProducto { get; set; }

        [Required(ErrorMessage = "La descripción del producto es obligatoria")]
        public string? descripcionProducto { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio")]
        public decimal precioProducto { get; set; }

        [Required(ErrorMessage = "La disponibilidad del producto es obligatoria")]
        public int disponibilidadProducto { get; set; }

        [Required(ErrorMessage = "La categoría del producto es obligatoria")]
        public int idCategoriaProducto { get; set; }

        public CategoriaModel? Categoria { get; set; }
    }
}
