using MySql.Data.MySqlClient;
using store.exceptions;


namespace store.factory
{
    internal class ConnectionFactory
    {
        private static MySqlConnection conn;
        private static string url = "server=localhost;database=loja;user=root;password=root123";


        public static MySqlConnection getConnection()
        {
            try
            {
                conn = new MySqlConnection(url);
                conn.Open();
            }
            catch(MySqlException error)
            {
                throw new ProductException("Error: " + error.Message);
            }

            return conn;
        }
    }
}
