using ApplicationForTrainingWEB.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ApplicationForTraining.Infrastructure;

public class MyDbContextFactory : IDesignTimeDbContextFactory<ApplicationForTrainingWEBDbContext>
{

    ApplicationForTrainingWEBDbContext IDesignTimeDbContextFactory<ApplicationForTrainingWEBDbContext>.CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        var builder = new DbContextOptionsBuilder<ApplicationForTrainingWEBDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseSqlServer(connectionString);

        return new ApplicationForTrainingWEBDbContext(builder.Options);
    }


}
