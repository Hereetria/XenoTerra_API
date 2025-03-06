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
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();

            // API veya başka bir katmandan gelen Connection String
            string connectionString = ConnectionStringProvider.GetConnectionString();

            // Eğer connection string boş veya null ise hata fırlat
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string could not be retrieved.");
            }

            // SQL Server bağlantısını yapılandır
            optionsBuilder.UseSqlServer(connectionString, options =>
                options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));

            return new Context(optionsBuilder.Options);
        }
    }

}
