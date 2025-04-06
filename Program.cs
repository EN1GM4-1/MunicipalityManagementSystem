using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;



var builder = WebApplication.CreateBuilder(args);



// Retrieve the connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");

// Register Entity Framework Core with Oracle database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(connectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseRouting();
app.UseAuthorization();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    
});

app.Urls.Add("https://localhost:7125");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Top-level route registrations
app.MapControllers();
app.MapDefaultControllerRoute(); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
