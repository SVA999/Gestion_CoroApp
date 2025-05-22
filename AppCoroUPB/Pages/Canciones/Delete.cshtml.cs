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
    public class DeleteModel : PageModel
    {
        private readonly AppCoroUPB.Services.ApplicationDbContext _context;

        public DeleteModel(AppCoroUPB.Services.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cancion = await _context.Canciones.FindAsync(id);
            if (cancion != null)
            {
                Cancion = cancion;
                _context.Canciones.Remove(Cancion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
