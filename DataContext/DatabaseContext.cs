using Agri_Energy_Connect.Models;
using Microsoft.EntityFrameworkCore;

namespace Agri_Energy_Connect.DataContext;

public class DatabaseContext : DbContext
{
    public DbSet<Farmer>? Farmers { get; set; }
    public DbSet<Employee>? Employees { get; set; }
}
