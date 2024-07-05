using System;
using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models
{
    public class RolModel
    {
        public int IdRol { get; set; }

        [Required]
        public string nombreRol { get; set; }
    }
}