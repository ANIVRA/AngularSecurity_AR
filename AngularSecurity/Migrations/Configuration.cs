using AngularSecurity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AngularSecurity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularSecurity.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AngularSecurity.Models.ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);


            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                var role = new IdentityRole { Name = "Member" };
                manager.Create(role);
            }


            var admin = userManager.FindByEmail("admin@coderfoundry.com");
            if (admin == null)
            {
                admin = new ApplicationUser()
                {
                    UserName = "admin@coderfoundry.com",
                    Email = "admin@coderfoundry.com"
                };

                userManager.Create(admin, "Abc&123!");
                userManager.AddToRole(admin.Id, "Admin");
                userManager.AddToRole(admin.Id, "Member");


                
            }
        }
    }
}
