using Library.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAT602_Demo
{
    public partial class AdminForm : Form
    {
        private AdminDataAccess dao = new AdminDataAccess();
        private GameplayDataAccess gameplayDao = new GameplayDataAccess();
        public AdminForm()
        {
            InitializeComponent();

        }

        private Player? GetSelectedPlayer()
        {
            if (_playersList.RowCount > 0)
            {
                // Get the selected index of the list and match to the game and then call join game with code
                Player selectedPlayer = _playersList.SelectedRows[0].DataBoundItem as Player;
                return selectedPlayer;
            }
            return null;
        }
        private Game? GetSelectedGame()
        {
            if (_activeGamesList.RowCount > 0)
            {
                // Get the selected index of the list and match to the game and then call join game with code
                Game selectedGame = _activeGamesList.SelectedRows[0].DataBoundItem as Game;
                return selectedGame;
            }
            return null;
        }

        private void _editPlayerButton_Click(object sender, EventArgs e)
        {
            Player selectedPlayer = GetSelectedPlayer();
            if(selectedPlayer == null)
            {
                MessageBox.Show("You must select a player to edit!");
                return;
            }
            PlayerDataForm playerForm = new PlayerDataForm(selectedPlayer);
            playerForm.ShowDialog();
        }

        private void _deletePlayerButton_Click(object sender, EventArgs e)
        {
            Player selectedPlayer = GetSelectedPlayer();
            if(selectedPlayer == null)
            {
                MessageBox.Show("You must select a player to delete!");
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete this player?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Delete Account
                gameplayDao.LeaveGame(selectedPlayer.Id);
            }
        }

        private void _killGameButton_Click(object sender, EventArgs e)
        {
            Game selectedGame = GetSelectedGame();
            if(selectedGame == null)
            {
                MessageBox.Show("You must select a game to kill!");
                return;
            }
            if (MessageBox.Show("Are you sure you wish to kill this game?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Delete Account
                dao.KillGame(selectedGame.Id);
            }
        }

        private void UpdateState(object sender, EventArgs e)
        {
            UpdatePlayersList();
            UpdateGamesList();
        }
        private void UpdatePlayersList()
        {
            _playersList.AutoGenerateColumns = false;
            SortableBindingList<Player> players = new SortableBindingList<Player>(gameplayDao.GetaAllPlayers());
            _playersList.DataSource = players;
        }
        private void UpdateGamesList()
        {
            _activeGamesList.AutoGenerateColumns = false;
            SortableBindingList<Game> games = new SortableBindingList<Game>(gameplayDao.GetActiveGames());
            _activeGamesList.DataSource = games;
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            UpdateTimer.Enabled = false;
            Close();
        }
    }
}
