namespace MusicStore.Migrations
{
    using MusicStore.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MusicStore.Data.MusicStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MusicStore.Data.MusicStoreDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Genres.AddOrUpdate(new Genre { Id = 1, Name = "Pop" });
            context.Genres.AddOrUpdate(new Genre { Id = 2, Name = "Jazz" });
            context.Genres.AddOrUpdate(new Genre { Id = 3, Name = "Rock'n Roll" });
        }
    }
}
