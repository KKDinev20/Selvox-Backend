using Microsoft.EntityFrameworkCore;
using Selvox.BLL.Interfaces;
using Selvox.BLL.Repositories;
using Selvox.DAL.Context;

namespace Selvox.BLL;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        // Configure CORS policy
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalhost",
                policyBuilder => policyBuilder.WithOrigins("http://localhost:3000")
                                              .AllowAnyHeader()
                                              .AllowAnyMethod()
                                              .AllowCredentials());
        });

        builder.Services.AddDbContext<SelvoxDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IJobListingService, JobListingService>();
        builder.Services.AddScoped<IPersonalityAssessmentRepository, PersonalityAssessmentRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors("AllowLocalhost");
        app.UseSession();
        app.UseAuthorization();
        
        // Use custom role-based middleware
        app.UseRoleMiddleware();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}
