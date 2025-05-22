using System.ComponentModel.DataAnnotations;

namespace AppCoroUPB.Models
{
    public class Idioma
    {
        [Key]
        public int idIdioma { get; set; }
        public string idioma { get; set; } = "";
    }
}
