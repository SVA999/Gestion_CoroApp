using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppCoroUPB.Models;
using AppCoroUPB.Services;

namespace AppCoroUPB.Pages.Canciones
{
    public class EditModel : PageModel
    {
        private readonly AppCoroUPB.Services.ApplicationDbContext _context;

        public EditModel(AppCoroUPB.Services.ApplicationDbContext context)
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

            var cancion =  await _context.Canciones.FirstOrDefaultAsync(m => m.idCanc == id);
            if (cancion == null)
            {
                return NotFound();
            }
            Cancion = cancion;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cancion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CancionExists(Cancion.idCanc))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CancionExists(int id)
        {
            return _context.Canciones.Any(e => e.idCanc == id);
        }
    }
}
