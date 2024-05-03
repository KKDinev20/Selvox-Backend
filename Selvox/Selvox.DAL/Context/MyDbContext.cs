using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Selvox.DAL.Models;

namespace Selvox.DAL.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<User_Education> User_Educations { get; set; }

    public virtual DbSet<User_Experience> User_Experiences { get; set; }

    public virtual DbSet<Users_Skill> Users_Skills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(";");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Applicat__3214EC07D074E350");

            entity.HasOne(d => d.Job).WithMany(p => p.Applications).HasConstraintName("FK__Applicati__JobID__2A4B4B5E");

            entity.HasOne(d => d.User).WithMany(p => p.Applications).HasConstraintName("FK__Applicati__UserI__2B3F6F97");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Educatio__3214EC07B84FB98E");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Experien__3214EC0725CB7060");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Jobs__3214EC0773BF0BA4");

            entity.HasOne(d => d.Employer).WithMany(p => p.Jobs).HasConstraintName("FK__Jobs__EmployerID__276EDEB3");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reviews__3214EC076D3A510B");

            entity.HasOne(d => d.Job).WithMany(p => p.Reviews).HasConstraintName("FK__Reviews__JobID__2F10007B");

            entity.HasOne(d => d.Reviewer).WithMany(p => p.Reviews).HasConstraintName("FK__Reviews__Reviewe__2E1BDC42");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skills__3214EC075E1C5D2E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC073BA085AA");
        });

        modelBuilder.Entity<User_Education>(entity =>
        {
            entity.HasOne(d => d.Education).WithMany().HasConstraintName("FK__User_Educ__Educa__3D5E1FD2");

            entity.HasOne(d => d.User).WithMany().HasConstraintName("FK__User_Educ__UserI__3C69FB99");
        });

        modelBuilder.Entity<User_Experience>(entity =>
        {
            entity.HasOne(d => d.Experience).WithMany().HasConstraintName("FK__User_Expe__Exper__38996AB5");

            entity.HasOne(d => d.User).WithMany().HasConstraintName("FK__User_Expe__UserI__37A5467C");
        });

        modelBuilder.Entity<Users_Skill>(entity =>
        {
            entity.HasOne(d => d.Skill).WithMany().HasConstraintName("FK__Users_Ski__Skill__33D4B598");

            entity.HasOne(d => d.User).WithMany().HasConstraintName("FK__Users_Ski__UserI__32E0915F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
