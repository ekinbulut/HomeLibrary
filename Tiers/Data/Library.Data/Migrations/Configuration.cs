namespace Library.Data.Migrations
{
    using Library.Data.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library.Data.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Library.Data.LibraryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            DateTime dateTime = DateTime.Now;

            ERole preminiumUser = new ERole
            {
                Name = "Preminium",
                CreatedDateTime = dateTime
            };

            ERole user = new ERole
            {
                Name = "User",
                CreatedDateTime = dateTime
            };

            ERole administrator = new ERole
            {
                Name = "Administrator",
                CreatedDateTime = dateTime
            };

            context.Set<ERole>().AddOrUpdate(new ERole[] { administrator, user, preminiumUser });
        }
    }
}
