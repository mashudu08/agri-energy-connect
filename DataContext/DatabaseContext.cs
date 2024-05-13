using Agri_Energy_Connect.enums;
using Agri_Energy_Connect.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Agri_Energy_Connect.DataContext { 

public class DatabaseContext : DbContext
        //IdentityDbContext<ApplicationUser>
   {
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure enum mapping for Role property
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion(
                    v => v.ToString(),    // Convert enum to string for database storage
                    v => (Role)Enum.Parse(typeof(Role), v)); // Convert string from database to enum

            // Other entity configurations...

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
    public DbSet<Farmer>? Farmers { get; set; }
    public DbSet<Product>? Products { get; set; }
    
}
}