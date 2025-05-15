using AppCoroUPB.Models;
using AppCoroUPB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AppCoroUPB.Pages.Ensayos
{
    public class CreateModel : PageModel
    {
		private readonly ApplicationDbContext context;

		public CreateModel(ApplicationDbContext context)
        {
			this.context = context;
		}

		//Lista de seleccion de lugares
		public SelectList sl_LugaresEnsayo { get; set; }


		[BindProperty]
        public EnsayosDto EnsayosDto { get; set; }= new();

		public async Task OnGetAsync()
		{
            await PopulateLugaresEnsayosSelectListAsync();

            // Cargar la lista de lugares de ensayo desde la base de datos
            var LugaresEnsayo = await context.LugaresEnsayo.ToListAsync();

			// Crear un SelectList para el control dropdown en la vista
			sl_LugaresEnsayo = new SelectList(LugaresEnsayo, "idLugEns", "Lugar");

			// Inicializar Fecha y Hora con valores predeterminados
			EnsayosDto = new EnsayosDto
			{
				IdLugEns = 1,
				Fecha = DateOnly.FromDateTime(DateTime.Now.Date), // Fecha actual
				Hora = TimeOnly.FromDateTime(DateTime.Now) // Hora actual
			};
		}

        public string updateSuccess = "";

        public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				// Si hay errores de validaci�n, recarga la lista de lugares de ensayo
				var LugaresEnsayo = await context.LugaresEnsayo.ToListAsync();
				sl_LugaresEnsayo = new SelectList(LugaresEnsayo, "Id", "Nombre");
                await PopulateLugaresEnsayosSelectListAsync();
                return Page();
			}

			try
			{
				// Crear una nueva instancia de Ensayo a partir del DTO
				var nuevoEnsayo = new Ensayo
				{
					Fecha = EnsayosDto.Fecha,
					Hora = EnsayosDto.Hora,
					IdLugEns = EnsayosDto.IdLugEns // Este valor vendr� del select list
				};

                context.Ensayos.Add(nuevoEnsayo);
				await context.SaveChangesAsync();

				return RedirectToPage("./Index");

			}
			catch (DbUpdateException ex)
			{
                if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2601) // 2601 es el c�digo de error para violaci�n de UNIQUE KEY en SQL Server
                {
                    // Manejar la violaci�n de clave �nica (CK_FechaHoralgual)
                    //_logger.LogWarning(sqlEx, "Intento de insertar un ensayo duplicado.");
                    ModelState.AddModelError(string.Empty, "Ya existe un ensayo programado para la misma fecha y hora.");

                    updateSuccess = "Ya existe este ensayo en esta misma fecha y hora";

                }
                else
                {
                    // Captura excepciones espec�ficas de Entity Framework Core
                    ModelState.AddModelError(string.Empty, "Ocurri� un error al guardar el ensayo en la base de datos. Por favor, int�ntalo de nuevo." + ex);

                    updateSuccess = "Ya existe este ensayo en esta misma fecha y hora";
                }

                await PopulateLugaresEnsayosSelectListAsync();
                return Page();


            }
			catch (SqlException sqlEx)
			{
				// Captura excepciones espec�ficas de SQL Server
				ModelState.AddModelError(string.Empty, "Ocurri� un error de base de datos. Contacte al administrador si el problema persiste."+ sqlEx);
                updateSuccess = "Ocurri� un error de base de datos. Contacte al administrador si el problema persiste.";
                await PopulateLugaresEnsayosSelectListAsync();
				return Page();
			}
			catch (Exception ex)
			{
				// Captura cualquier otra excepci�n inesperada
				ModelState.AddModelError(string.Empty, "Ocurri� un error inesperado. Por favor, int�ntalo de nuevo."+ ex);
                updateSuccess = "Ocurri� un error inesperado. Por favor, int�ntalo de nuevo";
                await PopulateLugaresEnsayosSelectListAsync();
				return Page();
			}
		}

		private async Task PopulateLugaresEnsayosSelectListAsync()
		{
			var lugaresEnsayos = await context.LugaresEnsayo.ToListAsync();
			sl_LugaresEnsayo = new SelectList(lugaresEnsayos, "idLugEns", "Lugar");
		}

	}
	
}

