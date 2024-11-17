using Library.Forms;
using System.Security.Cryptography;


namespace DAT602_Demo
{
    public partial class BrowserForm : Form
    {
        private GameplayDataAccess _dataAccess = new GameplayDataAccess();
        public BrowserForm()
        {
            InitializeComponent();
            UpdateGamesTable();
        }
        string get_unique_string(int string_length)
        {
            var bit_count = (string_length * 6);
            var byte_count = ((bit_count + 7) / 8); // rounded up
            var bytes = new byte[byte_count];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        private void _backButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void _createGameButton_Click(object sender, EventArgs e)
        {
            string code = get_unique_string(4).ToUpper();
            Data gameResult = _dataAccess.CreateGame(code, 100);

            if (gameResult.StatusCode == DataResult.OK)
            {
                JoinGame(code);
            }
        }

        private void _joinGameButton_Click(object sender, EventArgs e)
        {
            JoinGame(_codeInput.Text);
        }

        private void UpdateGamesTable()
        {
            ActiveGamesList.AutoGenerateColumns = false;
            SortableBindingList<Game> games = new SortableBindingList<Game>(_dataAccess.GetActiveGames());
            ActiveGamesList.DataSource = games;
        }

        private Game? GetSelectedGame()
        {
            if (ActiveGamesList.RowCount > 0)
            {
                // Get the selected index of the list and match to the game and then call join game with code
                Game selectedGame = ActiveGamesList.SelectedRows[0].DataBoundItem as Game;
                return selectedGame;
            }
            return null;
        }


        private void _joinGameFromListButton_Click(object sender, EventArgs e)
        {
            Game selectedGame = GetSelectedGame();
            if (selectedGame == null) return;
            JoinGame(selectedGame.Code);
        }

        private void JoinGame(string code)
        {
            int accId = GameManager.Instance.AccountId ?? -1;
            if (accId == -1) return;

            int joinGameResult = _dataAccess.JoinGame(code, _displayNameInput.Text, accId);

            if (joinGameResult == -1) return;
            GameManager.Instance.CurrentPlayer.Id = joinGameResult;
            OpenGamePlayForm();
        }

        private void OpenGamePlayForm()
        {

            GameplayForm gameplay = new GameplayForm();
            gameplay.Show();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            UpdateGamesTable();
        }
    }
}
