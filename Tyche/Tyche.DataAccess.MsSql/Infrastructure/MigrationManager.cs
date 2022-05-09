using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Tyche.DataAccess.MsSql.Context;



namespace Tyche.DataAccess.MsSql.Infrastructure
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<DeckContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            }

            return host;
        }
    }
}
