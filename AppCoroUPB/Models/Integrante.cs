using System.ComponentModel.DataAnnotations;

namespace AppCoroUPB.Models
{
	public class Integrante
	{
		[Key]
		public int idInt { get; set; }
		public string NombreCompleto { get; set; } = "";
		public int idVinculo { get; set; }
		public int idCarrera { get; set; }
		public DateOnly FechaIngreso { get; set; }
		public int IdVoz { get; set; }
		public int IdEstado { get; set; }

    }
}
