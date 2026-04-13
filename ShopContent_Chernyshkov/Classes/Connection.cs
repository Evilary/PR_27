using System.Data;
using System.Data.SqlClient;
using MySqlConnector; 

namespace ShopContent_Chernyshkov.Classes
{
    public class Connection
    {

        private static readonly string config = "server=localhost;port=3306;database=poslk;uid=root;pwd=;";

        public static MySqlConnection OpenConnection() 
        {
            MySqlConnection connection = new MySqlConnection(config);
            connection.Open();
            return connection;
        }

        public static MySqlDataReader Query(string SQL, out MySqlConnection connection) 
        {
            connection = OpenConnection();
            return new MySqlCommand(SQL, connection).ExecuteReader();
        }

        public static void CloseConnection(MySqlConnection connection) 
        {
            connection.Close();
            MySqlConnection.ClearPool(connection);
        }
    }
}