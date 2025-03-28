using Microsoft.EntityFrameworkCore;
using PracticaMVC.Models;   
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//BUILDER VERIFICACION
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(3600);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//BUILDER DE LA CONEXION A LA BASE DE DATOS
builder.Services.AddDbContext<equiposDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("equiposDbConnection")));

builder.Services.AddDbContext<usuariosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("equiposDbConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();
var variableLocal = "nombreVariable";


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
