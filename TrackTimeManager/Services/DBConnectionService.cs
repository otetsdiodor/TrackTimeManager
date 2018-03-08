using System;
using System.Collections.Generic;
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

        public List<string> ReadData()
        {
            List<string> result = new List<string>();
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TrackAreas",sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    result.Add((string)sqlDataReader.GetValue(1));
                }
                sqlConnection.Close();
                return result;
            }
            sqlConnection.Close();
            return result;
        }
    }
}
