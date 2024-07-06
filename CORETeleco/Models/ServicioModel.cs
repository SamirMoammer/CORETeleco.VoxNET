using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models
{
    public class ServicioModel
    {
        public int idServicio { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? nombreServicio { get; set; }

        [Required(ErrorMessage = "El campo Descripción es obligatorio")]
        public string? descripcionServicio { get; set; }

        [Required(ErrorMessage = "El campo Precio es obligatorio")]
        public decimal precioServicio { get; set; }
    }
}
