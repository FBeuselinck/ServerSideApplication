namespace Dropbox2.Migrations
{
    using Dropbox2.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dropbox2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Dropbox2.Models.ApplicationDbContext context)
        {
            string roleAdmin = "Administrator";
            string roleNormalUser = "User";
            IdentityResult roleResult;

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists(roleNormalUser))
            {
                roleResult = roleManager.Create(new IdentityRole(roleNormalUser));
            }
            if (!roleManager.RoleExists(roleAdmin))
            {
                roleResult = roleManager.Create(new IdentityRole(roleAdmin));
            }

            if (!context.Users.Any(u => u.Email.Equals("dieter.dp@gmail.com")))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    Name = "de preester",
                    FirstName = "dieter",
                    Email = "dieter@lala.be",
                    UserName = "dieter@lala.be",
                    Address = "graaf karel de goedelaan",
                    City = "kortrijk",
                    Zipcode = "8500",
                    TwitterName = "@nmct"
                };
                manager.Create(user, "-Password1");
                manager.AddToRole(user.Id, roleAdmin);
            }
        }
    }
}
