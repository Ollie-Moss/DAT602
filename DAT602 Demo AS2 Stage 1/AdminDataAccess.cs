using MySql.Data.MySqlClient;

namespace DAT602_Demo
{
    public class AdminDataAccess: DataAccess
    {
        public string TestAdmin()
        {
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call ADMIN_TEST()");

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }

        public Data DeleteAccount(int accountId)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var pAccountId = new MySqlParameter("@AccountId", MySqlDbType.Int64);

            pAccountId.Value = accountId;

            p.Add(pAccountId);
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call DeleteAccount(@AccountId)", p.ToArray());
            return DataParser.Instance.ParseTables(aDataSet);
        }

        public Data EditAccount(int accountId, string username, string email, string password)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var pAccountId = new MySqlParameter("@AccountId", MySqlDbType.Int64);
            var pUsername = new MySqlParameter("@Username", MySqlDbType.VarChar, 100);
            var pEmail = new MySqlParameter("@Email", MySqlDbType.VarChar, 100);
            var pPassword = new MySqlParameter("@Password", MySqlDbType.VarChar, 255);

            pAccountId.Value = accountId;
            pUsername.Value = username;
            pEmail.Value = email;
            pPassword.Value = password;

            p.Add(pAccountId);
            p.Add(pUsername);
            p.Add(pEmail);
            p.Add(pPassword);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "CALL EditAccount(@AccountId, @Username, @Email, @Password)", p.ToArray());

            return DataParser.Instance.ParseTables(aDataSet);
        }

        public Data KillGame(int gameId)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var pGameId = new MySqlParameter("@GameId", MySqlDbType.Int64);

            pGameId.Value = gameId;

            p.Add(pGameId);
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call KillGame(@GameId)", p.ToArray());
            return DataParser.Instance.ParseTables(aDataSet);
        }
    }
}
