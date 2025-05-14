using AppCoroUPB.Models;
using AppCoroUPB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AppCoroUPB.Pages.Ensayos
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public EnsayosDto EnsayosDto { get; set; } = new EnsayosDto();

        public Ensayo Ensayo { get; set; } = new();

        //Lista de seleccion de lugares
        public SelectList sl_LugaresEnsayo { get; set; }


        private readonly ApplicationDbContext context;

        public EditModel(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task OnGetAsync(int id)
        {
            // Cargar la lista de lugares de ensayo desde la base de datos
            var lugaresEnsayo = await context.LugaresEnsayo.ToListAsync();

            // Crear un SelectList para el control dropdown en la vista
            sl_LugaresEnsayo = new SelectList(lugaresEnsayo, "idLugEns", "Lugar");

            var ensayo = context.Ensayos.Find(id);
            if (ensayo == null)
            {
               RedirectToPage("/Ensayos/Index");
            }

            Ensayo = ensayo;

            EnsayosDto.Fecha = ensayo.Fecha;
            EnsayosDto.Hora = ensayo.Hora;
            EnsayosDto.IdLugEns = ensayo.IdLugEns;

            // Inicializar Fecha y Hora con valores predeterminados
            EnsayosDto = new EnsayosDto
            {
                IdLugEns = Ensayo.IdLugEns
            };

        }

        public string updateSuccess = "";
        
        public IActionResult OnPost(int id)
        {
            var ensayo = context.Ensayos.Find(id);
            if (ensayo == null)
            {
                return RedirectToPage("/Ensayos/Index");
            }

            Ensayo = ensayo;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            ensayo.IdLugEns = EnsayosDto.IdLugEns;

            updateSuccess = "Ensayo actualizado Exitosamente";

            context.SaveChanges();
            return Page();
        }
    }
}
