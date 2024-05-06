using Agri_Energy_Connect.DataContext;
using Agri_Energy_Connect.Models;

namespace Agri_Energy_Connect.Services;

public class FarmerService
{
    static void Register(Farmer farmer)
    {
        try
        {
            DatabaseContext context = new DatabaseContext();
            context.Farmers?.Add(farmer);
            context.SaveChanges();
        }
        catch (Exception exception)
        {
            throw;
        }
    }

    static Farmer FarmerById(string id)
    {
        try
        {
            DatabaseContext context = new DatabaseContext();
            Farmer farmer = context.Farmers?.Find(id)!;
            return farmer;
        }
        catch (Exception exception)
        {
            throw;
        }
    }
}
