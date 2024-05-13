using Agri_Energy_Connect.DataContext;
using Agri_Energy_Connect.enums;
using Agri_Energy_Connect.Models;
using Agri_Energy_Connect.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Agri_Energy_Connect.Pages.Auth
{
    public class LoginModel : PageModel
    {
        
        // private readonly SignInManager<ApplicationUser> _signInManager;
        // private readonly UserManager<ApplicationUser> _userManager;
        //
        // public LoginModel(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        // {
        //     _signInManager = signInManager;
        //     _userManager = userManager;
        // }
        private readonly LoginService _loginService;

        public LoginModel(LoginService loginService)
        {
            _loginService = loginService;
        }
        [BindProperty] public string Email { get; set; }
        [BindProperty] public string Password { get; set; }
        public void OnGet()
        {

        }
        // public async Task<IActionResult> onPost()
        // {
        //     var result = await _signInManager.PasswordSignInAsync(Email, Password, false, lockoutOnFailure: false);
        //     if (result.Succeeded)
        //     {
        //         var user = await _userManager.FindByEmailAsync(Email);
        //         if (await _userManager.IsInRoleAsync(user, "Farmer"))
        //         {
        //             return RedirectToPage("/Index");
        //         }
        //         else if (await _userManager.IsInRoleAsync(user, "Employee"))
        //         {
        //             return RedirectToPage("/Index");
        //         }
        //     }
        //     ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        //     return Page();
        // }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // If model validation fails, return the same page with validation errors
                return Page();
            }

            // Process the form data (e.g., authentication)
            // DO Login call here
            // DataManager dm = new DataManager();
            // dm.openConnection();
            // User user = dm.LoginUser(Email, Password);

            // DbContextOptions<DatabaseContext> options = new DbContextOptionsBuilder<DatabaseContext>()
            //     .UseSqlServer(
            //         "Server=tcp:st10115884-sql-server.database.windows.net,1433;Initial Catalog=KhumaloCraft;Persist Security Info=False;User ID=st10115884;Password=Mashudu@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
            //     .Options;
            // DatabaseContext da = new DatabaseContext(options);
            // LoginService loginService = new LoginService(da);
            User user = _loginService.Login(Email, Password);

            // Store the user role in storage
            if (user != null)
            {
                var role = user.Role;
                HttpContext.Session.SetString("role", role.ToString());
                HttpContext.Session.SetInt32("isLoggedIn", 1);
                Response.Cookies.Append("IsLoggedIn", "true");
                // Redirect the user to another page
                if (role == Role.Employee)
                {
                    return RedirectToPage("/Index");
                }
                else
                {
                    return RedirectToPage("/Index");
                }
            }

            // Login failed, add an error message
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
}
