using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ColoradoCrud.Api.Infrastructure.Data
{
    public class ColoradoCrudContextFactory : IDesignTimeDbContextFactory<ColoradoCrudContext>
    {
        public ColoradoCrudContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\ColoradoCrud.Api");
            var optionsBuilder = new DbContextOptionsBuilder<ColoradoCrudContext>();


            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ColoradoConnection");


            optionsBuilder.UseSqlServer(connectionString);


            return new ColoradoCrudContext(optionsBuilder.Options);
        }

    }
}

