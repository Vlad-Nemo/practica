using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SystemOfTests
{
    
    class DB
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source = LAZARPC; Initial Catalog = AppDB; Integrated Security = True");

        public void ConnectToDB()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void DisconnectDB()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}
