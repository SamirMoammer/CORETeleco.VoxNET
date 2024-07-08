using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models
{
    public class ContratoModel
    {
        public int idContrato { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Inicio es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime fechaInicioContrato { get; set; }

        [Required(ErrorMessage = "El campo Fecha de Fin es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime fechaFinContrato { get; set; }

        [Required(ErrorMessage = "El campo Descripción es obligatorio")]
        public string? descripcionContrato { get; set; }

        [Required(ErrorMessage = "El campo Estado es obligatorio")]
        public bool estadoContrato { get; set; }

        [Required(ErrorMessage = "El campo Cliente es obligatorio")]
        public int idCliente { get; set; }

        [Required(ErrorMessage = "El campo Servicio es obligatorio")]
        public int idServicio { get; set; }
    }
}
