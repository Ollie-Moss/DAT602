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

                return DataParser.ParseResponse(aDataSet);
        }

        public int JoinGame(string code, string displayName, int accountId)
        {
                List<MySqlParameter> p = new List<MySqlParameter>();
                var pCode = new MySqlParameter("@Code", MySqlDbType.VarChar, 4);
                var pDisplayName = new MySqlParameter("@DisplayName", MySqlDbType.VarChar, 100);
                var pAccount_id = new MySqlParameter("@AccountId", MySqlDbType.Int32);

                pCode.Value = code;
                pDisplayName.Value = displayName;
                pAccount_id.Value = accountId;

                p.Add(pCode);
                p.Add(pDisplayName);
                p.Add(pAccount_id);

                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call CreatePlayer(@Code, @DisplayName, @AccountId)", p.ToArray());


                if ((DataResult)aDataSet.Tables[0].Rows[0]["STATUS"] == DataResult.OK)
                {
                    return Convert.ToInt32(aDataSet.Tables[0].Rows[0]["player_id"]);
                }
                return -1;
        }

        public Data LeaveGame(int playerId)
        {
                List<MySqlParameter> p = new List<MySqlParameter>();
                var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int64);

                pPlayerId.Value = playerId;

                p.Add(pPlayerId);

                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call RemovePlayer(@PlayerId)", p.ToArray());
                return DataParser.ParseResponse(aDataSet);
        }


        public Data SendChat(int playerId, string message)
        {
                List<MySqlParameter> p = new List<MySqlParameter>();
                var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int64);
                var pMessage = new MySqlParameter("@Message", MySqlDbType.VarChar, 255);

                pPlayerId.Value = playerId;
                pMessage.Value = message;

                p.Add(pPlayerId);
                p.Add(pMessage);

                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call SendChat(@Message, @PlayerId)", p.ToArray());
                return DataParser.ParseResponse(aDataSet);
        }
        public List<Chat> GetChats(int playerId)
        {
                List<MySqlParameter> p = new List<MySqlParameter>();
                var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int64);

                pPlayerId.Value = playerId;

                p.Add(pPlayerId);

                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call GetChats(@PlayerId)", p.ToArray());
                var chats = (from aResult in
                                        DataTableExtensions.AsEnumerable(aDataSet.Tables[0])
                           select
                              new Chat 
                              {
                                  PlayerName = Convert.ToString(aResult["display_name"]),
                                  Text = Convert.ToString(aResult["text"]),
                                  TimeSent = Convert.ToDateTime(aResult["time_sent"])
                              }).ToList();
            return chats;
        }

        public string RollDice(int playerId)
        {
                List<MySqlParameter> p = new List<MySqlParameter>();
                var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int64);

                pPlayerId.Value = playerId;

                p.Add(pPlayerId);
                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call Roll(@PlayerId)", p.ToArray());

            if (aDataSet.Tables[0].Columns.Contains("move_error"))
            {

                return Convert.ToString(aDataSet.Tables[0].Rows[0]["move_error"]);
            }
            return null;
        }

        public Data PickUpItem(int playerId)
        {
                List<MySqlParameter> p = new List<MySqlParameter>();
                var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int64);

                pPlayerId.Value = playerId;

                p.Add(pPlayerId);
                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call PickUp(@PlayerId)", p.ToArray());
                return DataParser.ParseResponse(aDataSet);
        }

        public List<Tile> GetAllTiles()
        {

                List<MySqlParameter> p = new List<MySqlParameter>();
                var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int64);

                pPlayerId.Value = GameManager.Instance.CurrentPlayer.Id;

                p.Add(pPlayerId);
                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call GetAllTiles(@PlayerId)", p.ToArray());
                var tiles = (from aResult in
                                        DataTableExtensions.AsEnumerable(aDataSet.Tables[0])
                           select
                              new Tile
                              {
                                  Id = Convert.ToInt32(aResult["tile_id"]),
                              }).ToList();
                return tiles; 
        }
        public List<MoveTile> GetMoveTiles()
        {

                List<MySqlParameter> p = new List<MySqlParameter>();
                var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int64);

                pPlayerId.Value = GameManager.Instance.CurrentPlayer.Id;

                p.Add(pPlayerId);
                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call GetMoveTiles(@PlayerId)", p.ToArray());
                var tiles = (from aResult in
                                        DataTableExtensions.AsEnumerable(aDataSet.Tables[0])
                             select
                                new MoveTile
                                {
                                    Id = Convert.ToInt32(aResult["tile_id"]),
                                    Distance = Convert.ToInt32(aResult["distance"]),
                                }).ToList();
                return tiles;
        }

        public List<ItemTile> GetItemTiles()
        {

                List<MySqlParameter> p = new List<MySqlParameter>();
                var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int64);

                pPlayerId.Value = GameManager.Instance.CurrentPlayer.Id;

                p.Add(pPlayerId);
                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call GetItemTiles(@PlayerId)", p.ToArray());
                var tiles = (from aResult in
                                        DataTableExtensions.AsEnumerable(aDataSet.Tables[0])
                             select
                                new ItemTile
                                {
                                    Id = Convert.ToInt32(aResult["tile_id"]),
                                    ItemId = Convert.ToInt32(aResult["item_id"]),
                                    ItemName = Convert.ToString(aResult["name"])
                                }).ToList();
                return tiles;
        }
        public bool GetGameState()
        {
                List<MySqlParameter> p = new List<MySqlParameter>();
                var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int64);

                pPlayerId.Value = GameManager.Instance.CurrentPlayer.Id;

                p.Add(pPlayerId);

                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call GetGameState(@PlayerId)", p.ToArray());
                return Convert.ToBoolean(Convert.ToInt16(aDataSet.Tables[0].Rows[0]["completed"]));
        }

        public int GetPlayerPosition()
        {

                List<MySqlParameter> p = new List<MySqlParameter>();
                var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int32);

                pPlayerId.Value = GameManager.Instance.CurrentPlayer.Id;

                p.Add(pPlayerId);

                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call GetPlayerPosition(@PlayerId)", p.ToArray());
                var row = aDataSet.Tables[0].Rows[0];
                return Convert.ToInt32(row["tile_id"]);

        }

        public List<InventoryItem> GetItems()
        {
                List<MySqlParameter> p = new List<MySqlParameter>();
                var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int32);

                pPlayerId.Value = GameManager.Instance.CurrentPlayer.Id;

                p.Add(pPlayerId);

                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call GetItems(@PlayerId)", p.ToArray());

                var items = (from aResult in
                                        DataTableExtensions.AsEnumerable(aDataSet.Tables[0])
                           select
                              new InventoryItem 
                              {
                                  Id = Convert.ToInt32(aResult["item_id"]),
                                  DisplayName = Convert.ToString(aResult["name"]),
                                  Quantity = Convert.ToInt32(aResult["quantity"])
                              }).ToList();
                return items;
        }
        public List<Player> GetaAllPlayers()
        {
                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call GetAllPlayers()");
                var players = (from aResult in
                                        DataTableExtensions.AsEnumerable(aDataSet.Tables[0])
                           select
                              new Player 
                              {
                                  Id = Convert.ToInt32(aResult["player_id"]),
                                  GameCode = Convert.ToString(aResult["code"]),
                                  TileId = Convert.ToInt32(aResult["tile_id"]),
                                  DisplayName = Convert.ToString(aResult["display_name"])
                              }).ToList();
                return players;
        }

        public List<Player> GetPlayersInGame(int playerId)
        {
                List<MySqlParameter> p = new List<MySqlParameter>();
                var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int32);

                pPlayerId.Value = GameManager.Instance.CurrentPlayer.Id;

                p.Add(pPlayerId);

                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call GetPlayersInGame(@PlayerId)", p.ToArray());
                var players = (from aResult in
                                        DataTableExtensions.AsEnumerable(aDataSet.Tables[0])
                               select
                                  new Player
                                  {
                                      Id = Convert.ToInt32(aResult["player_id"]),
                                      TileId = Convert.ToInt32(aResult["tile_id"]),
                                      DisplayName = Convert.ToString(aResult["display_name"])
                                  }).ToList();
                return players;
        }

        public string GetLastRoll()
        {
                List<MySqlParameter> p = new List<MySqlParameter>();
                var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int32);

                pPlayerId.Value = GameManager.Instance.CurrentPlayer.Id;

                p.Add(pPlayerId);
                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call GetLastRoll(@PlayerId)", p.ToArray());

                return Convert.ToString(aDataSet.Tables[0].Rows[0]["last_roll"]);

        }

        public List<Game> GetActiveGames()
        {
                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call GetActiveGames()");
                var games = (from aResult in
                                        DataTableExtensions.AsEnumerable(aDataSet.Tables[0])
                             select
                                new Game
                                {
                                    Id = Convert.ToInt32(aResult["game_id"]),
                                    Code = Convert.ToString(aResult["code"]),
                                    NumOfPlayers = Convert.ToInt32(aResult["num_of_players"])
                                }).ToList();

                return games;
        }

        public string UseItem(int itemId, int targetId, int playerId)
        {
                List<MySqlParameter> p = new List<MySqlParameter>();
                var pPlayerId = new MySqlParameter("@PlayerId", MySqlDbType.Int32);
                var pTargetId = new MySqlParameter("@TargetId", MySqlDbType.Int32);
                var pItemId = new MySqlParameter("@ItemId", MySqlDbType.Int32);

                pPlayerId.Value = playerId;
                pTargetId.Value = targetId;
                pItemId.Value = itemId;

                p.Add(pTargetId);
                p.Add(pPlayerId);
                p.Add(pItemId);
                var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call UseItem(@ItemId, @PlayerId, @TargetId)", p.ToArray());
                return Convert.ToString(aDataSet.Tables[0].Rows[0]["MESSAGE"]);

        }



    }

}
