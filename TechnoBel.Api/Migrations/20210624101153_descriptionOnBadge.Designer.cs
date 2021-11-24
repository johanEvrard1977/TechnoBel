﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechnoBel.Dal.DbContexts;

namespace TechnoBel.Api.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210624101153_descriptionOnBadge")]
    partial class descriptionOnBadge
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TechnoBel.Dal.Models.Badge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<DateTime?>("Updatedate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.CategorieDeProjet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<DateTime?>("Updatedate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CategorieDeProjets");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Filiere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Annee")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<DateTime?>("Updatedate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Filieres");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.FiliereTechonologie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FiliereId")
                        .HasColumnType("int");

                    b.Property<int>("TechnologieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FiliereId");

                    b.HasIndex("TechnologieId");

                    b.ToTable("FiliereTechonologies");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Hobbies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<DateTime?>("Updatedate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Hobby");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Hobby_Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HobbyId")
                        .HasColumnType("int");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HobbyId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Hobby_Profile");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("File")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Langue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<DateTime?>("Updatedate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Langues");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<int>("StatutId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updatedate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatutId");

                    b.HasIndex("UserId");

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Projet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Resume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updatedate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Projets");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.ProjetImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ImageId")
                        .HasColumnType("int");

                    b.Property<int>("ProjetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("ProjetId");

                    b.ToTable("ProjetImages");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Projet_Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategorieId")
                        .HasColumnType("int");

                    b.Property<int>("ProjetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.HasIndex("ProjetId");

                    b.ToTable("Projet_Categories");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<DateTime?>("Updatedate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Role");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Statut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<DateTime?>("Updatedate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Statut");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Technologie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<DateTime?>("Updatedate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Technologie");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updatedate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.UserBadge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BadgeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BadgeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBadges");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.UserFiliere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FiliereId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FiliereId");

                    b.HasIndex("UserId");

                    b.ToTable("UserFilieres");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.UserProjet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProjetId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjetId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProjets");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.UserTechnologie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TechnologieId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TechnologieId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTechnologies");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.FiliereTechonologie", b =>
                {
                    b.HasOne("TechnoBel.Dal.Models.Filiere", "Filiere")
                        .WithMany("FiliereTechonologies")
                        .HasForeignKey("FiliereId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnoBel.Dal.Models.Technologie", "Technologie")
                        .WithMany("FiliereTechonologies")
                        .HasForeignKey("TechnologieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filiere");

                    b.Navigation("Technologie");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Hobby_Profile", b =>
                {
                    b.HasOne("TechnoBel.Dal.Models.Hobbies", "Hobbies")
                        .WithMany("Hobby_Profiles")
                        .HasForeignKey("HobbyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnoBel.Dal.Models.Profile", "Profile")
                        .WithMany("Hobby_Profiles")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hobbies");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Profile", b =>
                {
                    b.HasOne("TechnoBel.Dal.Models.Statut", "Statut")
                        .WithMany("Profiles")
                        .HasForeignKey("StatutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnoBel.Dal.Models.User", "User")
                        .WithMany("Profiles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Statut");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.ProjetImage", b =>
                {
                    b.HasOne("TechnoBel.Dal.Models.Image", "Image")
                        .WithMany("ProjetImages")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnoBel.Dal.Models.Projet", "Projet")
                        .WithMany("ProjetImages")
                        .HasForeignKey("ProjetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Projet");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Projet_Categorie", b =>
                {
                    b.HasOne("TechnoBel.Dal.Models.CategorieDeProjet", "Categorie")
                        .WithMany("Projet_categories")
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnoBel.Dal.Models.Projet", "Projet")
                        .WithMany("Projet_categories")
                        .HasForeignKey("ProjetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Projet");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.UserBadge", b =>
                {
                    b.HasOne("TechnoBel.Dal.Models.Badge", "Badge")
                        .WithMany("UserBadges")
                        .HasForeignKey("BadgeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnoBel.Dal.Models.User", "User")
                        .WithMany("UserBadges")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Badge");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.UserFiliere", b =>
                {
                    b.HasOne("TechnoBel.Dal.Models.Filiere", "Filiere")
                        .WithMany("UserFiliere")
                        .HasForeignKey("FiliereId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnoBel.Dal.Models.User", "User")
                        .WithMany("UserFiliere")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Filiere");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.UserProjet", b =>
                {
                    b.HasOne("TechnoBel.Dal.Models.Projet", "Projet")
                        .WithMany("UserProjet")
                        .HasForeignKey("ProjetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnoBel.Dal.Models.User", "User")
                        .WithMany("UserProjet")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projet");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.UserRole", b =>
                {
                    b.HasOne("TechnoBel.Dal.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnoBel.Dal.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.UserTechnologie", b =>
                {
                    b.HasOne("TechnoBel.Dal.Models.Technologie", "Technologie")
                        .WithMany("UserTechnologies")
                        .HasForeignKey("TechnologieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechnoBel.Dal.Models.User", "User")
                        .WithMany("UserTechnologies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Technologie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Badge", b =>
                {
                    b.Navigation("UserBadges");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.CategorieDeProjet", b =>
                {
                    b.Navigation("Projet_categories");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Filiere", b =>
                {
                    b.Navigation("FiliereTechonologies");

                    b.Navigation("UserFiliere");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Hobbies", b =>
                {
                    b.Navigation("Hobby_Profiles");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Image", b =>
                {
                    b.Navigation("ProjetImages");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Profile", b =>
                {
                    b.Navigation("Hobby_Profiles");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Projet", b =>
                {
                    b.Navigation("Projet_categories");

                    b.Navigation("ProjetImages");

                    b.Navigation("UserProjet");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Statut", b =>
                {
                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.Technologie", b =>
                {
                    b.Navigation("FiliereTechonologies");

                    b.Navigation("UserTechnologies");
                });

            modelBuilder.Entity("TechnoBel.Dal.Models.User", b =>
                {
                    b.Navigation("Profiles");

                    b.Navigation("UserBadges");

                    b.Navigation("UserFiliere");

                    b.Navigation("UserProjet");

                    b.Navigation("UserRoles");

                    b.Navigation("UserTechnologies");
                });
#pragma warning restore 612, 618
        }
    }
}
