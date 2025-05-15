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

        public string updateSuccess = "";
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await PopulateListAsync();

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
            catch (DbUpdateException ex)
            {
                // Captura excepciones específicas de Entity Framework Core
                ModelState.AddModelError(string.Empty, "Por favor, inténtalo de nuevo. Puede que este valor ya exista" );
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
            var tipoVinculo = await context.TipoVinculo.OrderBy(i => i.Vinculo).ToListAsync();
            sl_Vinculo = new SelectList(tipoVinculo, "idVinculo", "Vinculo");

            var Carrera = await context.Carrera_Dependencia.OrderBy(i => i.Carrera).ToListAsync();
            sl_Carrera = new SelectList(Carrera, "idCarrera", "Carrera");

            var Voz = await context.ClasificacionVoz.ToListAsync();
            sl_Voz = new SelectList(Voz, "idVoz", "Voz");

            var Estado = await context.Estados.ToListAsync();
            sl_Estado = new SelectList(Estado, "idEst", "Estado");
        }
    }
}
