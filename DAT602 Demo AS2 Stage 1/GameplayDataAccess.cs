using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.Data;
using System.Diagnostics;

namespace DAT602_Demo
{
    public class GameplayDataAccess: DataAccess
    {
        public string TestGameplay()
        {
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call GAMEPLAY_TEST()");

            // expecting one table with one row
            return aDataSet.Tables[0].Rows[0]["MESSAGE"].ToString();
        }

        public Data CreateGame(string code, int mapSize)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var pCode = new MySqlParameter("@Code", MySqlDbType.VarChar, 4);
            var pMapSize = new MySqlParameter("@MapSize", MySqlDbType.Int64);

            pCode.Value = code;
            pMapSize.Value = mapSize;

            p.Add(pCode);
            p.Add(pMapSize);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call CreateGame(@Code, @MapSize)", p.ToArray());

            return DataParser.Instance.ParseTables(aDataSet);
        }

        public Data JoinGame(string code, string displayName, int accountId)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var pCode = new MySqlParameter("@Code", MySqlDbType.VarChar, 4);
            var pDisplayName = new MySqlParameter("@DisplayName", MySqlDbType.VarChar, 100);
            var pAccount_id = new MySqlParameter("@AccountId", MySqlDbType.Int64);

            pCode.Value = code;
            pDisplayName.Value = displayName;
            pAccount_id.Value = accountId;

            p.Add(pCode);
            p.Add(pDisplayName);
            p.Add(pAccount_id);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call CreatePlayer(@Code, @DisplayName, @AccountId)", p.ToArray());
            return DataParser.Instance.ParseTables(aDataSet);
        }

        public Data LeaveGame(int playerId)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int64);

            pPlayerId.Value = playerId;

            p.Add(pPlayerId);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call RemovePlayer(@PlayerId)", p.ToArray());
            return DataParser.Instance.ParseTables(aDataSet);
        }

        public Data SendMessage(int playerId, string message)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int64);
            var pMessage = new MySqlParameter("@Message", MySqlDbType.VarChar, 255);

            pPlayerId.Value = playerId;
            pMessage.Value = message;

            p.Add(pPlayerId);
            p.Add(pMessage);

            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call SendMessage(@Message, @PlayerId)", p.ToArray());
            return DataParser.Instance.ParseTables(aDataSet);
        }

        public Data RollDice(int playerId)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int64);

            pPlayerId.Value = playerId;

            p.Add(pPlayerId);
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call Roll(@PlayerId)", p.ToArray());

            return DataParser.Instance.ParseTables(aDataSet);
        }

        public Data PickUpItem(int playerId)
        {
            List<MySqlParameter> p = new List<MySqlParameter>();
            var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int64);

            pPlayerId.Value = playerId;

            p.Add(pPlayerId);
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call PickUp(@PlayerId)", p.ToArray());
            return DataParser.Instance.ParseTables(aDataSet);
        }

        // This is not a completed method will be used in final implementation
        public string Render()
        {
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call RENDER(1)");

            string result = "";
            foreach (DataRow row in aDataSet.Tables[0].Rows)
            {
                foreach (var cell in row.ItemArray)
                {
                    result += cell?.ToString();
                }
                result += "\n";
            }

            // expecting one table with one row
            return result;
        }
    }
}
