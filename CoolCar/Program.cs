using CoolCar.Services;
using CoolCar.Services.Interfaces;
using Serilog;

namespace CoolCar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<ICardsStorage, CardsDatabase>();
            builder.Services.AddSingleton<ICarsStorage, CarsStorageService>();
            builder.Services.AddSingleton<IConstants, Constants>();
            builder.Services.AddSingleton<IOrdersInterface, OrderService>();
            builder.Services.AddSingleton<ILikedInterface, LikedService>();
            builder.Services.AddSingleton<ICompareInterface, CompareServise>();
            builder.Services.AddSingleton<IRoleInterface, RoleService>();

            builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration).Enrich.WithProperty("ApplicationName","Online Shop"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSerilogRequestLogging();    
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Authorization}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "MyArea",
                pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
