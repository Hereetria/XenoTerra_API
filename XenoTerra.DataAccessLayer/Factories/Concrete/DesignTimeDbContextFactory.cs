using XenoTerra.DataAccessLayer.Contexts;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.Json;
using XenoTerra.DataAccessLayer.Utils;

namespace XenoTerra.DataAccessLayer.Factories.Concrete
{
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        // Connection String sadece Provider üzerinden alınır
        string connectionString = ConnectionStringProvider.GetConnectionString();

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string coul d not be retrieved from ConnectionStringProvider.");
        }

        optionsBuilder.UseSqlServer(connectionString, options =>
            options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));

        return new AppDbContext(optionsBuilder.Options);
    }
}



}
