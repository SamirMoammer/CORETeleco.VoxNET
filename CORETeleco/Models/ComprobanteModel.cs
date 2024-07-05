using System;
using System.ComponentModel.DataAnnotations;
namespace CORETeleco.Models
{
    public class ComprobanteModel
    {
        public int IdTipoComprobante { get; set; }

        [Required]
        public string? tipoComprobante { get; set; }
    }
}

