using Agri_Energy_Connect.DataContext;
using Agri_Energy_Connect.Models;

using Agri_Energy_Connect.DataContext;
using Agri_Energy_Connect.Models;
namespace Agri_Energy_Connect.Services;

public class LoginService
{
    // using dependecy inject to prevent db connection leaks
    private readonly DatabaseContext _context;

    public LoginService(DatabaseContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));;
    }

    public User Login(string email, string password)
    {
        return _context.Users?.FirstOrDefault(user => user.Email == email && user.Password == password)!;

    }
}


