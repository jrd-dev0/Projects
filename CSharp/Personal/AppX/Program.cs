using AppX.Data;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;

namespace AppX
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionStrings = builder.Configuration.GetConnectionString("AppXContext");
            builder.Services.AddDbContext<AppXContext>(x => x.UseMySql(connectionStrings, ServerVersion.AutoDetect(connectionStrings)));

            var app = builder.Build();

            SeedingService.SeedData(app);

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
        }
    }
}