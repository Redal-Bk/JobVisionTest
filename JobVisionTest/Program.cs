using JobVisionTest.Domain.Entities;
using JobVisionTest.Infrastructure;
using JobVisionTest.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JobVisionTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);




            builder.Services.AddDbContext<JobVisionTestContext>(options =>
                     options.UseSqlServer(builder.Configuration.GetConnectionString("JobVisionTest")));


            builder.Services.AddScoped<IUserConfig, UserConfig>();
            
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

           
            app.UseStaticFiles();

            
            app.UseRouting();

            
            app.MapControllerRoute(
                name: "Account",
                pattern: "{controller=Account}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}
