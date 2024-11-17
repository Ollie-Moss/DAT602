using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_Demo
{
    public enum DataResult
    {
        OK = 1001,
        ERROR = 1002,
    }
    public class Data
    {
        private DataResult _statusCode;
        private string _message;
        private object _response;

        public DataResult StatusCode { get => _statusCode; set => _statusCode = value; }
        public string Message { get => _message; set => _message = value; }
        public object Response { get => _response; set => _response= value; }
    }
}
