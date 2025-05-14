using System.ComponentModel.DataAnnotations;

namespace AppCoroUPB.Models
{
    public class Carrera_Dependencia
    {
        [Key]
        public int idCarrera { get; set; }
        public string Carrera { get; set; } = "";
    }
}
