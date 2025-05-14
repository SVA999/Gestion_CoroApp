using System.ComponentModel.DataAnnotations;

namespace AppCoroUPB.Models
{
	public class EnsayosDto
	{
		[Required]
		public DateOnly Fecha { get; set; }
		[Required]
		public TimeOnly Hora { get; set; }
		[Range(1,99999)]
		public int IdLugEns { get; set; }

	}
}
