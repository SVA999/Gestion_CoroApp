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
    public class IndexModel : PageModel
    {
        private readonly AppCoroUPB.Services.ApplicationDbContext context;

        public IndexModel(AppCoroUPB.Services.ApplicationDbContext context)
        {
            this.context = context;
        }

        // Diccionarios para almacenar los nombres basados en los IDs
        public Dictionary<int, string> NombreVinculos { get; set; } = new Dictionary<int, string>();
        public Dictionary<int, string> NombreCarreras { get; set; } = new Dictionary<int, string>();
        public Dictionary<int, string> NombreVoces { get; set; } = new Dictionary<int, string>();
        public Dictionary<int, string> NombreEstados { get; set; } = new Dictionary<int, string>();


        public List<Integrante> Integrante { get;set; }

        public async Task OnGetAsync()
        {
			Integrante = await context.Integrantes.OrderByDescending(i => i.NombreCompleto).ToListAsync();

            // Cargar y mapear los nombres de Vinculos
            var vinculos = await context.TipoVinculo.ToListAsync();
            NombreVinculos = vinculos.ToDictionary(v => v.idVinculo, v => v.Vinculo);

            // Cargar y mapear los nombres de Carreras
            var carreras = await context.Carrera_Dependencia.ToListAsync();
            NombreCarreras = carreras.ToDictionary(c => c.idCarrera, c => c.Carrera);

            // Cargar y mapear los nombres de Voces
            var voces = await context.ClasificacionVoz.ToListAsync();
            NombreVoces = voces.ToDictionary(v => v.idVoz, v => v.Voz);

            // Cargar y mapear los nombres de Estados
            var estados = await context.Estados.ToListAsync();
            NombreEstados = estados.ToDictionary(e => e.idEst, e => e.Estado);
        }

        // Métodos para obtener los nombres en la vista
        public string GetNombreVinculo(int id) => NombreVinculos.ContainsKey(id) ? NombreVinculos[id] : "Desconocido";
        public string GetNombreCarrera(int id) => NombreCarreras.ContainsKey(id) ? NombreCarreras[id] : "Desconocido";
        public string GetNombreVoz(int id) => NombreVoces.ContainsKey(id) ? NombreVoces[id] : "Desconocido";
        public string GetNombreEstado(int id) => NombreEstados.ContainsKey(id) ? NombreEstados[id] : "Desconocido";

    }
}
