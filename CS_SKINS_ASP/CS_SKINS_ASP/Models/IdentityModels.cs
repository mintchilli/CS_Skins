﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace CS_SKINS_ASP.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string AspNetUserId { get; set; }
        [ForeignKey("AspNetUserId")]
        public virtual AspNetUserInfoSup details { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<AspNetUserInfoSup> userprop { get; set; }
        public DbSet<Sujet> Sujet { get; set; }
        public DbSet<Posts> Posts { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<CS_SKINS_ASP.Models.Crate> Crates { get; set; }

        public System.Data.Entity.DbSet<CS_SKINS_ASP.Models.Skins> Skins { get; set; }

        public System.Data.Entity.DbSet<CS_SKINS_ASP.Models.Ventes> Ventes { get; set; }
        //public System.Data.Entity.DbSet<CS_SKINS_ASP.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}