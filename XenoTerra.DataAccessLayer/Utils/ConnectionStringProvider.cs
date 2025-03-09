using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace XenoTerra.DataAccessLayer.Utils
{
    public static class ConnectionStringProvider
    {
        public static string GetConnectionString()
        {
            var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "XenoTerra.WebAPI", "appsettings.json");
            var jsonContent = File.ReadAllText(jsonFilePath);

            var connectionString = JsonSerializer.Deserialize<JsonElement>(jsonContent)
                .GetProperty("ConnectionStrings")
                .GetProperty("DefaultConnection")
                .GetString();

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string could not be found in appsettings.json");
            }

            return connectionString;
;
        }
    }
}
