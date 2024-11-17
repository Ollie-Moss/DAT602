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
            return DataParser.ParseResponse(aDataSet);
        }

        public Data EditPlayer(int playerId, string displayName)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int32);
            var pDisplayName = new MySqlParameter("@DisplayName", MySqlDbType.VarChar, 255);

            pPlayerId.Value = playerId;
            pDisplayName.Value = displayName;
            p.Add(pPlayerId);
            p.Add(pDisplayName);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "CALL EditPlayer(@PlayerId, @DisplayName)", p.ToArray());

            return DataParser.ParseResponse(aDataSet);
        }

        public Data KillGame(int gameId)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var pGameId = new MySqlParameter("@GameId", MySqlDbType.Int64);

            pGameId.Value = gameId;

            p.Add(pGameId);
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call KillGame(@GameId)", p.ToArray());
            return DataParser.ParseResponse(aDataSet);
        }
        public bool IsAdmin(int accountId)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var pAccountId = new MySqlParameter("@AccountId", MySqlDbType.Int64);

            pAccountId.Value = accountId;

            p.Add(pAccountId);
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call IsAdmin(@AccountId)", p.ToArray());
            return Convert.ToBoolean(aDataSet.Tables[0].Rows[0]["admin_status"]);
        }
    }
}
