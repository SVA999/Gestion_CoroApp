using System.ComponentModel.DataAnnotations;

namespace AppCoroUPB.Models
{
    public class EstadoInt
    {
        [Key]
        public int idEst{ get; set; }
        public string Estado { get; set; } = "";
    }
}
