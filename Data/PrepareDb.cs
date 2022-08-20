using System.Linq;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepareDb
    {
        public static void Population(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var serviceProvider = scope.ServiceProvider;
            var context = serviceProvider.GetRequiredService<AppDbContext>();
            seedData(context);
        }

        private static void seedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data...");
                context.Platforms.AddRange(
                    new Platform()
                    {
                        Name = "Dot Net",
                        Publisher = "Microsoft",
                        Cost = "Free "
                    },
                    new Platform()
                    {
                        Name = "SQL Server Express",
                        Publisher = "Microsoft",
                        Cost = "Free "
                    },
                    new Platform()
                    {
                        Name = "Kubernetes",
                        Publisher = "Cloud Native Computing Foundation",
                        Cost = "Free "
                    }
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data.");
            }

        }
    }
}