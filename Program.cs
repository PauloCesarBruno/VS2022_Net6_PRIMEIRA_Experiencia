using Brinquedos_NET6.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//===============================================================================
// ATENCAO: (NO NET 6 A STRING ESTANDO NO AppSettingsJson), SER� ASSIM ABAIXO:
//===============================================================================
builder.Services.AddDbContext<DataContext>(x =>
{
   x.UseSqlServer(builder.Configuration.GetConnectionString("ConectDB"));
});

builder.Services.AddCors();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseBrowserLink();// Colocar Aqui se não estiver em desenvolvimento -> if (!app.Environment.IsDevelopment())
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());


app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Brinquedo}/{action=Index}/{id?}");

app.Run();
