﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Latin1_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.File", b =>
                {
                    b.Property<int>("FileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FileID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TeamID")
                        .HasColumnType("int")
                        .HasColumnName("TeamID");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasMaxLength(4)
                        .IsUnicode(false)
                        .HasColumnType("varchar(4)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("FileSize")
                        .HasColumnType("int");

                    b.Property<int?>("MemberID")
                        .HasColumnType("int");

                    b.HasKey("FileID", "TeamID")
                        .HasName("File_pk");

                    b.HasIndex("MemberID");

                    b.HasIndex("TeamID");

                    b.ToTable("File");
                });

            modelBuilder.Entity("WebApplication1.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MemberID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("MemberNickName")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("MemberSurname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int")
                        .HasColumnName("OrganizationID");

                    b.HasKey("MemberID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("WebApplication1.Models.Membership", b =>
                {
                    b.Property<int>("MemberID")
                        .HasColumnType("int")
                        .HasColumnName("MemberID");

                    b.Property<int>("TeamID")
                        .HasColumnType("int")
                        .HasColumnName("TeamID");

                    b.Property<DateTime>("MembershipDate")
                        .HasColumnType("datetime");

                    b.HasKey("MemberID", "TeamID")
                        .HasName("Membership_pk");

                    b.HasIndex("TeamID");

                    b.ToTable("Membership");
                });

            modelBuilder.Entity("WebApplication1.Models.Organization", b =>
                {
                    b.Property<int>("OrganizationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrganizationID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrganizationDomain")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("OrganizationID");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("WebApplication1.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TeamID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int")
                        .HasColumnName("OrganizationID");

                    b.Property<string>("TeamDescription")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("TeamID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("WebApplication1.Models.File", b =>
                {
                    b.HasOne("WebApplication1.Models.Member", null)
                        .WithMany("Files")
                        .HasForeignKey("MemberID");

                    b.HasOne("WebApplication1.Models.Team", "Team")
                        .WithMany("Files")
                        .HasForeignKey("TeamID")
                        .HasConstraintName("File_Team")
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("WebApplication1.Models.Member", b =>
                {
                    b.HasOne("WebApplication1.Models.Organization", "Organization")
                        .WithMany("Members")
                        .HasForeignKey("OrganizationID")
                        .HasConstraintName("Member_Organization")
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("WebApplication1.Models.Membership", b =>
                {
                    b.HasOne("WebApplication1.Models.Member", "Member")
                        .WithMany("Memberships")
                        .HasForeignKey("MemberID")
                        .HasConstraintName("Membership_Member")
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Team", "Team")
                        .WithMany("Memberships")
                        .HasForeignKey("TeamID")
                        .HasConstraintName("Membership_Team")
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("WebApplication1.Models.Team", b =>
                {
                    b.HasOne("WebApplication1.Models.Organization", "Organization")
                        .WithMany("Teams")
                        .HasForeignKey("OrganizationID")
                        .HasConstraintName("Team_Organization")
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("WebApplication1.Models.Member", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("Memberships");
                });

            modelBuilder.Entity("WebApplication1.Models.Organization", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("WebApplication1.Models.Team", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}