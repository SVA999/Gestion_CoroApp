using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace AppCoroUPB.Models
{
    public class Cancion
    {
        [Key]
        public int idCanc { get; set; }
        public string Titulo { get; set; } = "";
        public int idComp { get; set; }
        public int idIdioma { get; set; }
        public int Duracion { get; set; }
        public int idClasif { get; set; }


    }
}
