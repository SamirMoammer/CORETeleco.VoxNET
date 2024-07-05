using System;
using System.ComponentModel.DataAnnotations;
namespace CORETeleco.Models
{
    public class ContratoModel
    {
        public int IdContrato { get; set; }

        [Required]
        public DateTime fechaInicioContrato { get; set; }

        [Required]
        public DateTime fechaFinContrato { get; set; }

        [Required]
        public string? descripcionContrato { get; set; }

        public bool estadoContrato { get; set; }

        public int IdCliente { get; set; }
        public int IdServicio { get; set; }
    }
}