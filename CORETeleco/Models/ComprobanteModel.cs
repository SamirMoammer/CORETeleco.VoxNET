using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models
{
    public class ComprobanteModel
    {
        public int idTipoComprobante { get; set; }

        [Required(ErrorMessage = "El campo Tipo de Comprobante es obligatorio")]
        public string? tipoComprobante { get; set; }
    }
}
