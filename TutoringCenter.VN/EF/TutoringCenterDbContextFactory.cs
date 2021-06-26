using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace TutoringCenter.VN.EF
{
    public class TutoringCenterDbContextFactory : IDesignTimeDbContextFactory<TutoringCenterDbContext>
    {
        public TutoringCenterDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("TutoringCenterDb");
            var optionsBuilder = new DbContextOptionsBuilder<TutoringCenterDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new TutoringCenterDbContext(optionsBuilder.Options);
        }
    }
}
