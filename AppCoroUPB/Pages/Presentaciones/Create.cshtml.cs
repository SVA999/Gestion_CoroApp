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

namespace AppCoroUPB.Pages.Presentaciones
{
    public class CreateModel : PageModel
    {
        private readonly AppCoroUPB.Services.ApplicationDbContext context;

        public CreateModel(AppCoroUPB.Services.ApplicationDbContext context)
        {
            this.context = context;
        }

        //Lista de seleccion de lugares
        public SelectList sl_LugarPresent { get; set; }
        //Lista de seleccion de eventos
        public SelectList sl_Eventos { get; set; }

        public async Task OnGetAsync()
		{
            await PopulateSelectListAsync();

            var LugaresPresent = await context.LugaresPresentaciones.OrderBy(i => i.Lugar).ToListAsync();
            sl_LugarPresent = new SelectList(LugaresPresent, "idLugPresent", "Lugar");

            var tipoEvento = await context.TipoEvento.OrderBy(i => i.Evento).ToListAsync();
            sl_Eventos = new SelectList(tipoEvento, "idEvent", "Evento");

            // Inicializar con valores predeterminados
            Presentacion = new Presentacion
            {
                Fecha= DateOnly.FromDateTime(DateTime.Now.Date),
                idLugPresent = 1,
                idEvent =1
			};
		}

        [BindProperty]
        public Presentacion Presentacion { get; set; } = default!;


        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                await PopulateSelectListAsync();

                if (!ModelState.IsValid)
                {
                    return Page();
                }

                context.Presentaciones.Add(Presentacion);
                await context.SaveChangesAsync();

                return RedirectToPage("./Index");

            }
            catch (DbUpdateException ex)
            {
                // Captura excepciones específicas de Entity Framework Core
                ModelState.AddModelError(string.Empty, "Por favor, inténtalo de nuevo. Puede que este valor ya exista");
                //updateSuccess = "Soy DbUpdateException";

                await PopulateSelectListAsync();
                return Page();


            }
            catch (SqlException sqlEx)
            {
                // Captura excepciones específicas de SQL Server
                ModelState.AddModelError(string.Empty, "Ocurrió un error de base de datos. Contacte al administrador si el problema persiste." + sqlEx);
                //updateSuccess = "Soy SqlException";
                await PopulateSelectListAsync();
                return Page();
            }
            catch (Exception ex)
            {
                // Captura cualquier otra excepción inesperada
                ModelState.AddModelError(string.Empty, "Ocurrió un error inesperado. Por favor, inténtalo de nuevo." + ex);
                //updateSuccess = "Soy Exception";
                await PopulateSelectListAsync();
                return Page();
            }
        }

        private async Task PopulateSelectListAsync()
        {
            var LugaresPresent = await context.LugaresPresentaciones.OrderBy(i => i.Lugar).ToListAsync();
            sl_LugarPresent = new SelectList(LugaresPresent, "idLugPresent", "Lugar");

            var tipoEvento = await context.TipoEvento.OrderBy(i => i.Evento).ToListAsync();
            sl_Eventos = new SelectList(tipoEvento, "idEvent", "Evento");
        }

    }
}
