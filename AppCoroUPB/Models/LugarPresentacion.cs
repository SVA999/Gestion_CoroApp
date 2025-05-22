using System.ComponentModel.DataAnnotations;

namespace AppCoroUPB.Models
{
    public class LugarPresentacion
    {
        [Key]
        public int idLugPresent { get; set; }
        public string Lugar { get; set; } = "";
    }
}
