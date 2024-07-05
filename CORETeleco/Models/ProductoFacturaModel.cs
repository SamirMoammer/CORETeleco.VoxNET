using System;
using System.ComponentModel.DataAnnotations;
namespace CORETeleco.Models
{
    public class ProductoFacturaModel
    {
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }

        public FacturaModel Factura { get; set; }
        public ProductoModel Producto { get; set; }
    }
}
