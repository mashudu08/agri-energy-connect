using Agri_Energy_Connect.DataContext;
using Agri_Energy_Connect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agri_Energy_Connect.Pages
{
    public class EmployeeModel : PageModel
    {
        private readonly DatabaseContext _context;

        public EmployeeModel(DatabaseContext context)
        {
            _context = context;
        }

        // [BindProperty]
        // public Employee employee { get; set; }
        //
        // public void OnGet(Guid id)
        // {
        //     Employee employee = _context.Employees?.Find(id)!;
        // }

        // public IActionResult onPost()
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return Page();
        //     }
        //
        //     _context.Employees?.Add(employee);
        //     _context.SaveChanges();
        //     return Page();
        // }

    }
}
