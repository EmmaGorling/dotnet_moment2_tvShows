var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // Activate MVC

var app = builder.Build();

app.UseStaticFiles();   // Enable static files
app.UseRouting();       // Enable routing

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();
