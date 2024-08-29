using MySql.Data.MySqlClient;

namespace DAT602_Demo
{
    public class LoginRegistrationDataAccess : DataAccess
    {
        public string TestLogin()
        {
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call LOGIN_TEST()");

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }
    }
}
