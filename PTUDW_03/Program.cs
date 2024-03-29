using Microsoft.EntityFrameworkCore;
using PTUDW_03.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HarmicContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

#region thay thanh
//scaffold-DbContext "data source=DESKTOP-IV0MTE3\SQLEXPRESS;initial catalog=Harmic;integrated security=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models
//scaffold-DbContext "data source=DESKTOP-IV0MTE3\SQLEXPRESS;initial catalog=Harmic;integrated security=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models -force
#endregion