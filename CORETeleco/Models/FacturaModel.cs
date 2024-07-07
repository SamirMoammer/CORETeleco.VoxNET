using System;
using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models
{
    public class FacturaModel
    {
        [Key]
        public int idFactura { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime fechaFactura { get; set; }

        [Required]
        [StringLength(10)]
        public string? metodoPagoFactura { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal impuestosFactura { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal totalFactura { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int cantidadFactura { get; set; }

        [Required]
        public int idSucursal { get; set; }

        [Required]
        public int idCliente { get; set; }

        [Required]
        public int idEmpleado { get; set; }

        [Required]
        public int idTipoComprobante { get; set; }
    }
}
