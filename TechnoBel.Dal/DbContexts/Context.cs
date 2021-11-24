using Microsoft.EntityFrameworkCore;
using TechnoBel.Dal.Models;

namespace TechnoBel.Dal.DbContexts
{
    public class Context : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Hobbies> Hobby { get; set; }
        public DbSet<Hobby_Profile> Hobby_Profile { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Statut> Statut { get; set; }
        public DbSet<Technologie> Technologie { get; set; }
        public DbSet<UserTechnologie> UserTechnologies { get; set; }
        public DbSet<Langue> Langues { get; set; }
        public DbSet<Filiere> Filieres { get; set; }
        public DbSet<UserFiliere> UserFilieres { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<FiliereTechonologie> FiliereTechonologies { get; set; }
        public DbSet<CategorieDeProjet> CategorieDeProjets { get; set; }
        public DbSet<Projet> Projets { get; set; }
        public DbSet<Projet_Categorie> Projet_Categories { get; set; }
        public DbSet<UserProjet> UserProjets { get; set; }
        public DbSet<ProjetImage> ProjetImages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<UserBadge> UserBadges { get; set; }
        public DbSet<CurriculumVitae> CurriculumVitaes { get; set; }
        public DbSet<Filiere_Image> Filiere_Images { get; set; }
        public DbSet<Projet_Technologie> Projet_Technologies { get; set; }
        public DbSet<SoftSkills> SoftSkills { get; set; }
        public DbSet<UserSoftSkills> UserSoftSkills { get; set; }
        public DbSet<Profile_Image> User_Images { get; set; }
        public DbSet<ProfileTechnologie> ProfileTechnologies { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Profile_Image> profile_Images { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey("Id");
            builder.Entity<Profile>().HasKey("Id");
            builder.Entity<Hobbies>().HasKey("Id");
            builder.Entity<Hobby_Profile>().HasKey("Id");
            builder.Entity<Image>().HasKey("Id");
            builder.Entity<Statut>().HasKey("Id");
            builder.Entity<Technologie>().HasKey("Id");
            builder.Entity<UserTechnologie>().HasKey("Id");
            builder.Entity<Langue>().HasKey("Id");
            builder.Entity<Role>().HasKey("Id");
            builder.Entity<Filiere>().HasKey("Id");
            builder.Entity<UserFiliere>().HasKey("Id");
            builder.Entity<UserRole>().HasKey("Id");
            builder.Entity<FiliereTechonologie>().HasKey("Id");
            builder.Entity<CategorieDeProjet>().HasKey("Id");
            builder.Entity<Projet>().HasKey("Id");
            builder.Entity<Projet_Categorie>().HasKey("Id");
            builder.Entity<UserProjet>().HasKey("Id");
            builder.Entity<ProjetImage>().HasKey("Id");
            builder.Entity<Image>().HasKey("Id");
            builder.Entity<Badge>().HasKey("Id");
            builder.Entity<UserBadge>().HasKey("Id");
            builder.Entity<CurriculumVitae>().HasKey("Id");
            builder.Entity<Filiere_Image>().HasKey("Id");
            builder.Entity<Projet_Technologie>().HasKey("Id");
            builder.Entity<SoftSkills>().HasKey("Id");
            builder.Entity<UserSoftSkills>().HasKey("Id");
            builder.Entity<Profile_Image>().HasKey("Id");
            builder.Entity<ProfileTechnologie>().HasKey("Id");
            builder.Entity<Experience>().HasKey("Id");
            builder.Entity<Profile_Image>().HasKey("Id");

            builder.Entity<Technologie>(b =>
            {
                b.HasMany(e => e.UserTechnologies)
                    .WithOne(e => e.Technologie)
                    .HasForeignKey(ur => ur.TechnologieId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Technologie>(b =>
            {
                b.HasMany(e => e.ProfileTechnologies)
                    .WithOne(e => e.Technologie)
                    .HasForeignKey(ur => ur.TechnologieId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Technologie>(b =>
            {
                b.HasMany(e => e.Projet_Technologies)
                    .WithOne(e => e.Technologie)
                    .HasForeignKey(ur => ur.TechnologieId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Technologie>(b =>
            {
                b.HasMany(e => e.FiliereTechonologies)
                    .WithOne(e => e.Technologie)
                    .HasForeignKey(ur => ur.TechnologieId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Profile>(b =>
            {
                b.HasMany(e => e.Hobby_Profiles)
                    .WithOne(e => e.Profile)
                    .HasForeignKey(ur => ur.ProfileId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Profile>(b =>
            {
                b.HasMany(e => e.ProfileImages)
                    .WithOne(e => e.Profile)
                    .HasForeignKey(ur => ur.ProfileId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });


            builder.Entity<Profile>(b =>
            {
                b.HasMany(e => e.ProfileTechnologies)
                    .WithOne(e => e.Profile)
                    .HasForeignKey(ur => ur.ProfileId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Profile>(b =>
            {
                b.HasMany(e => e.ProfileImages)
                    .WithOne(e => e.Profile)
                    .HasForeignKey(ur => ur.ProfileId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
            builder.Entity<Hobbies>(b =>
            {
                b.HasMany(e => e.Hobby_Profiles)
                    .WithOne(e => e.Hobbies)
                    .HasForeignKey(ur => ur.HobbyId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
            builder.Entity<User>(b =>
            {
                b.HasMany(e => e.Profiles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<User>(b =>
            {
                b.HasMany(e => e.UserSoftSkills)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<User>(b =>
            {
                b.HasMany(e => e.UserTechnologies)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<User>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<User>(b =>
            {
                b.HasMany(e => e.UserFiliere)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<User>(b =>
            {
                b.HasMany(e => e.UserProjet)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<User>(b =>
            {
                b.HasMany(e => e.UserBadges)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<User>(b =>
            {
                b.HasMany(e => e.Experiences)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Filiere>(b =>
            {
                b.HasMany(e => e.UserFiliere)
                    .WithOne(e => e.Filiere)
                    .HasForeignKey(ur => ur.FiliereId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Filiere>(b =>
            {
                b.HasMany(e => e.FiliereTechonologies)
                    .WithOne(e => e.Filiere)
                    .HasForeignKey(ur => ur.FiliereId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Filiere>(b =>
            {
                b.HasMany(e => e.Filiere_Images)
                    .WithOne(e => e.Filiere)
                    .HasForeignKey(ur => ur.FiliereId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Statut>(b =>
            {
                b.HasMany(e => e.Profiles)
                    .WithOne(e => e.Statut)
                    .HasForeignKey(ur => ur.StatutId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Role>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Projet>(b =>
            {
                b.HasMany(e => e.Projet_categories)
                    .WithOne(e => e.Projet)
                    .HasForeignKey(ur => ur.ProjetId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Projet>(b =>
            {
                b.HasMany(e => e.Projet_Technologies)
                    .WithOne(e => e.Projet)
                    .HasForeignKey(ur => ur.ProjetId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Projet>(b =>
            {
                b.HasMany(e => e.UserProjet)
                    .WithOne(e => e.Projet)
                    .HasForeignKey(ur => ur.ProjetId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Projet>(b =>
            {
                b.HasMany(e => e.ProjetImages)
                    .WithOne(e => e.Projet)
                    .HasForeignKey(ur => ur.ProjetId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Image>(b =>
            {
                b.HasMany(e => e.ProjetImages)
                    .WithOne(e => e.Image)
                    .HasForeignKey(ur => ur.ImageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Image>(b =>
            {
                b.HasMany(e => e.Filiere_Images)
                    .WithOne(e => e.Image)
                    .HasForeignKey(ur => ur.ImageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Image>(b =>
            {
                b.HasMany(e => e.ProfileImages)
                    .WithOne(e => e.Image)
                    .HasForeignKey(ur => ur.ImageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Image>(b =>
            {
                b.HasMany(e => e.ProfileImages)
                    .WithOne(e => e.Image)
                    .HasForeignKey(ur => ur.ImageId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<CategorieDeProjet>(b =>
            {
                b.HasMany(e => e.Projet_categories)
                    .WithOne(e => e.Categorie)
                    .HasForeignKey(ur => ur.CategorieId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<Badge>(b =>
            {
                b.HasMany(e => e.UserBadges)
                    .WithOne(e => e.Badge)
                    .HasForeignKey(ur => ur.BadgeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            builder.Entity<SoftSkills>(b =>
            {
                b.HasMany(e => e.UserSoftSkills)
                    .WithOne(e => e.SoftSkill)
                    .HasForeignKey(ur => ur.SoftSkillsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });


            builder.Entity<User>().Property(u => u.FirstName).HasMaxLength(75);
            builder.Entity<User>().Property(u => u.LastName).HasMaxLength(75);
            builder.Entity<User>().Property(u => u.Email).HasMaxLength(255);
            builder.Entity<User>().Property(u => u.UserName).IsRequired().HasMaxLength(75);
            builder.Entity<Profile>().Property(u => u.UserName).IsRequired().HasMaxLength(75);
            builder.Entity<Profile>().Property(u => u.Firstname).HasMaxLength(75);
            builder.Entity<Profile>().Property(u => u.UserId).IsRequired();
            builder.Entity<Statut>().Property(u => u.Name).IsRequired().HasMaxLength(75);
            builder.Entity<Hobbies>().Property(u => u.Name).IsRequired().HasMaxLength(75);
            builder.Entity<Role>().Property(u => u.Name).IsRequired().HasMaxLength(75);
            builder.Entity<Technologie>().Property(u => u.Name).IsRequired().HasMaxLength(75);
            builder.Entity<Langue>().Property(u => u.Name).IsRequired().HasMaxLength(75);
            builder.Entity<Filiere>().Property(u => u.Name).IsRequired().HasMaxLength(75);
            builder.Entity<CategorieDeProjet>().Property(u => u.Name).IsRequired().HasMaxLength(75);
            builder.Entity<Projet>().Property(u => u.Name).IsRequired().HasMaxLength(75);
            builder.Entity<Image>().Property(u => u.File).IsRequired();
            builder.Entity<Image>().Property(u => u.MimeType).IsRequired();
            builder.Entity<Badge>().Property(u => u.Name).IsRequired().HasMaxLength(75);
            builder.Entity<SoftSkills>().Property(u => u.Name).IsRequired().HasMaxLength(75);
            builder.Entity<CurriculumVitae>().Property(u => u.File).IsRequired();
            builder.Entity<CurriculumVitae>().Property(u => u.MimeType).IsRequired();
            builder.Entity<Experience>().Property(u => u.Titre).IsRequired().HasMaxLength(75);

            //This line allows a unique relation 
            builder.Entity<User>()
                .HasIndex(uw => uw.Email).IsUnique();
            builder.Entity<User>()
                .HasIndex(uw => uw.UserName).IsUnique();
            base.OnModelCreating(builder);
            builder.Entity<Statut>()
                .HasIndex(uw => uw.Name).IsUnique();
            builder.Entity<Role>()
                .HasIndex(uw => uw.Name).IsUnique();
            builder.Entity<Hobbies>()
                .HasIndex(uw => uw.Name).IsUnique();
            builder.Entity<Technologie>()
                .HasIndex(uw => uw.Name).IsUnique();
            builder.Entity<Langue>()
                .HasIndex(uw => uw.Name).IsUnique();
            builder.Entity<Filiere>()
                .HasIndex(uw => uw.Name).IsUnique();
            builder.Entity<Role>()
                .HasIndex(uw => uw.Name).IsUnique();
            builder.Entity<CategorieDeProjet>()
                .HasIndex(uw => uw.Name).IsUnique();
            builder.Entity<Projet>()
                .HasIndex(uw => uw.Name).IsUnique();
            builder.Entity<Badge>()
                .HasIndex(uw => uw.Name).IsUnique();
            builder.Entity<SoftSkills>()
                .HasIndex(uw => uw.Name).IsUnique();

            base.OnModelCreating(builder);
        }
    }
}
