using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppCoroUPB.Models;
using AppCoroUPB.Services;

namespace AppCoroUPB.Pages.Directores
{
    public class IndexModel : PageModel
    {
        private readonly AppCoroUPB.Services.ApplicationDbContext _context;

        public IndexModel(AppCoroUPB.Services.ApplicationDbContext context)
        {
            _context = context;
        }

        public Dictionary<int, string> Estado { get; set; } = new Dictionary<int, string>();

        public IList<Director> Director { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Director = await _context.Directores.ToListAsync();

            var estado = await _context.Estados.ToListAsync();
            Estado = estado.ToDictionary(c => c.idEst, c => c.Estado);

        }

        public string GetEstado(int id) => Estado.ContainsKey(id) ? Estado[id] : "Desconocido";
    }
}
