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

        public Data ParseTables(DataSet dataSet)
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
    }

}

