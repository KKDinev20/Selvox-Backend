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

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<CareerRecommendation> CareerRecommendations { get; set; }

    public virtual DbSet<Employer> Employers { get; set; }

    public virtual DbSet<Industry> Industries { get; set; }

    public virtual DbSet<JobListing> JobListings { get; set; }

    public virtual DbSet<JobRole> JobRoles { get; set; }

    public virtual DbSet<PersonalityAssessment> PersonalityAssessments { get; set; }

    public virtual DbSet<PersonalityQuestion> PersonalityQuestions { get; set; }
    public virtual DbSet<PersonalityTestQuestion> PersonalityTestQuestions { get; set; }
    public virtual DbSet<PersonalityTestAnswer> PersonalityTestAnswers { get; set; }

    public virtual DbSet<QuestionJobFieldMapping> QuestionJobFieldMappings { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserSkill> UserSkills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Selvox;TrustServerCertificate=True;Integrated Security=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK__Applicat__C93A4C99156A28E6");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.JobListing).WithMany(p => p.Applications).HasConstraintName("FK__Applicati__JobLi__74AE54BC");

            entity.HasOne(d => d.User).WithMany(p => p.Applications).HasConstraintName("FK__Applicati__UserI__75A278F5");
        });

        modelBuilder.Entity<CareerRecommendation>(entity =>
        {
            entity.HasKey(e => e.RecommendationId).HasName("PK__CareerRe__AA15BEE4FD34D332");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.JobRole).WithMany(p => p.CareerRecommendations).HasConstraintName("FK__CareerRec__JobRo__5AEE82B9");

            entity.HasOne(d => d.User).WithMany(p => p.CareerRecommendations).HasConstraintName("FK__CareerRec__UserI__59FA5E80");
        });

        modelBuilder.Entity<Employer>(entity =>
        {
            entity.HasKey(e => e.EmployerId).HasName("PK__Employer__CA44526164042D7C");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.Industry).WithMany(p => p.Employers).HasConstraintName("FK__Employers__Indus__6A30C649");
        });

        modelBuilder.Entity<Industry>(entity =>
        {
            entity.HasKey(e => e.IndustryId).HasName("PK__Industri__808DEDCCA4CD957D");
        });

        modelBuilder.Entity<JobListing>(entity =>
        {
            entity.HasKey(e => e.JobListingId).HasName("PK__JobListi__70B705E0FDA186BF");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.Employer).WithMany(p => p.JobListings).HasConstraintName("FK__JobListin__Emplo__6EF57B66");

            entity.HasOne(d => d.JobRole).WithMany(p => p.JobListings).HasConstraintName("FK__JobListin__JobRo__6FE99F9F");
        });

        modelBuilder.Entity<JobRole>(entity =>
        {
            entity.HasKey(e => e.JobRoleId).HasName("PK__JobRoles__6D8BAC2FBB2A94CD");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
        });

        modelBuilder.Entity<PersonalityAssessment>(entity =>
        {
            entity.HasKey(e => e.AssessmentId).HasName("PK__Personal__3D2BF81E1EA2F518");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.User).WithMany(p => p.PersonalityAssessments).HasConstraintName("FK__Personali__UserI__4F7CD00D");
        });

        modelBuilder.Entity<PersonalityQuestion>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Personal__0DC06FAC021B80BC");
        });

        modelBuilder.Entity<QuestionJobFieldMapping>(entity =>
        {
            entity.HasKey(e => e.MappingId).HasName("PK__Question__8B57819D8122EF1C");

            entity.HasOne(d => d.JobField).WithMany(p => p.QuestionJobFieldMappings).HasConstraintName("FK__QuestionJ__JobFi__18EBB532");

            entity.HasOne(d => d.Question).WithMany(p => p.QuestionJobFieldMappings).HasConstraintName("FK__QuestionJ__Quest__17F790F9");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK__Skills__DFA09187EDFFCABB");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CE72D638B");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.Gender).IsFixedLength();
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
        });

        modelBuilder.Entity<UserSkill>(entity =>
        {
            entity.HasKey(e => e.UserSkillId).HasName("PK__UserSkil__2F28BE569EC8242B");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.Skill).WithMany(p => p.UserSkills).HasConstraintName("FK__UserSkill__Skill__6383C8BA");

            entity.HasOne(d => d.User).WithMany(p => p.UserSkills).HasConstraintName("FK__UserSkill__UserI__628FA481");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
