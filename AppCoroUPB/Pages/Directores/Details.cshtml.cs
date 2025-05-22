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
    public class DetailsModel : PageModel
    {
        private readonly AppCoroUPB.Services.ApplicationDbContext _context;

        public DetailsModel(AppCoroUPB.Services.ApplicationDbContext context)
        {
            _context = context;
        }

        public Director Director { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.Directores.FirstOrDefaultAsync(m => m.idDic == id);
            if (director == null)
            {
                return NotFound();
            }
            else
            {
                Director = director;
            }
            return Page();
        }
    }
}
