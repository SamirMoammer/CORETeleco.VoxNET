using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models
{
    public class ProductoModel
    {
        public int idProducto { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string nombreProducto { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public string descripcionProducto { get; set; }

        [Required(ErrorMessage = "El Precio es obligatorio")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "El campo Precio debe ser un número válido.")]
        public decimal precioProducto { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public bool disponibilidadProducto { get; set; }

        [Required(ErrorMessage = "El campo es obligatorio")]
        public int idCategoriaProducto { get; set; }
    }
}
