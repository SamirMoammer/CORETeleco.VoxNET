using System;
using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models
{
    public class FacturaModel
    {
        public int idFactura { get; set; }

        [Required(ErrorMessage = "El campo Fecha es obligatorio")]
        public DateTime fechaFactura { get; set; }

        [Required(ErrorMessage = "El campo Método de Pago es obligatorio")]
        public string? metodoPagoFactura { get; set; }

        [Required(ErrorMessage = "El campo Impuestos es obligatorio")]
        public decimal impuestosFactura { get; set; }

        [Required(ErrorMessage = "El campo Total es obligatorio")]
        public decimal totalFactura { get; set; }

        [Required(ErrorMessage = "El campo Cantidad es obligatorio")]
        public int cantidadFactura { get; set; }

        public int idSucursal { get; set; }
        public int idCliente { get; set; }
        public int idEmpleado { get; set; }
        public int idTipoComprobante { get; set; }
    }
}
