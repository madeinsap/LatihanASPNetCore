using LatihanASPNetCore.Model;
using System.Data;
using System.Data.SqlClient;

namespace LatihanASPNetCore.Core
{
    public class DBHelper
    {
        private readonly IConfiguration configuration;

        public DBHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IDbConnection CreateConnection() => new SqlConnection(configuration.GetConnectionString("CourseDB"));
    }
}
