using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Selvox.DAL.Models;

namespace Selvox.DAL.Context;

public partial class SelvoxDbContext : DbContext
{
    public SelvoxDbContext()
    {
    }

    public SelvoxDbContext(DbContextOptions<SelvoxDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Assessment> Assessments { get; set; }

    public virtual DbSet<Employer> Employers { get; set; }

    public virtual DbSet<EmployerJob> EmployerJobs { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Interview> Interviews { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserJob> UserJobs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Selvox;TrustServerCertificate=True;Integrated Security=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasKey(e => e.AssessmentID).HasName("PK__Assessme__3D2BF83EDD395C13");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.Assessments).HasConstraintName("FK__Assessmen__UserI__4F7CD00D");
        });

        modelBuilder.Entity<Employer>(entity =>
        {
            entity.HasKey(e => e.EmployerID).HasName("PK__Employer__CA4452416FE5BAB2");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<EmployerJob>(entity =>
        {
            entity.HasKey(e => new { e.EmployerID, e.JobID }).HasName("PK__Employer__FA123B4F2F580BEF");

            entity.Property(e => e.PostedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Employer).WithMany(p => p.EmployerJobs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployerJ__Emplo__619B8048");

            entity.HasOne(d => d.Job).WithMany(p => p.EmployerJobs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EmployerJ__JobID__628FA481");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackID).HasName("PK__Feedback__6A4BEDF69F79EECD");

            entity.Property(e => e.GivenAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Interview).WithMany(p => p.Feedbacks).HasConstraintName("FK__Feedback__Interv__6E01572D");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks).HasConstraintName("FK__Feedback__UserID__6D0D32F4");
        });

        modelBuilder.Entity<Interview>(entity =>
        {
            entity.HasKey(e => e.InterviewID).HasName("PK__Intervie__C97C58328AE4F436");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Employer).WithMany(p => p.Interviews).HasConstraintName("FK__Interview__Emplo__68487DD7");

            entity.HasOne(d => d.Job).WithMany(p => p.Interviews).HasConstraintName("FK__Interview__JobID__6754599E");

            entity.HasOne(d => d.User).WithMany(p => p.Interviews).HasConstraintName("FK__Interview__UserI__66603565");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobID).HasName("PK__Jobs__056690E23E164422");

            entity.Property(e => e.PostedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.PostedByUser).WithMany(p => p.Jobs).HasConstraintName("FK__Jobs__PostedByUs__5441852A");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationID).HasName("PK__Notifica__20CF2E32F2F60978");

            entity.Property(e => e.ReadStatus).HasDefaultValueSql("((0))");
            entity.Property(e => e.SentAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications).HasConstraintName("FK__Notificat__UserI__72C60C4A");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserID).HasName("PK__Users__1788CCAC6DC70BC8");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<UserJob>(entity =>
        {
            entity.HasKey(e => new { e.UserID, e.JobID }).HasName("PK__UserJobs__27DEA5A2C8F78AB2");

            entity.Property(e => e.AppliedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Job).WithMany(p => p.UserJobs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserJobs__JobID__59063A47");

            entity.HasOne(d => d.User).WithMany(p => p.UserJobs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserJobs__UserID__5812160E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
