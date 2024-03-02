using Microsoft.EntityFrameworkCore;
using ShpinxCommercial.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// get connection string from the appsettings.json
var connection = builder.Configuration.GetConnectionString("con");
// set the DBContext options and pass the connection string 
builder.Services.AddDbContext<ShpinxCommercialDbContext>(options => options.UseSqlServer(connection));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
