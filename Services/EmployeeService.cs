using Agri_Energy_Connect.DataContext;
using Agri_Energy_Connect.Models;

namespace Agri_Energy_Connect.Services;

public static class EmployeeService
{
    static void Register(Employee employee)
    {
        try
        {
            DatabaseContext context = new DatabaseContext();
            context.Employees?.Add(employee);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw;
        }

        static Employee EmployeeById(string id)
        {
            try
            {
                DatabaseContext context = new DatabaseContext();
                Employee employee = context.Employees?.Find(id)!;
                return employee;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
