using System.ComponentModel.DataAnnotations;

namespace AppCoroUPB.Models
{
    public class Presentacion
    {
        [Key]
        public int idPresent { get; set; }
        public DateOnly Fecha { get; set; }
        public int idLugPresent { get; set; }
        public int idEvent { get; set; }
        
    }
}
