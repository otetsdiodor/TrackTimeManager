using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using TrackTimeManager.Models;

namespace TrackTimeManager.Services
{
    public class DBConnectionService
    {
        static string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        SqlConnection CurrentConnection;

        private static SqlConnection Open()
        {
            return new SqlConnection();
        }

        public List<TrackAreaModel> ReadData()
        {
            List<TrackAreaModel> result = new List<TrackAreaModel>();
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TrackAreas",sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    string name = sqlDataReader.GetString(1);
                    string totalTime = sqlDataReader.GetString(2);
                    result.Add(new TrackAreaModel(name,totalTime));
                }
                sqlConnection.Close();
                return result;
            }
            sqlConnection.Close();
            return result;
        }
    }
}
