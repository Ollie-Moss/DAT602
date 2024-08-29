using MySql.Data.MySqlClient;

namespace DAT602_Demo
{
    public class GameplayDataAccess: DataAccess
    {
        public string TestGameplay()
        {
            var aDataSet = MySqlHelper.ExecuteDataset(DataAccess.mySqlConnection, "call GAMEPLAY_TEST()");

            // expecting one table with one row
            return (aDataSet.Tables[0].Rows[0])["MESSAGE"].ToString();
        }
    }
}
