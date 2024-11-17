using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_Demo
{
    public class Game
    {
        private int _id;
        private string _code;
        private int _numOfPlayers;

        public int Id { get => _id; set => _id = value; }
        public string Code { get => _code; set => _code = value; }
        public int NumOfPlayers { get => _numOfPlayers; set => _numOfPlayers = value; }
    }
}
