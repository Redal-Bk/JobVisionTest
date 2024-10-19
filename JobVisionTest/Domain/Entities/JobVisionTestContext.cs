using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JobVisionTest.Domain.Entities;

public partial class JobVisionTestContext : DbContext
{
    public JobVisionTestContext()
    {
    }

    public JobVisionTestContext(DbContextOptions<JobVisionTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDeatali> UserDeatalis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-AU43CNB;Database=JobVisionTest;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0719777C07");

            entity.Property(e => e.Family).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.ProfileImageUrl).HasMaxLength(200);
        });

        modelBuilder.Entity<UserDeatali>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserDeat__3214EC070D02663F");

            entity.Property(e => e.Gender).HasMaxLength(5);

            entity.HasOne(d => d.User).WithMany(p => p.UserDeatalis)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserDeata__UserI__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
