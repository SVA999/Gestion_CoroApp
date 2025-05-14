using AppCoroUPB.Models;
using AppCoroUPB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppCoroUPB.Pages.Ensayos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;


        public List<Ensayo> l_ensayos = new();
		public Dictionary<int, string> NombreLugaresEnsayo { get; set; } = new Dictionary<int, string>();


		public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }


		public async Task OnGetAsync()
		{
			l_ensayos = await context.Ensayos.OrderByDescending(i => i.Fecha).ToListAsync();
			var lugares = await context.LugaresEnsayo.ToListAsync();
			NombreLugaresEnsayo = lugares.ToDictionary(l => l.idLugEns, l => l.Lugar);
		}

		public string GetNombreLugarEnsayo(int idLugEns)
		{
			if (NombreLugaresEnsayo.ContainsKey(idLugEns))
			{
				return NombreLugaresEnsayo[idLugEns];
			}
			return "Desconocido"; // O algún otro valor por defecto
		}

	}
}
