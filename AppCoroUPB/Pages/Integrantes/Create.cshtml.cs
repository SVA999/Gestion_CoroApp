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

namespace AppCoroUPB.Pages.Integrantes
{
    public class CreateModel : PageModel
    {
        private readonly AppCoroUPB.Services.ApplicationDbContext context;

        public CreateModel(AppCoroUPB.Services.ApplicationDbContext context)
        {
            this.context = context;
        }

        //Lista de seleccion de Vinculo 
        public SelectList sl_Vinculo { get; set; }
        //Lista de seleccion de Carreras
        public SelectList sl_Carrera { get; set; }
        //Lista de seleccion de Voz
        public SelectList sl_Voz { get; set; }
        //Lista de seleccion de Estado
        public SelectList sl_Estado { get; set; }

        public async Task OnGetAsync()
        {
            var tipoVinculo = await context.TipoVinculo.OrderBy(i => i.Vinculo).ToListAsync();
            sl_Vinculo = new SelectList(tipoVinculo, "idVinculo", "Vinculo");

            var Carrera = await context.Carrera_Dependencia.OrderBy(i => i.Carrera).ToListAsync();
            sl_Carrera = new SelectList(Carrera, "idCarrera", "Carrera");

            var Voz = await context.ClasificacionVoz.ToListAsync();
            sl_Voz = new SelectList(Voz, "idVoz", "Voz");

            var Estado = await context.Estados.ToListAsync();
            sl_Estado = new SelectList(Estado, "idEst", "Estado");


            IntegranteDto = new IntegranteDto
            {
                FechaIngreso = DateOnly.FromDateTime(DateTime.Now.Date),
                IdEstado = 1
            };
        }

        [BindProperty]
        public IntegranteDto IntegranteDto { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Crear una nueva instancia a partir del DTO
            var nuevoIntegrante = new Integrante
            {
                idInt = IntegranteDto.idInt,
                NombreCompleto = IntegranteDto.NombreCompleto,
                idVinculo = IntegranteDto.idVinculo,
                idCarrera = IntegranteDto.idCarrera,
                FechaIngreso = IntegranteDto.FechaIngreso,
                IdVoz = IntegranteDto.IdVoz,
                IdEstado = 1
            };

            context.Integrantes.Add(nuevoIntegrante);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
