using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppCoroUPB.Models;
using AppCoroUPB.Services;

namespace AppCoroUPB.Pages.Integrantes
{
    public class DetailsModel : PageModel
    {
        private readonly AppCoroUPB.Services.ApplicationDbContext _context;

        public DetailsModel(AppCoroUPB.Services.ApplicationDbContext context)
        {
            _context = context;
        }

        public Integrante Integrante { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var integrante = await _context.Integrantes.FirstOrDefaultAsync(m => m.idInt == id);
            if (integrante == null)
            {
                return NotFound();
            }
            else
            {
                Integrante = integrante;
            }
            return Page();
        }
    }
}
