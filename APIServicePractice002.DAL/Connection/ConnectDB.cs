using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServicePractice002.DAL.Connection
{
    public class ConnectDB
    {
        private string SqlEndpoint = "localhost";
        private SqlConnection cnn;
        public ConnectDB()
        {
            
        }
        public SqlConnection ConnectToDatabase()
        {
            string connectionString;

            connectionString = $"Data Source={SqlEndpoint};Initial Catalog=practice002;User ID=sa;Password=Mo123456789";

            cnn = new SqlConnection(connectionString);
            return cnn;
        }

    }
}
