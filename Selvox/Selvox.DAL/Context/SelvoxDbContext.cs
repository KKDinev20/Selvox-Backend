using Microsoft.EntityFrameworkCore;
using Selvox.DAL.Models;

namespace Selvox.DAL.Context;

public class SelvoxDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Assessment> Assessments { get; set; }
    public DbSet<CareerRecommendation> CareerRecommendations { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Interest> Interests { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.\\SQLEXPRESS;Database=selvox;TrustServerCertificate=True;Integrated Security=true;");
    }
}