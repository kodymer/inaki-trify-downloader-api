using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TriFy.ExportAuto.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class ExportAutoDbContextFactory : IDesignTimeDbContextFactory<ExportAutoDbContext>
{
    public ExportAutoDbContext CreateDbContext(string[] args)
    {
        ExportAutoEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<ExportAutoDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new ExportAutoDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../TriFy.ExportAuto.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
