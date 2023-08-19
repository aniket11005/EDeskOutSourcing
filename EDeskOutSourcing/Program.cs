

using EDeskOutSourcing.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
var config = builder.Configuration;
builder.Services.AddDbContextPool<CompanyContext>(opt => opt.UseLazyLoadingProxies().UseSqlServer(config.GetConnectionString("scon")));
builder.Services.AddSession();
var app = builder.Build();

app.UseSession();
app.UseStaticFiles();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );


app.MapDefaultControllerRoute();

app.Run();
