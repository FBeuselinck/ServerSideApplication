namespace Dropbox.Migrations
{
    using Dropbox.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dropbox.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //deze code wordt aangeroepen als we een migratie uitvoeren
        protected override void Seed(Dropbox.Models.ApplicationDbContext context)
        {
            // hier zullen we 2 rollen gaan aanmaken in de database en één administrator
            // we zullen het e-mail adres ook gebruiken als username aangezien dit uniek is
            string roleAdmin = "Administrator";
            string roleNormalUser = "User";
            IdentityResult roleResult;

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if(!RoleManager.RoleExists(roleNormalUser))
            {
                roleResult = RoleManager.Create(new IdentityRole(roleNormalUser));
            }

            if (!RoleManager.RoleExists(roleAdmin))
            {
                roleResult = RoleManager.Create(new IdentityRole(roleAdmin));
            }


            if(!context.Users.Any(u => u.Email.Equals("rodric.degroote@student.howest.be")))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser()
                {
                    Name = "Degroote",
                    FirstName = "Rodric",
                    Email = "rodric.degroote@student.howest.be",
                    UserName = "rodric.degroote@student.howest.be",
                    Address = "Graaf Karel De Goedelaan 1",
                    City = "Kortrijk",
                    ZipCode = "8500",
                    TwitterName = "@nmct"
                };
                manager.Create(user, "-Password1");
                manager.AddToRole(user.Id, roleAdmin);
            }


            //  This method will be called after migrating to the latest version.

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
        }
    }
}
