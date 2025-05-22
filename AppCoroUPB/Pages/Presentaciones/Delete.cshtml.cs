using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppCoroUPB.Models;
using AppCoroUPB.Services;

namespace AppCoroUPB.Pages.Presentaciones
{
    public class DeleteModel : PageModel
    {
        private readonly AppCoroUPB.Services.ApplicationDbContext _context;

        public DeleteModel(AppCoroUPB.Services.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Presentacion Presentacion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentacion = await _context.Presentaciones.FirstOrDefaultAsync(m => m.idPresent == id);

            if (presentacion == null)
            {
                return NotFound();
            }
            else
            {
                Presentacion = presentacion;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presentacion = await _context.Presentaciones.FindAsync(id);
            if (presentacion != null)
            {
                Presentacion = presentacion;
                _context.Presentaciones.Remove(Presentacion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
