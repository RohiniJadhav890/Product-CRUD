using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AssingmentApp.Data;
using AssingmentApp.Models;
using Microsoft.CodeAnalysis.Options;
using AssingmentApp.DAL;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AssingmentAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AssingmentAppContext") ?? throw new InvalidOperationException("Connection string 'AssingmentAppContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDBConntext>(Option =>
  Option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
   // app.UseStatusCodePagesWithRedirects("");
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
