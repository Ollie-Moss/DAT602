using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_Demo
{
    public class GameManager
    {
        private int _accountId;
        private int _playerId;
        private static GameManager _instance;

        public int AccountId { get => _accountId; set => _accountId = value; }
        public int PlayerId { get => _playerId; set => _playerId = value; }

        public static GameManager Instance {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }
                return _instance;
            }
        }

    }
}
