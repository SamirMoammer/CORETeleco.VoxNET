using System;
using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models
{
    public class ContratoModel
    {
        public int idContrato { get; set; }

        [Required(ErrorMessage = "El campo Fecha Inicio es obligatorio")]
        [Display(Name = "Fecha Inicio")]
        public DateTime fechaInicioContrato { get; set; }

        [Required(ErrorMessage = "El campo Fecha Fin es obligatorio")]
        [Display(Name = "Fecha Fin")]
        public DateTime fechaFinContrato { get; set; }

        [Required(ErrorMessage = "El campo Descripción es obligatorio")]
        public string? descripcionContrato { get; set; }

        [Display(Name = "Estado")]
        public bool estadoContrato { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "El campo Cliente es obligatorio")]
        public int idCliente { get; set; }

        [Display(Name = "Servicio")]
        [Required(ErrorMessage = "El campo Servicio es obligatorio")]
        public int idServicio { get; set; }
    }
}
