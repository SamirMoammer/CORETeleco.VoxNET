using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models
{
    public class RolModel
    {
        public int idRol { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? nombreRol { get; set; }
    }
}
