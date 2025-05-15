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
    public class DeleteModel : PageModel
    {
        private readonly AppCoroUPB.Services.ApplicationDbContext context;

        public DeleteModel(AppCoroUPB.Services.ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult OnGet(int id)
        {
            var integrante = context.Integrantes.Find(id); 
            if (integrante != null)
            {
                context.Integrantes.Remove(integrante);
                context.SaveChanges();

            }

            return RedirectToPage("/Integrantes/Index");
        }
    }
}
