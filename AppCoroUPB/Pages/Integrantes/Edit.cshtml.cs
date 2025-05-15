using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppCoroUPB.Models;
using AppCoroUPB.Services;

namespace AppCoroUPB.Pages.Integrantes
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public IntegranteDto IntegranteDto { get; set; } = new IntegranteDto();

        public Integrante Integrante { get; set; } = new();

        private readonly AppCoroUPB.Services.ApplicationDbContext context;

        public EditModel(AppCoroUPB.Services.ApplicationDbContext context)
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

        

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var tipoVinculo = await context.TipoVinculo.OrderBy(i => i.Vinculo).ToListAsync();
            sl_Vinculo = new SelectList(tipoVinculo, "idVinculo", "Vinculo");

            var Carrera = await context.Carrera_Dependencia.OrderBy(i => i.Carrera).ToListAsync();
            sl_Carrera = new SelectList(Carrera, "idCarrera", "Carrera");

            var Voz = await context.ClasificacionVoz.ToListAsync();
            sl_Voz = new SelectList(Voz, "idVoz", "Voz");

            var Estado = await context.Estados.ToListAsync();
            sl_Estado = new SelectList(Estado, "idEst", "Estado");

            if (id == null)
            {
                return NotFound();
            }

            var integrante =  context.Integrantes.Find(id);
            if (integrante == null)
            {
                RedirectToPage("./Index");
            }

            Integrante = integrante;

            IntegranteDto.idInt = integrante.idInt;
            IntegranteDto.NombreCompleto = integrante.NombreCompleto;
            IntegranteDto.idCarrera = integrante.idCarrera;
            IntegranteDto.idVinculo = integrante.idVinculo;
            IntegranteDto.FechaIngreso = integrante.FechaIngreso;
            IntegranteDto.IdEstado = integrante.IdEstado;
            IntegranteDto.IdVoz = integrante.IdVoz;

            IntegranteDto = new IntegranteDto
            {
                idInt = Integrante.idInt,
                NombreCompleto = Integrante.NombreCompleto,
                idCarrera = Integrante.idCarrera,
                idVinculo = Integrante.idVinculo,
                FechaIngreso = Integrante.FechaIngreso,
                IdEstado = Integrante.IdEstado,
                IdVoz = Integrante.IdVoz = integrante.IdVoz
            };

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        public string updateSuccess = "";
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var tipoVinculo = await context.TipoVinculo.OrderBy(i => i.Vinculo).ToListAsync();
                sl_Vinculo = new SelectList(tipoVinculo, "idVinculo", "Vinculo");

                var Carrera = await context.Carrera_Dependencia.OrderBy(i => i.Carrera).ToListAsync();
                sl_Carrera = new SelectList(Carrera, "idCarrera", "Carrera");

                var Voz = await context.ClasificacionVoz.ToListAsync();
                sl_Voz = new SelectList(Voz, "idVoz", "Voz");

                var Estado = await context.Estados.ToListAsync();
                sl_Estado = new SelectList(Estado, "idEst", "Estado");

                return Page();
            }

            // Carga la entidad existente desde la base de datos usando la clave primaria del DTO
            var integranteToUpdate = await context.Integrantes.FindAsync(IntegranteDto.idInt);

            if (integranteToUpdate == null)
            {
                return NotFound();
            }

            // Actualiza las propiedades de la entidad cargada con los valores del DTO
            integranteToUpdate.NombreCompleto = IntegranteDto.NombreCompleto;
            integranteToUpdate.idCarrera = IntegranteDto.idCarrera;
            integranteToUpdate.idVinculo = IntegranteDto.idVinculo;
            integranteToUpdate.FechaIngreso = IntegranteDto.FechaIngreso;
            integranteToUpdate.IdEstado = IntegranteDto.IdEstado;
            integranteToUpdate.IdVoz = IntegranteDto.IdVoz;

            try
            {
                await context.SaveChangesAsync();
                updateSuccess = "Integrante actualizado exitosamente.";
                return RedirectToPage("./Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntegranteExists(Integrante.idInt))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool IntegranteExists(int id)
        {
            return context.Integrantes.Any(e => e.idInt == id);
        }
    }
}
