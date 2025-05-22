using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppCoroUPB.Models;
using AppCoroUPB.Services;

namespace AppCoroUPB.Pages.Canciones
{
    public class IndexModel : PageModel
    {
        private readonly AppCoroUPB.Services.ApplicationDbContext _context;

        public IndexModel(AppCoroUPB.Services.ApplicationDbContext context)
        {
            _context = context;
        }


        // Diccionarios para almacenar los nombres basados en los IDs
        public Dictionary<int, string> Compositor { get; set; } = new Dictionary<int, string>();
        public Dictionary<int, string> Idioma { get; set; } = new Dictionary<int, string>();
        public Dictionary<int, string> Clasificacion { get; set; } = new Dictionary<int, string>();

        public IList<Cancion> Cancion { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Cancion = await _context.Canciones.ToListAsync();

            var compositor = await _context.CompositorCanciones.ToListAsync();
            Compositor = compositor.ToDictionary(c => c.idComp, c => c.Compositor);

            var idioma = await _context.Idiomas.ToListAsync();
            Idioma = idioma.ToDictionary(c => c.idIdioma, c => c.idioma);

            var clasificacion = await _context.ClasificacionCancion.ToListAsync();
            Clasificacion = clasificacion.ToDictionary(c => c.idClasif, c => c.Clasificacion);

        }

        // Métodos para obtener los nombres en la vista
        public string GetCompositor(int id) => Compositor.ContainsKey(id) ? Compositor[id] : "Desconocido";
        public string GetIdioma(int id) => Idioma.ContainsKey(id) ? Idioma[id] : "Desconocido";

        public string GetClasificacion(int id) => Clasificacion.ContainsKey(id) ? Clasificacion[id] : "Desconocido";
    }
}
