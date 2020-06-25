using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace finalPro.Models
{
    public partial class finalProDBContext : DbContext
    {
        public finalProDBContext()
        {
        }

        public finalProDBContext(DbContextOptions<finalProDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Citizen> Citizen { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<OrgBranches> OrgBranches { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Requist> Requist { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=finalProDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NationalId)
                    .IsRequired()
                    .HasColumnName("nationalID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Citizen>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NReq).HasColumnName("nReq");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NationalId)
                    .IsRequired()
                    .HasColumnName("nationalID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("image");
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.DateTime });

                entity.ToTable("logs");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.DateTime)
                    .HasColumnName("dateTime")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_logs_User");
            });

            modelBuilder.Entity<OrgBranches>(entity =>
            {
                entity.ToTable("Org_branches");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Long)
                    .HasColumnName("long")
                    .HasColumnType("decimal(18, 5)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.OrgId).HasColumnName("orgID");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.OrgBranches)
                    .HasForeignKey(d => d.OrgId)
                    .HasConstraintName("FK_Org_branches_Organization");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Requist>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CitId).HasColumnName("citID");

                entity.Property(e => e.DateTime)
                    .IsRequired()
                    .HasColumnName("dateTime")
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Long)
                    .HasColumnName("long")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrgId).HasColumnName("orgID");

                entity.Property(e => e.Photo)
                    .HasColumnName("photo")
                    .HasColumnType("image");

                entity.Property(e => e.Response).HasColumnName("response");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Cit)
                    .WithMany(p => p.Requist)
                    .HasForeignKey(d => d.CitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Requist_Citizen");

                entity.HasOne(d => d.Org)
                    .WithMany(p => p.Requist)
                    .HasForeignKey(d => d.OrgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Requist_Organization");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Requist)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Requist_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BranchId).HasColumnName("branchID");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NReq).HasColumnName("nReq");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NationalId)
                    .IsRequired()
                    .HasColumnName("nationalID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Org_branches1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
