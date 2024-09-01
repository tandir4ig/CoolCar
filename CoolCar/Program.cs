using CoolCar.Db;
using CoolCar.Services;
using CoolCar.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace CoolCar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
			

			// Add services to the container.
			builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<ICardsStorage, CardsDatabase>();
            builder.Services.AddTransient<ICarsStorage, CarsDbRepository>();
            builder.Services.AddSingleton<IConstants, Constants>();
            builder.Services.AddSingleton<IOrdersInterface, OrderService>();
            builder.Services.AddSingleton<ILikedInterface, LikedService>();
            builder.Services.AddSingleton<ICompareInterface, CompareServise>();
            builder.Services.AddSingleton<IRoleInterface, RoleService>();
            builder.Services.AddSingleton<IUserInterface, UserService>();

            builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connection));


            //builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration).Enrich.WithProperty("ApplicationName","Online Shop"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseSerilogRequestLogging();    
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            app.MapControllerRoute(
                name: "MyArea",
                pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
