using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using TechCafe.Repository;
using TechCafe.Repository.Entities;

namespace TechCafe.Api
{
    public partial class Startup
    {
        public void InitializeDb(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Startup>>();
                try
                {
                    var context = services.GetRequiredService<TechCafeDbContext>();
                    TechCafeDbInitializer.Initialize(context);
                    if (!context.Users.Any(x => x.Username == "techcafe"))
                    {
                        var passwordHasher = services.GetRequiredService<IPasswordHasher<User>>();
                        var user = new User
                        {
                            Username = "techcafe",
                        };
                        user.Password = passwordHasher.HashPassword(user, "techcafe");
                        context.Users.Add(user);
                        context.SaveChanges();
                    }
                    logger.LogInformation("Database is updated.");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
        }
    }
}
