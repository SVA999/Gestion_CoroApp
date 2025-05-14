using System.ComponentModel.DataAnnotations;

namespace AppCoroUPB.Models
{
    public class IntegranteDto
    {
        [Required]
        public int idInt { get; set; }
        [Required]
        public string NombreCompleto { get; set; } = "";
        [Required][Range(1, 4)]
        public int idVinculo { get; set; }
        [Required]
        public int idCarrera { get; set; }
        [Required]
        public DateOnly FechaIngreso { get; set; }
        [Required][Range(1, 6)]
        public int IdVoz { get; set; }
        [Required][Range(1, 2)]
        public int IdEstado { get; set; }

    }
}
