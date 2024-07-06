using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models
{
    public class CategoriaModel
    {
        public int idCategoriaProducto { get; set; }

        [Required(ErrorMessage = "El campo Categoría es obligatorio")]
        public string? categoriaProducto { get; set; }
    }
}

