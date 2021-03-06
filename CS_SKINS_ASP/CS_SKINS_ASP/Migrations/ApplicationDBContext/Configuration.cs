namespace CS_SKINS_ASP.Migrations.ApplicationDBContext
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CS_SKINS_ASP.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CS_SKINS_ASP.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            PasswordHasher pass = new PasswordHasher();

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            AjouterUsagers(pass, context);
            AjouterRoles(context);
            AjouterUsersRoles(context);
            //AjouterPost(context);

        }

        //private void AjouterPost(ApplicationDbContext context)
        //{
        //    Posts[] posts =
        //    {
        //        new Posts()
        //        {
        //            Auteur = context.Users.Where(m => m.Email == "admin@clubinfosth.ca").FirstOrDefault().Id,
        //            DatePublication = DateTime.Now,
        //            Message = "test1",
        //            SujetId = 5
        //        },
        //        new Posts()
        //        {
        //            Auteur = context.Users.Where(m => m.Email == "admin@clubinfosth.ca").FirstOrDefault().Id,
        //            DatePublication = DateTime.Now,
        //            Message = "test2",
        //            SujetId = 5
        //        }
        //    };
        //    context.Posts.AddOrUpdate(r => r.Id, posts);
        //    context.SaveChanges();
        //}

        private void AjouterUsersRoles(ApplicationDbContext context)
        {
            IdentityUserRole[] userRoles =
                        {
                new IdentityUserRole()
                {
                    UserId = context.Users.Where(u => u.UserName == "admin@clubinfosth.ca").First().Id,
                    RoleId = context.Roles.Where(r => r.Name == "Administrateur").First().Id
                },

                new IdentityUserRole()
                {
                    UserId = context.Users.Where(u => u.UserName == "utilisateur@clubinfosth.ca").First().Id,
                    RoleId = context.Roles.Where(r => r.Name == "Utilisateur").First().Id
                },

                new IdentityUserRole()
                {
                    UserId = context.Users.Where(u => u.UserName == "moderateur@clubinfosth.ca").First().Id,
                    RoleId = context.Roles.Where(r => r.Name == "Modérateur").First().Id
                },

                new IdentityUserRole()
                {
                    UserId = context.Users.Where(u => u.UserName == "exclus@clubinfosth.ca").First().Id,
                    RoleId = context.Roles.Where(r => r.Name == "ExclusionForum").First().Id
                }
            };

            context.Set<IdentityUserRole>().AddOrUpdate(ur => new { ur.UserId, ur.RoleId }, userRoles);
            context.SaveChanges();
        }

        private void AjouterRoles(ApplicationDbContext context)
        {
            IdentityRole[] roles =
                        {
                new IdentityRole {Name = "Administrateur" },
                new IdentityRole {Name = "Utilisateur" },
                new IdentityRole {Name = "Modérateur" },
                new IdentityRole {Name = "ExclusionForum" }
            };

            context.Roles.AddOrUpdate(r => r.Name, roles);
            context.SaveChanges();
        }

        private void AjouterUsagers(PasswordHasher pass, ApplicationDbContext context)
        {
            ApplicationUser[] users =
                        {
                new ApplicationUser
                {
                    Email = "admin@clubinfosth.ca",
                    UserName = "admin@clubinfosth.ca",
                    PasswordHash = pass.HashPassword("Admin1!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    details = new AspNetUserInfoSup()
                    {
                        Prenom = "Yves", Nom = "Bloduc",
                        DateInscription = DateTime.Now
                    }
                },

                new ApplicationUser
                {
                    Email = "utilisateur@clubinfosth.ca",
                    UserName = "utilisateur@clubinfosth.ca",
                    PasswordHash = pass.HashPassword("Utilisateur1!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    details = new AspNetUserInfoSup()
                    {
                        Prenom = "Marc", Nom = "Laforest",
                        DateInscription = DateTime.Now
                    }
                },

                new ApplicationUser
                {
                    Email = "moderateur@clubinfosth.ca",
                    UserName = "moderateur@clubinfosth.ca",
                    PasswordHash = pass.HashPassword("Moderateur1!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    details = new AspNetUserInfoSup()
                    {
                        Prenom = "Nicolas", Nom = "Bourdage",
                        DateInscription = DateTime.Now
                    }
                },

                new ApplicationUser
                {
                    Email = "exclus@clubinfosth.ca",
                    UserName = "exclus@clubinfosth.ca",
                    PasswordHash = pass.HashPassword("Exclus1!"),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    details = new AspNetUserInfoSup()
                    {
                        Prenom = "Sebastien", Nom = "Gagnon",
                        DateInscription = DateTime.Now
                    }
                }
            };

            foreach (ApplicationUser u in users)
                u.details.ID = u.Id;

            context.Users.AddOrUpdate(u => u.UserName, users);
            context.SaveChanges();

        }
    }
}
