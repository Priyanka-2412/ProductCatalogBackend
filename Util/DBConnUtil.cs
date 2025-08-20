using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogBackend.Util
{
    public static class DBConnUtil
    {
        public static SqlConnection GetConnection(string propertyFile)
        {
            var connStr = DBPropertyUtil.GetConnectionString(propertyFile);
            var conn = new SqlConnection(connStr);
            conn.Open();
            return conn;
        }
    }
}
