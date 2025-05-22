using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppCoroUPB.Models;
using AppCoroUPB.Services;

namespace AppCoroUPB.Pages.Canciones
{
    public class DetailsModel : PageModel
    {
        private readonly AppCoroUPB.Services.ApplicationDbContext _context;

        public DetailsModel(AppCoroUPB.Services.ApplicationDbContext context)
        {
            _context = context;
        }

        public Cancion Cancion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cancion = await _context.Canciones.FirstOrDefaultAsync(m => m.idCanc == id);
            if (cancion == null)
            {
                return NotFound();
            }
            else
            {
                Cancion = cancion;
            }
            return Page();
        }
    }
}
