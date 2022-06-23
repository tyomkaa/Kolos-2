using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public partial class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {

        }

        public MainDbContext()
        {

        }

        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Membership> Memberships { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(e => new { e.FileID, e.TeamID });
                entity.ToTable("File");
                entity.Property(e => e.FileName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.FileExtension).IsRequired().HasMaxLength(4);
                entity.Property(e => e.FileSize).IsRequired();
                entity.HasOne(e => e.Team).WithMany(p => p.Files).HasForeignKey(e => e.TeamID);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.HasKey(e => new { e.MemberID, e.OrganizationID });
                entity.ToTable("Member");
                entity.Property(e => e.MemberName).IsRequired().HasMaxLength(20);
                entity.Property(e => e.MemberSurname).IsRequired().HasMaxLength(50);
                entity.Property(e => e.MemberNickName).IsRequired().HasMaxLength(20);
                entity.HasOne(e => e.Organization).WithMany(e => e.Members).HasForeignKey(e => e.OrganizationID).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Member_Organization");
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.HasKey(e => new { e.MemberID, e.TeamID });
                entity.ToTable("Membership");
                entity.Property(e => e.MembershipDate).IsRequired().HasColumnType("datetime");
                entity.HasOne(e => e.Member).WithMany(e => e.Memberships).HasForeignKey(e => e.MemberID).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Membership_Member");
                entity.HasOne(e => e.Team).WithMany(e => e.Memberships).HasForeignKey(e => e.TeamID).OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Membership_Team");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.OrganizationID);
                entity.ToTable("Organization");
                entity.Property(e => e.OrganizationID).ValueGeneratedNever();
                entity.Property(e => e.OrganizationName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.OrganizationDomain).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => new { e.TeamID, e.OrganizationID });
                entity.ToTable("Team");
                entity.Property(e => e.TeamName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.TeamDescription).IsRequired().HasMaxLength(500);
                entity.HasOne(e => e.Organization).WithMany(e => e.Teams).HasForeignKey(e => e.OrganizationID);
            });

           // OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
