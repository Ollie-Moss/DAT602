using MySql.Data.MySqlClient;
using System.Data;

namespace DAT602_Demo
{
    public class LoginRegistrationDataAccess : DataAccess
    {
        public string TestLogin()
        {
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call login()");

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }
        public Data Login(string usernameInput, string passwordInput)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var username = new MySqlParameter("@Username", MySqlDbType.VarChar, 100);
            var password = new MySqlParameter("@Password", MySqlDbType.VarChar, 255);

            username.Value = usernameInput;
            password.Value = passwordInput;

            p.Add(username);
            p.Add(password);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "CALL Login(@Username, @Password)", p.ToArray());

            return DataParser.ParseResponse(aDataSet);
        }

        public Data Register(string usernameInput, string emailInput, string passwordInput)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var username = new MySqlParameter("@Username", MySqlDbType.VarChar, 100);
            var email = new MySqlParameter("@Email", MySqlDbType.VarChar, 100);
            var password = new MySqlParameter("@Password", MySqlDbType.VarChar, 255);

            username.Value = usernameInput;
            email.Value = emailInput;
            password.Value = passwordInput;

            p.Add(username);
            p.Add(email);
            p.Add(password);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "CALL Register(@Username, @Email, @Password)", p.ToArray());

            return DataParser.ParseResponse(aDataSet);
        }
    }
}
