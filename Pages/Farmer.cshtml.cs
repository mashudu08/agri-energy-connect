using Agri_Energy_Connect.DataContext;
using Agri_Energy_Connect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agri_Energy_Connect.Pages
{
    public class FarmerModel : PageModel
    {
        private readonly DatabaseContext _context;

        public FarmerModel(DatabaseContext context)
        {
            _context = context;
        }

        public Farmer farmer { get; set; }

        public void OnGet(Guid id)
        {
            Farmer farmer = _context.Farmers?.Find(id)!;
        }

        public IActionResult onPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Farmers?.Add(farmer);
            _context.SaveChanges();
            return Page();
        }
    }
}
