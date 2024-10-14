//using CoolCar.Db;
//using CoolCar.Db.Models;
//using CoolCar.Db.Services;
//using CoolCar.Db.Services.Interfaces;
//using CoolCar.Helpers;
//using CoolCar.Services;
//using CoolCar.Services.Interfaces;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using CoolCar.Helpers;
//using Microsoft.Extensions.FileProviders;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

//string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
//builder.Services.AddTransient<ICardsStorage, CardsDbRepository>();
//builder.Services.AddTransient<ICarsStorage, CarsDbRepository>();
//builder.Services.AddSingleton<IOrdersInterface, OrderService>();
//builder.Services.AddSingleton<ILikedInterface, LikedService>();
//builder.Services.AddSingleton<ICompareInterface, CompareServise>();
//builder.Services.AddSingleton<IRoleInterface, RoleService>();
//builder.Services.AddTransient<ImagesProvider>();

//builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//// добавляем контекст IndentityContext в качестве сервиса в приложение
//builder.Services.AddDbContext<IdentityContext>(options => options.UseNpgsql(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
