using Agri_Energy_Connect.DataContext;
using Agri_Energy_Connect.Models;
using Agri_Energy_Connect.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseContext")));
builder.Services.AddSession();
builder.Services.AddScoped<LoginService>();

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    .AddEntityFrameworkStores<DatabaseContext>()
//    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    // Other configuration...
}

//async Task SeedRoles(RoleManager<IdentityRole> roleManager)
//{
//    if (!await roleManager.RoleExistsAsync("Farmer"))
//    {
//        var role = new IdentityRole("Farmer");
//        await roleManager.CreateAsync(role);
//    }

//    if (!await roleManager.RoleExistsAsync("Employee"))
//    {

//        var role = new IdentityRole("Employee");
//        await roleManager.CreateAsync(role);
//    }
//}


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DatabaseContext>();
    context.Database.EnsureCreated();
    context.Database.Migrate();
    // DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
