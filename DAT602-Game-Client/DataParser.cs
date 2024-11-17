using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_Demo
{
    public class DataParser
    {
        
        private static DataParser _instance;

        public static DataParser Instance {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataParser();
                }
                return _instance;
            }
        }

        public static Data ParseResponse(DataSet dataSet)
        {
            Data data = new Data();
            if (dataSet.Tables.Count < 1) { return null; }

            if (dataSet.Tables[0].Columns.Contains("MESSAGE"))
            {
                data.Message = dataSet.Tables[0].Rows[0]["MESSAGE"].ToString();
            }
            if (dataSet.Tables[0].Columns.Contains("DATA"))
            {
                data.Response = dataSet.Tables[0].Rows[0]["DATA"];
            }
            if (dataSet.Tables[0].Columns.Contains("STATUS"))
            {
                data.StatusCode = (DataResult)(int) dataSet.Tables[0].Rows[0]["STATUS"];
            }

            return data;
        }

        public static Player ParsePlayerData(DataSet dataSet)
        {

            return new Player();
        }

        public static List<Tile> ParseTiles(DataSet dataSet)
        {
            var tiles = (from aResult in
                                    DataTableExtensions.AsEnumerable(dataSet.Tables[0])
                       select
                          new Tile
                          {
                              Id = Convert.ToInt32(aResult["tile_id"]),
                          }).ToList();
            return tiles; 
        }
    }

}

