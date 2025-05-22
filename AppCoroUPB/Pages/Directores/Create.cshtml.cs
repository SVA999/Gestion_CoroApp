using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppCoroUPB.Models;
using AppCoroUPB.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AppCoroUPB.Pages.Directores
{
    public class CreateModel : PageModel
    {
        private readonly AppCoroUPB.Services.ApplicationDbContext _context;

        public CreateModel(AppCoroUPB.Services.ApplicationDbContext context)
        {
            _context = context;
        }

        public SelectList sl_Estado { get; set; }

        public async Task OnGetAsync()
        {
            var Estado = await _context.Estados.ToListAsync();
            sl_Estado = new SelectList(Estado, "idEst", "Estado");

            Director = new Director
            {
                FechaInicio = DateOnly.FromDateTime(DateTime.Now.Date),
                idEstado = 1
            };

        }

        [BindProperty]
        public Director Director { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _context.Directores.Add(Director);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");

            }
            catch (DbUpdateException ex)
            {
                // Captura excepciones específicas de Entity Framework Core
                ModelState.AddModelError(string.Empty, "Por favor, inténtalo de nuevo. Puede que este valor ya exista");
                //updateSuccess = "Soy DbUpdateException";

                await PopulateListAsync();
                return Page();


            }
            catch (SqlException sqlEx)
            {
                // Captura excepciones específicas de SQL Server
                ModelState.AddModelError(string.Empty, "Ocurrió un error de base de datos. Contacte al administrador si el problema persiste." + sqlEx);
                //updateSuccess = "Soy SqlException";
                await PopulateListAsync();
                return Page();
            }
            catch (Exception ex)
            {
                // Captura cualquier otra excepción inesperada
                ModelState.AddModelError(string.Empty, "Ocurrió un error inesperado. Por favor, inténtalo de nuevo." + ex);
                //updateSuccess = "Soy Exception";
                await PopulateListAsync();
                return Page();
            }
        }

        private async Task PopulateListAsync()
        {
            var Estado = await _context.Estados.ToListAsync();
            sl_Estado = new SelectList(Estado, "idEst", "Estado");
        }
    }
}
