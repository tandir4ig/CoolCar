using CoolCar.Db.Services.Interfaces;
using CoolCar.Db.Services;
using CoolCar.Services.Interfaces;
using CoolCar.Services;
using CoolCar.Db;
using Microsoft.EntityFrameworkCore;
using CoolCar.Db.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAppCoolCar.Services.Interfaces;
using WebAppCoolCar.Services; //body

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<ICardsStorage, CardsDbRepository>();
builder.Services.AddTransient<ICarsStorage, CarsDbRepository>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<IdentityContext>(options => options.UseNpgsql(connection));
builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "JWT Token Authentication API",
        Description = "ASP.NET Core 5.0 Web API"
    });
    // To Enable authorization using Swagger (JWT)
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
});
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["Jwt:Issuer"],
        ValidAudience = configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"])) //Configuration["JwtToken:SecretKey"]
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    IdentityInitializer.Initialize(userManager, rolesManager);
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();