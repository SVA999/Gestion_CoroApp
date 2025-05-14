using System.ComponentModel.DataAnnotations;

namespace AppCoroUPB.Models
{
    public class ClasificacionVoz
    {
        [Key]
        public int idVoz { get; set; }
        public string Voz { get; set; } = "";
    }
}
