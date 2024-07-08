using System;
using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models
{
    public class ContratoModel
    {
        public int idContrato { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Inicio es obligatorio")]
        [Display(Name = "Fecha de Inicio")]
        public DateTime fechaInicioContrato { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Fin es obligatorio")]
        [Display(Name = "Fecha de Fin")]
        public DateTime fechaFinContrato { get; set; }

        [Required(ErrorMessage = "El campo Descripción es obligatorio")]
        public string descripcionContrato { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio")]
        public bool estadoContrato { get; set; }

        [Required(ErrorMessage = "El campo Cliente es obligatorio")]
        [Display(Name = "Cliente")]
        public int idCliente { get; set; }

        [Required(ErrorMessage = "El campo Servicio es obligatorio")]
        [Display(Name = "Servicio")]
        public int idServicio { get; set; }
    }
}
