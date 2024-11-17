using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_Demo
{
    public class Chat
    {
        private string _playerName;
        private string text;
        private DateTime _timeSent;

        public string PlayerName { get => _playerName; set => _playerName = value; }
        public string Text { get => text; set => text = value; }
        public DateTime TimeSent { get => _timeSent; set => _timeSent = value; }
    }
}
