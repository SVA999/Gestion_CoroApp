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

namespace AppCoroUPB.Pages.Presentaciones
{
    public class EditModel : PageModel
    {
        private readonly AppCoroUPB.Services.ApplicationDbContext _context;

        public EditModel(AppCoroUPB.Services.ApplicationDbContext context)
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

            var presentacion =  await _context.Presentaciones.FirstOrDefaultAsync(m => m.idPresent == id);
            if (presentacion == null)
            {
                return NotFound();
            }
            Presentacion = presentacion;
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

            _context.Attach(Presentacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PresentacionExists(Presentacion.idPresent))
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

        private bool PresentacionExists(int id)
        {
            return _context.Presentaciones.Any(e => e.idPresent == id);
        }
    }
}
