using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models
{
    public class ProductoModel
    {
        public int idProducto { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? nombreProducto { get; set; }

        [Required(ErrorMessage = "El campo Descripción es obligatorio")]
        public string? descripcionProducto { get; set; }

        [Required(ErrorMessage = "El campo Precio es obligatorio")]
        public decimal precioProducto { get; set; }

        [Required(ErrorMessage = "El campo Disponibilidad es obligatorio")]
        public bool disponibilidadProducto { get; set; }

        public int idCategoriaProducto { get; set; }
    }
}

