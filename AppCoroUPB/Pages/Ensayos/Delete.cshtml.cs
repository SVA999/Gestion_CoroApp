using AppCoroUPB.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppCoroUPB.Pages.Ensayos
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public DeleteModel(ApplicationDbContext context)
        {
            this.context = context;
        }


        public IActionResult OnGet(int id)
        {
            var ensayo = context.Ensayos.Find(id);
            if (ensayo != null)
            {
                context.Ensayos.Remove(ensayo);
                context.SaveChanges();
                
            }

            return RedirectToPage("/Ensayos/Index");
        }
    }
}
