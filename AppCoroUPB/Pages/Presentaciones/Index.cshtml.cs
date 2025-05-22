using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppCoroUPB.Models;
using AppCoroUPB.Services;

namespace AppCoroUPB.Pages.Presentaciones
{
    public class IndexModel : PageModel
    {
        private readonly AppCoroUPB.Services.ApplicationDbContext _context;

        public IndexModel(AppCoroUPB.Services.ApplicationDbContext context)
        {
            _context = context;
        }

        // Diccionarios para almacenar los nombres basados en los IDs
        public Dictionary<int, string> LugarPresentacion { get; set; } = new Dictionary<int, string>();
        public Dictionary<int, string> TipoEvento { get; set; } = new Dictionary<int, string>();


        public IList<Presentacion> Presentacion { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Presentacion = await _context.Presentaciones.ToListAsync();

            var lugar = await _context.LugaresPresentaciones.ToListAsync();
            LugarPresentacion = lugar.ToDictionary(c => c.idLugPresent, c => c.Lugar);

            var evento = await _context.TipoEvento.ToListAsync();
            TipoEvento = evento.ToDictionary(c => c.idEvent, c => c.Evento);

        }

        // Métodos para obtener los nombres en la vista
        public string GetLugarPresentacion(int id) => LugarPresentacion.ContainsKey(id) ? LugarPresentacion[id] : "Desconocido";
        public string GetTipoEvento(int id) => TipoEvento.ContainsKey(id) ? TipoEvento[id] : "Desconocido";
        


    }
}
