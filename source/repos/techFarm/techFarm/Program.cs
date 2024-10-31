using System;
using techFarm.Data;
using Microsoft.EntityFrameworkCore;
using techFarm.Interfaces;
using techFarm.Services;
using System.Globalization;
using DinkToPdf.Contracts;
using DinkToPdf;


var builder = WebApplication.CreateBuilder(args);

var cultureInfo = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

builder.Services.AddDbContext<TechFarmContext>(options => options.UseSqlite("Data source=database.db"));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRelatorioDeVendasService, RelatorioDeVendasService>();
builder.Services.AddScoped<IRazorViewRendererService, RazorViewRendererService>();
builder.Services.AddScoped<IServicesArquivoPDF, ServicesArquivoPDF>();
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));

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

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
