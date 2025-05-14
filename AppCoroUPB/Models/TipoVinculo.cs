using System.ComponentModel.DataAnnotations;

namespace AppCoroUPB.Models
{
    public class TipoVinculo
    {
        [Key]
        public int idVinculo { get; set; }
        public string Vinculo { get; set; } = "";

    }
}
