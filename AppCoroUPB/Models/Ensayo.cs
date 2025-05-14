using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCoroUPB.Models
{
    public class Ensayo
    {
        [Key]
		public int idEns { get; set; }
		public DateOnly Fecha { get; set; }
		public TimeOnly Hora { get; set; }
		public int IdLugEns { get; set; }

    }
}
