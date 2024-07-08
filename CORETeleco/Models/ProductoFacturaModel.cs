using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models
{
    public class ProductoFacturaModel
    {
        public int idFactura { get; set; }
        public int idProducto { get; set; }

        [Required(ErrorMessage = "El campo Cantidad es obligatorio")]
        public int cantidad { get; set; }
    }
}
