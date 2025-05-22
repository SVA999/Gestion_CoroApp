using System.ComponentModel.DataAnnotations;

namespace AppCoroUPB.Models
{
    public class CompositorCancion
    {
        [Key]
        public int idComp { get; set; }
        public string Compositor { get; set; } = "";
    }
}
