using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_Demo
{
    public class GameManager
    {
        private Player _currentPlayer;
        private int? _accountId;

        private GameplayForm _gameplayForm;

        public Player CurrentPlayer { 
            get 
            {
                if (_currentPlayer == null)
                {
                    _currentPlayer = new Player();
                }
                return _currentPlayer;
            }
            set => _currentPlayer = value; 
        }


        public static GameplayDataAccess gameplayDataAccess = new GameplayDataAccess();

        private static GameManager _instance;
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
        

        public int? AccountId { get => _accountId; set => _accountId = value; }
        public GameplayForm GameplayForm { get => _gameplayForm; set => _gameplayForm = value; }

    }
}
