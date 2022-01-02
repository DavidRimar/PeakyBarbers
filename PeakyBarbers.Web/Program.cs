using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PetManager.Data.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeakyBarbers.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {

                // 1. run migrations (updates or creates the local database)
                var dbContext = scope.ServiceProvider.GetRequiredService<Data.PeakyBarbersDbContext>();
                var migrations = dbContext.Database.GetMigrations().ToHashSet();
                if (dbContext.Database.GetAppliedMigrations().Any(a => !migrations.Contains(a)))
                    throw new InvalidOperationException("There is a migration that has already been applied to the existing database. Delete the database or repair the state of the migrations, then restart the app!");
                dbContext.Database.Migrate();

                // 2. role seeder
                var roleSeeder = scope.ServiceProvider.GetRequiredService<IRoleSeedService>();
                await roleSeeder.SeedRoleAsync();

                // 3. user seeder
                var userSeeder = scope.ServiceProvider.GetRequiredService<IUserSeedService>();
                await userSeeder.SeedUserAsync();

                // 4. Seed Data - User Related
                await userSeeder.SeedUserDataAsync(dbContext);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
