using System.Data;
using MySql.Data.MySqlClient;

namespace DAT602_Demo
{
    public class DataAccess
    {
        private static string connectionString
        {
            get { return "Server=localhost;Port=3306;Database=gameDB;Uid=gameClient;password=54321;"; }

        }

        private static MySqlConnection _mySqlConnection = null;
        public static MySqlConnection mySqlConnection
        {
            get
            {
                if (_mySqlConnection == null)
                {
                    _mySqlConnection = new MySqlConnection(connectionString);
                }

                return _mySqlConnection;

            }
        }
    }
}

