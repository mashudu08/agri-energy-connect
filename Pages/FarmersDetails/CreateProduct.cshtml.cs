using Agri_Energy_Connect.DataContext;
using Agri_Energy_Connect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agri_Energy_Connect.Pages.Farmers
{
    public class CreateModel : PageModel
    {
        private readonly DatabaseContext _context;

        public CreateModel(DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
