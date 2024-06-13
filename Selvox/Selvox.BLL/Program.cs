using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Selvox.BLL.Repositories;
using Selvox.BLL.Repositories.Interfaces;
using Selvox.BLL.Services;
using Selvox.DAL.Context;

namespace Selvox.BLL;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddDbContext<SelvoxDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<IAssessmentRepository, AssessmentRepository>();
        builder.Services.AddScoped<AssessmentService>();
        builder.Services.AddMemoryCache();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<SelvoxDbContext>();
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                    };
                });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}