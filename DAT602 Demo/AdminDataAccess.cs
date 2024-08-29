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
    }
}
