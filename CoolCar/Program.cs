using CoolCar.Db;
using CoolCar.Db.Models;
using CoolCar.Db.Services;
using CoolCar.Db.Services.Interfaces;
using CoolCar.Services;
using CoolCar.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
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
            builder.Services.AddTransient<ICardsStorage, CardsDbRepository>();
            builder.Services.AddTransient<ICarsStorage, CarsDbRepository>();
            builder.Services.AddSingleton<IOrdersInterface, OrderService>();
            builder.Services.AddSingleton<ILikedInterface, LikedService>();
            builder.Services.AddSingleton<ICompareInterface, CompareServise>();
            builder.Services.AddSingleton<IRoleInterface, RoleService>();
            builder.Services.AddSingleton<IUserInterface, UserService>();

            builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
            
            // добавляем контекст IndentityContext в качестве сервиса в приложение
            builder.Services.AddDbContext<IdentityContext>(options => options.UseNpgsql(connection));

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(8);
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.Cookie = new CookieBuilder
                {
                    IsEssential = true
                };
            });

            // указываем тип пользователя и роли
            builder.Services.AddIdentity<UserDb, IdentityRole>()
                            // устанавливаем тип хранилища - наш контекст
                            .AddEntityFrameworkStores<IdentityContext>();
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

            app.UseAuthentication(); 
            app.UseAuthorization();

            using (var serviceScope = app.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<UserDb>>();
                var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                IdentityInitializer.Initialize(userManager, rolesManager);
            }

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
