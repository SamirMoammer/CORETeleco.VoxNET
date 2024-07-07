using System.ComponentModel.DataAnnotations;

namespace CORETeleco.Models

{
    public class ContratoModel
    {
        public int idContrato { get; set; }
        public DateTime fechaInicioContrato { get; set; }
        public DateTime fechaFinContrato { get; set; }
        public string? descripcionContrato { get; set; }
        public bool estadoContrato { get; set; }
        public int idCliente { get; set; }
        public int idServicio { get; set; }

        public List<ClienteModel> Cliente { get; set; } = new List<ClienteModel>();
        public List<ServicioModel> Servicio { get; set; } = new List<ServicioModel>();
    }
}
