using System.ComponentModel.DataAnnotations;

namespace AppCoroUPB.Models
{
    public class TipoEvento
    {
        [Key]
        public int idEvent { get; set; }
        public string Evento { get; set; } = "";
    }
}
