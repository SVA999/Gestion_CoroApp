using System.ComponentModel.DataAnnotations;

namespace AppCoroUPB.Models
{
	public class LugarEnsayo
	{
		[Key]
		public int idLugEns { get; set; }
		public string Lugar { get; set; } = "";

	}
}
