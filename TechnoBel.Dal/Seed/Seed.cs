using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnoBel.Dal.DbContexts;
using TechnoBel.Dal.Models;

namespace TechnoBel.Dal.Seed
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<Context>();
            context.Database.EnsureCreated();

            if (!context.Role.Any())
            {
                Role roles = new Role
                {
                    Name = "Admin",
                    CreationDate = DateTime.Now,
                    Updatedate = DateTime.Now

                };
                context.Role.Add(roles);
                context.Entry(roles).State = EntityState.Added;
                context.SaveChanges();
                Role roles2 = new Role
                {
                    Name = "Stagiaire",
                    CreationDate = DateTime.Now,
                    Updatedate = DateTime.Now

                };
                context.Role.Add(roles2);
                context.Entry(roles2).State = EntityState.Added;
                context.SaveChanges();
            }


            if (!context.User.Any())
            {
                User admin = new User();

                admin.Email = "superAdmin@gmail.com";
                admin.UserName = "SuperAdmin";
                admin.FirstName = "Super";
                admin.LastName = "Admin";
                admin.Password = new PasswordHasher<User>().HashPassword(admin, "superAdmin007!");
                
                admin.CreationDate = DateTime.Now;
                admin.Updatedate = DateTime.Now;
                context.User.Add(admin);
                context.Entry(admin).State = EntityState.Added;
                context.SaveChanges();
                User stagiaire = new User();
                stagiaire.Email = "candidat@gmail.com";
                stagiaire.UserName = "Candidat";
                stagiaire.FirstName = "Super";
                stagiaire.LastName = "Candidat";
                stagiaire.Password = new PasswordHasher<User>().HashPassword(stagiaire, "superCandidat007!");
                
                stagiaire.CreationDate = DateTime.Now;
                stagiaire.Updatedate = DateTime.Now;
                context.User.Add(stagiaire);
                context.Entry(stagiaire).State = EntityState.Added;
                context.SaveChanges();
            }

            //User_Role
            if (!context.UserRole.Any())
            {
                UserRole roles = new UserRole
                {
                    UserId = context.User.First().Id,
                    RoleId = context.Role.First().Id

                };
                context.UserRole.Add(roles);
                context.Entry(roles).State = EntityState.Added;
                context.SaveChanges();
                UserRole roles2 = new UserRole
                {
                    UserId = 2,
                    RoleId = 2

                };
                context.UserRole.Add(roles2);
                context.Entry(roles2).State = EntityState.Added;
                context.SaveChanges();
            }


            //hobbies
            if (!context.Hobby.Any())
            {
                Hobbies hobbies = new Hobbies
                {
                    Name = "Tennis",
                    CreationDate = DateTime.Now,
                    Updatedate = DateTime.Now

                };
                context.Hobby.Add(hobbies);
                context.Entry(hobbies).State = EntityState.Added;
                context.SaveChanges();
            }

            //statut
            if (!context.Statut.Any())
            {
                Statut statut = new Statut
                {
                    Name = "brouillon",
                    CreationDate = DateTime.Now,
                    Updatedate = DateTime.Now

                };
                context.Statut.Add(statut);
                context.Entry(statut).State = EntityState.Added;
                context.SaveChanges();
            }
            //Profile
            if (!context.Profile.Any())
            {
                Profile profile = new Profile
                {
                    UserName = "profile 1",
                    Firstname = "prenom profil",
                    Description = "description profile",
                    UserId = 2,
                    Email = "profile1@gmail.com",
                    StatutId = context.Statut.First().Id,
                    CreationDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };
                context.Profile.Add(profile);
                context.Entry(profile).State = EntityState.Added;
                context.SaveChanges();
            }

            //hobbies_Profile
            if (!context.Hobby_Profile.Any())
            {
                Hobby_Profile hobbies = new Hobby_Profile
                {
                    ProfileId = context.Profile.First().Id,
                    HobbyId = context.Hobby.First().Id

                };
                context.Hobby_Profile.Add(hobbies);
                context.Entry(hobbies).State = EntityState.Added;
                context.SaveChanges();
            }

            //technologie
            if (!context.Technologie.Any())
            {
                Technologie tech = new Technologie
                {
                    Name = "Ado.Net",
                    CreationDate = DateTime.Now,
                    Updatedate = DateTime.Now

                };
                context.Technologie.Add(tech);
                context.Entry(tech).State = EntityState.Added;
                context.SaveChanges();
                Technologie tech2 = new Technologie
                {
                    Name = "Entity Framework",
                    CreationDate = DateTime.Now,
                    Updatedate = DateTime.Now

                };
                context.Technologie.Add(tech2);
                context.Entry(tech2).State = EntityState.Added;
                context.SaveChanges();
                Technologie tech3 = new Technologie
                {
                    Name = "Sql",
                    CreationDate = DateTime.Now,
                    Updatedate = DateTime.Now

                };
                context.Technologie.Add(tech3);
                context.Entry(tech3).State = EntityState.Added;
                context.SaveChanges();
            }

            //userTechnologie
            if (!context.UserTechnologies.Any())
            {
                UserTechnologie tech = new UserTechnologie
                {
                    UserId = 2,
                    TechnologieId = context.Technologie.First().Id

                };
                context.UserTechnologies.Add(tech);
                context.Entry(tech).State = EntityState.Added;
                context.SaveChanges();
            }

            //langue
            if (!context.Langues.Any())
            {
                Langue français = new Langue
                {
                    Name = "Français",
                    CreationDate = DateTime.Now,
                    Updatedate = DateTime.Now

                };
                context.Langues.Add(français);
                context.Entry(français).State = EntityState.Added;
                context.SaveChanges();
                Langue anglais = new Langue
                {
                    Name = "Anglais",
                    CreationDate = DateTime.Now,
                    Updatedate = DateTime.Now

                };
                context.Langues.Add(anglais);
                context.Entry(anglais).State = EntityState.Added;
                context.SaveChanges();
            }

            //filieres
            if (!context.Filieres.Any())
            {
                Filiere filiere = new Filiere
                {
                    Name = "filiere-1",
                    Annee = DateTime.Now.Year - 1,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam ultrices, nunc eu rhoncus ornare, orci quam convallis justo, ut tempus lorem mauris sed nunc. Pellentesque blandit erat nibh, vel euismod urna mattis eu. Sed cursus condimentum libero id consequat. In pulvinar ultricies augue, eu fringilla augue sodales pulvinar. Nulla facilisi. Aliquam dignissim risus fringilla pellentesque interdum. Maecenas pharetra, ante non faucibus tincidunt, nisi mi tincidunt massa, sit amet tempus orci nunc sed turpis. Donec pharetra in dui at sodales. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis quis elementum risus. In ut bibendum velit. Maecenas egestas fermentum lectus non vehicula. Cras nec urna nec massa dictum ornare. Donec luctus lectus a quam auctor, non interdum neque finibus. Nunc vel maximus justo. Donec non auctor nulla.",
                    CreationDate = DateTime.Now,
                    Updatedate = DateTime.Now
                };
                context.Filieres.Add(filiere);
                context.Entry(filiere).State = EntityState.Added;
                context.SaveChanges();
                Filiere filiere2 = new Filiere
                {
                    Name = "filiere-2",
                    Annee = DateTime.Now.Year,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam ultrices, nunc eu rhoncus ornare, orci quam convallis justo, ut tempus lorem mauris sed nunc. Pellentesque blandit erat nibh, vel euismod urna mattis eu. Sed cursus condimentum libero id consequat. In pulvinar ultricies augue, eu fringilla augue sodales pulvinar. Nulla facilisi. Aliquam dignissim risus fringilla pellentesque interdum. Maecenas pharetra, ante non faucibus tincidunt, nisi mi tincidunt massa, sit amet tempus orci nunc sed turpis. Donec pharetra in dui at sodales. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis quis elementum risus. In ut bibendum velit. Maecenas egestas fermentum lectus non vehicula. Cras nec urna nec massa dictum ornare. Donec luctus lectus a quam auctor, non interdum neque finibus. Nunc vel maximus justo. Donec non auctor nulla.",
                    CreationDate = DateTime.Now,
                    Updatedate = DateTime.Now
                };
                context.Filieres.Add(filiere2);
                context.Entry(filiere2).State = EntityState.Added;
                context.SaveChanges();
            }

            //user-filieres
            if (!context.UserFilieres.Any())
            {
                UserFiliere filiere = new UserFiliere
                {
                    UserId = 2,
                    FiliereId = context.Filieres.First().Id

                };
                context.UserFilieres.Add(filiere);
                context.Entry(filiere).State = EntityState.Added;
                context.SaveChanges();
            }

            //filier-technologie
            if (!context.FiliereTechonologies.Any())
            {
                FiliereTechonologie filiere = new FiliereTechonologie
                {
                    TechnologieId = 2,
                    FiliereId = context.Filieres.First().Id

                };
            }

            //CategorieDeProjet
            if (!context.CategorieDeProjets.Any())
            {
                CategorieDeProjet categorie = new CategorieDeProjet
                {
                    Name = "Innovation",
                    CreationDate = DateTime.Now,
                    Updatedate = DateTime.Now

                };
                context.CategorieDeProjets.Add(categorie);
                context.Entry(categorie).State = EntityState.Added;
                context.SaveChanges();
                CategorieDeProjet categorie2 = new CategorieDeProjet
                {
                    Name = "Partenariat",
                    CreationDate = DateTime.Now,
                    Updatedate = DateTime.Now

                };
                context.CategorieDeProjets.Add(categorie2);
                context.Entry(categorie2).State = EntityState.Added;
                context.SaveChanges();
                CategorieDeProjet categorie3 = new CategorieDeProjet
                {
                    Name = "Public",
                    CreationDate = DateTime.Now,
                    Updatedate = DateTime.Now

                };
                context.CategorieDeProjets.Add(categorie3);
                context.Entry(categorie3).State = EntityState.Added;
                context.SaveChanges();
                CategorieDeProjet categorie4 = new CategorieDeProjet
                {
                    Name = "Nature",
                    CreationDate = DateTime.Now,
                    Updatedate = DateTime.Now

                };
                context.CategorieDeProjets.Add(categorie4);
                context.Entry(categorie4).State = EntityState.Added;
                context.SaveChanges();
            }

            //Projets
            if (!context.Projets.Any())
            {
                Projet projet = new Projet
                {
                    Name = "Chaine éditoriale",
                    CreationDate = DateTime.Now,
                    Updatedate = DateTime.Now

                };
                context.Projets.Add(projet);
                context.Entry(projet).State = EntityState.Added;
                context.SaveChanges();
                Projet projet2 = new Projet
                {
                    Name = "Industrie",
                    CreationDate = DateTime.Now,
                    Updatedate = DateTime.Now

                };
                context.Projets.Add(projet2);
                context.Entry(projet2).State = EntityState.Added;
                context.SaveChanges();
            }

            //Projet_Categorie
            if (!context.Projet_Categories.Any())
            {
                Projet_Categorie PC = new Projet_Categorie
                {
                    ProjetId = 1,
                    CategorieId = context.CategorieDeProjets.First().Id

                };
                context.Projet_Categories.Add(PC);
                context.Entry(PC).State = EntityState.Added;
                context.SaveChanges();
            }

            //UserProjet
            if (!context.UserProjets.Any())
            {
                UserProjet UP = new UserProjet
                {
                    ProjetId = 1,
                    UserId = 1,
                    StagiaireId = 2

                };
                context.UserProjets.Add(UP);
                context.Entry(UP).State = EntityState.Added;
                context.SaveChanges();
            }

            //Badge
            if(!context.Badges.Any())
            {
                Badge master = new Badge
                {
                    Name = "Master",
                    Description = "blablablablabl"
                };
                context.Badges.Add(master);
                context.Entry(master).State = EntityState.Added;
                context.SaveChanges();
                Badge angular = new Badge
                {
                    Name = "Angular",
                    Description = "blablablabla"
                };
                context.Badges.Add(angular);
                context.Entry(angular).State = EntityState.Added;
                context.SaveChanges();
            }

            //UserBadge
            if (!context.UserBadges.Any())
            {
                UserBadge master = new UserBadge
                {
                    UserId = 2,
                    BadgeId = context.Badges.First().Id
                };
                context.UserBadges.Add(master);
                context.Entry(master).State = EntityState.Added;
                context.SaveChanges();
            }

            //Projet_Technologie
            if (!context.Projet_Technologies.Any())
            {
                Projet_Technologie master = new Projet_Technologie
                {
                    ProjetId = 2,
                    TechnologieId = context.Technologie.First().Id
                };
                context.Projet_Technologies.Add(master);
                context.Entry(master).State = EntityState.Added;
                context.SaveChanges();
            }


            //SoftSkills
            if (!context.SoftSkills.Any())
            {
                SoftSkills com = new SoftSkills
                {
                    Name = "Commuication"
                };
                context.SoftSkills.Add(com);
                context.Entry(com).State = EntityState.Added;
                context.SaveChanges();
                SoftSkills org = new SoftSkills
                {
                    Name = "Organisation"
                };
                context.SoftSkills.Add(org);
                context.Entry(org).State = EntityState.Added;
                context.SaveChanges();
            }

            //Projet_Technologie
            if (!context.UserSoftSkills.Any())
            {
                UserSoftSkills master = new UserSoftSkills
                {
                    UserId = 2,
                    SoftSkillsId = context.SoftSkills.First().Id
                };
                context.UserSoftSkills.Add(master);
                context.Entry(master).State = EntityState.Added;
                context.SaveChanges();
            }

            //Expériences
            if (!context.Experiences.Any())
            {
                Experience exp = new Experience
                {
                    Titre = "Développeur .net",
                    Description = "développement d'una web api en .net core",
                    UserId = 2
                };
                context.Experiences.Add(exp);
                context.Entry(exp).State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
