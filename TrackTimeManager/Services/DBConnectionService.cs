using System;
using System.Configuration;
using System.Data.SqlClient;

namespace TrackTimeManager.Services
{
    class DBConnectionService
    {
        static string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        SqlConnection CurrentConnection;

        private static SqlConnection Open()
        {
            return new SqlConnection();
        }
    }
}
