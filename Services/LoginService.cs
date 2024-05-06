using Agri_Energy_Connect.DataContext;
using Agri_Energy_Connect.Models;

namespace Agri_Energy_Connect.Services;

public class LoginService
{
    // using dependecy inject to prevent db connection leaks
    private readonly DatabaseContext _context;

    public LoginService(DatabaseContext context)
    {
        _context = context;
    }

    public List<Farmer> GetAllFarmers()
    {
        //DatabaseContext context = new DatabaseContext();
        //List<Farmer> farmers = new List<Farmer> { context.Farmers.Find() };
        return _context.Farmers.ToList();
    }

    public Farmer LoginFarmer(string email, string password)
    {
       // DatabaseContext context = new DatabaseContext();
       //Farmer farmer = context.Farmers?.FirstOrDefault(farmer => farmer.email == email && farmer.password == password)!;
        return _context.Farmers?.FirstOrDefault(farmer => farmer.Email == email && farmer.Password == password)!;
    }

    public Employee LoginEmployee(string email, string password)
    {
       // DatabaseContext context = new DatabaseContext();
        //Employee employee = context.Employees?.FirstOrDefault(employee => employee.Email == email && employee.Password == password)!;
        return _context.Employees?.FirstOrDefault(employee => employee.Email == email && employee.Password == password)!;
    }
}

