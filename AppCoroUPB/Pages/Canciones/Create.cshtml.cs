using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppCoroUPB.Models;
using AppCoroUPB.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace AppCoroUPB.Pages.Canciones
{
    public class CreateModel : PageModel
    {
        private readonly AppCoroUPB.Services.ApplicationDbContext _context;

        public CreateModel(AppCoroUPB.Services.ApplicationDbContext context)
        {
            _context = context;
        }

        public SelectList sl_Compositor { get; set; }
        public SelectList sl_Idioma{ get; set; }

        public SelectList sl_Clasificacion{ get; set; }


        public async Task OnGetAsync()
        {

            await PopulateListAsync();

            var compositor = await _context.CompositorCanciones.OrderBy(i => i.Compositor).ToListAsync();
            sl_Compositor = new SelectList(compositor, "idComp", "Compositor");

            var idioma = await _context.Idiomas.OrderBy(i => i.idioma).ToListAsync();
            sl_Idioma = new SelectList(idioma, "idIdioma", "idioma");

            var clasificacion = await _context.ClasificacionCancion.OrderBy(i => i.Clasificacion).ToListAsync();
            sl_Clasificacion = new SelectList(clasificacion, "idClasif", "Clasificacion");


        }

        [BindProperty]
        public Cancion Cancion { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _context.Canciones.Add(Cancion);
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
            var compositor = await _context.CompositorCanciones.OrderBy(i => i.Compositor).ToListAsync();
            sl_Compositor = new SelectList(compositor, "idComp", "Compositor");

            var idioma = await _context.Idiomas.OrderBy(i => i.idioma).ToListAsync();
            sl_Idioma = new SelectList(idioma, "idIdioma", "idioma");

            var clasificacion = await _context.ClasificacionCancion.OrderBy(i => i.Clasificacion).ToListAsync();
            sl_Clasificacion = new SelectList(clasificacion, "idClasif", "Clasificacion");
        }



    }
}
