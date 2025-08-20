using ProductCatalogBackend.Exception;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogBackend.Util
{
    public static class DBPropertyUtil
    {
        public static string GetConnectionString(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            foreach (var line in lines)
            {
                if (line.StartsWith("connectionString=Server=(localdb)\\mssqllocaldb;Database=ProductCatalogDB;Trusted_Connection=True;\r\n"))
                    return line.Split('=')[1].Trim();
            }
            throw new CatalogException("Connection string not found.");
        }
    }
}
