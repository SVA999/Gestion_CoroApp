using System.ComponentModel.DataAnnotations;

namespace AppCoroUPB.Models
{
    public class Director
    {
        [Key]
        public int idDic { get; set; }
        public string NombreCompleto { get; set; } = "";
        public DateOnly FechaInicio { get; set; }
        public int idEstado { get; set; }
    }
}
