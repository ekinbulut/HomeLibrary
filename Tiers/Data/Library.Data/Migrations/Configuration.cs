using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Library.Common.Helpers;
using Library.Data.Entities;

namespace Library.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LibraryContext context)
        {
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

            // sets roles
            context.Set<ERole>().AddOrUpdate(new ERole()
            {
                Name = "Administrator",
                CreatedDateTime = DateTime.Now
            });

            context.Set<ERole>().AddOrUpdate(new ERole()
            {
                Name = "User",
                CreatedDateTime = DateTime.Now
            });


            var pass = "p@ssw0rd";
            var crypt = pass.HashMd5();

            // sets users
            context.Set<EUser>().AddOrUpdate(new EUser()
            {
                Name = "Administrator",
                Gender = Gender.Male,
                Occupation = "Developer",
                Password = crypt,
                IsActive = true,
                CreatedDateTime = DateTime.Now,
                UserName = "admin@admin.com",
                //ERole = role,
                LastLoginDate = null,
                RoleId = 2
            });

        }
    }
}
