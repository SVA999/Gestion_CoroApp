using System.ComponentModel.DataAnnotations;

namespace AppCoroUPB.Models
{
    public class ClasificacionCancion
    {
        [Key]
        public int idClasif { get; set; }
        public string Clasificacion { get; set; } = "";
    }
}
