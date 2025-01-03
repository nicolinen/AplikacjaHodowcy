global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
global using System.ComponentModel;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AplikacjaHodowcy.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AplikacjaHodowcy.Repositories;
using AplikacjaHodowcy.Interfaces;
using AplikacjaHodowcy.KonkursyFactory.Interfaces;
using AplikacjaHodowcy.KonkursyFactory;
using AplikacjaHodowcy.Mappers;
using AplikacjaHodowcy.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<ILiniaRepository, LiniaRepository>();
builder.Services.AddScoped<IMiotRepository, MiotRepository>();
builder.Services.AddScoped<ISzczeniakRepository, SzczeniakRepository>();
builder.Services.AddScoped<IKonkursFactory, KonkursFactory>();
builder.Services.AddTransient<LiniaMapper>();
builder.Services.AddTransient<MiotMapper>();
builder.Services.AddScoped<ILiniaService, LiniaService>();
builder.Services.AddScoped<IMiotService, MiotService>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{ 
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
