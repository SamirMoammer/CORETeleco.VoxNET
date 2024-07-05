using System;
using System.ComponentModel.DataAnnotations;
namespace CORETeleco.Models
{
    public class FacturaModel
    {
        public int IdFactura { get; set; }

        [Required]
        public DateTime fechaFactura { get; set; }

        [Required]
        public string? metodoPagoFactura { get; set; }

        [Required]
        public decimal impuestosFactura { get; set; }

        [Required]
        public decimal totalFactura { get; set; }

        [Required]
        public int cantidadFactura { get; set; }

        public int IdSucursal { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public int IdTipoComprobante { get; set; }
    }
}