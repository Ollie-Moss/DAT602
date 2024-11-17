using Library.Forms;
using System.Data;
namespace DAT602_Demo
{
    public partial class GameplayForm : Form
    {
        private GameplayDataAccess dao = new GameplayDataAccess();
        private List<Tile> tiles = new List<Tile>();
        private Dictionary<int, PlayerIcon> playerIcons = new Dictionary<int, PlayerIcon>();


        private List<InventoryItem> currentItems = new List<InventoryItem>();
        private List<Player> currentPlayers = new List<Player>();

        public GameplayForm()
        {
            InitializeComponent();
            GameManager.Instance.GameplayForm = this;
            IntializeBoard();

            GameTick.Start();
        }

        private void IntializeBoard()
        {

            // Load board
            tiles = dao.GetAllTiles();
            List<MoveTile> moveTiles = dao.GetMoveTiles();
            List<ItemTile> itemTiles = dao.GetItemTiles();
            if (GameManager.Instance.CurrentPlayer == null || tiles == null) return;

            var row = 0;
            int col = 0;
            foreach (var item in tiles.Select((value, index) => new { index, value }))
            {
                var tile = item.value;
                var i = item.index;


                var columnIndex = i % 10;

                PictureBox currentTilePic = new PictureBox();

                if (i % 10 == 0)
                {
                    row++;
                }
                if (row % 2 == 0)
                {
                    // are moving right
                    col = 9 - columnIndex;
                }
                else
                {
                    // are moving left
                    col = columnIndex;
                }
                //Debug.WriteLine($"Col: {col}\nRow: {row}\nColIndex: {columnIndex}\nIndex:{i}");

                currentTilePic.BackColor = Color.Tomato;
                Label label = new Label();
                if (moveTiles.Where(moveTile => tile.Id == moveTile.Id).Count() > 0)
                {
                    var moveTile = moveTiles.Where(moveTile => tile.Id == moveTile.Id).First();
                    label.Text = moveTile.Distance.ToString();
                    if (moveTile.Distance > 0)
                    {
                        currentTilePic.BackColor = Color.Green;
                    }
                    else
                    {
                        currentTilePic.BackColor = Color.Red;
                    }
                }
                if (itemTiles.Where(itemTile => tile.Id == itemTile.Id).Count() > 0)
                {
                    currentTilePic.BackColor = Color.Pink;
                }
                currentTilePic.Width = (gameBoard.Width / 10) - 1;//20;
                currentTilePic.Height = (gameBoard.Height / 10) - 1; //20;

                Point tileLocation = new Point(col * (currentTilePic.Width + 1), gameBoard.Height - row * (currentTilePic.Height + 1));
                currentTilePic.Location = tileLocation;

                label.Location = new Point(tileLocation.X, tileLocation.Y);
                label.Size = currentTilePic.Size;
                label.BackColor = currentTilePic.BackColor;
                label.TextAlign = ContentAlignment.MiddleCenter;

                tile.tilePic = currentTilePic;

                gameBoard.Controls.Add(currentTilePic);
                gameBoard.Controls.Add(label);
                label.BringToFront();
            }
        }


        private void UpdateBoard()
        {
            //check if game is alive 
            //check win state
            if (dao.GetGameState())
            {
                dao.LeaveGame(GameManager.Instance.CurrentPlayer.Id);
                GameTick.Stop();
                Close();
                MessageBox.Show("GAME HAS BEEN COMPLETED");
                return;
            }

            UpdateInventoryList();
            UpdatePlayerCombobox();

            // update last roll
            last_roll_label.Text = $"Dice: {dao.GetLastRoll()}";

            List<Player> players = dao.GetPlayersInGame(GameManager.Instance.CurrentPlayer.Id);

            foreach (var player in players)
            {
                Tile playerTile = tiles.Where(tile => tile.Id == player.TileId).First();
                if (playerTile.Id == player.TileId && playerTile.tilePic != null)
                {
                    if (!playerIcons.ContainsKey(player.Id))
                    {
                        playerIcons[player.Id] = new PlayerIcon();
                    }

                    UpdatePlayerIcon(playerIcons[player.Id], player, playerTile);
                    foreach (int playerId in playerIcons.Keys.Where(id => !(players.Where(player => player.Id == id).Count() > 0)))
                    {
                        gameBoard.Controls.Remove(playerIcons[playerId].Icon);
                        gameBoard.Controls.Remove(playerIcons[playerId].DisplayNameLabel);
                        playerIcons.Remove(playerId);
                    }
                }
            }
        }

        private void UpdatePlayerIcon(PlayerIcon playerIcon, Player player, Tile playerTile)
        {
            PictureBox icon = playerIcon.Icon;
            icon.BackColor = Color.DarkRed;
            icon.Width = playerTile.tilePic.Width / 2;
            icon.Height = playerTile.tilePic.Height / 2;
            icon.Location = new Point(playerTile.tilePic.Location.X + playerTile.tilePic.Width / 4, playerTile.tilePic.Location.Y + playerTile.tilePic.Height / 4);

            Label label = playerIcon.DisplayNameLabel;
            label.Location = new Point(icon.Location.X - (label.Width-icon.Width)/2, icon.Location.Y - 30);
            label.BackColor = Color.Transparent;
            label.ForeColor = Color.Black;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Text = player.DisplayName;

            if (!gameBoard.Controls.Contains(icon))
            {
                gameBoard.Controls.Add(icon);
            }
            if (!gameBoard.Controls.Contains(label))
            {
                gameBoard.Controls.Add(label);
            }

            if (player.Id == GameManager.Instance.CurrentPlayer.Id)
            {
                icon.BackColor = Color.Blue;
            }

            icon.BringToFront();
            label.BringToFront();

        }

        // Roll Button
        private void Roll_Button_Click(object sender, EventArgs e)
        {
            string result = dao.RollDice(GameManager.Instance.CurrentPlayer.Id);
            if(result != null)
            {
                MessageBox.Show(result);
            }
        }

        private void UpdateGameState(object sender, EventArgs e)
        {
            UpdateBoard();
        }

        private void UpdateInventoryList()
        {
            List<InventoryItem> newList = dao.GetItems();

            var dummyItem = new InventoryItem() { Id = -11111 };
            if(currentItems.Count < 1)
            {
                currentItems.Add(dummyItem);
            }
            if(newList.Count < 1)
            {
                newList.Add(dummyItem);
            }


            if (!newList.All(newItem => currentItems.Where(curItem => curItem.Id == newItem.Id).Count() > 0))
            {
                currentItems.Remove(dummyItem);
                newList.Remove(dummyItem);

                inventoryList.AutoGenerateColumns = false;
                currentItems = newList;
                SortableBindingList<InventoryItem> items = new SortableBindingList<InventoryItem>(newList);
                inventoryList.DataSource = items;
            }
        }
        private void UpdatePlayerCombobox()
        {
            
            List<Player> newList = dao.GetPlayersInGame(GameManager.Instance.CurrentPlayer.Id)
                .Where(player => player.Id != GameManager.Instance.CurrentPlayer.Id)
                .ToList();

            var dummyPlayer = new Player() { Id = -11111 };
            if(currentPlayers.Count < 1)
            {
                currentPlayers.Add(dummyPlayer);
            }
            if(newList.Count < 1)
            {
                newList.Add(dummyPlayer);
            }
            
            if (!newList.All(newPlayer => currentPlayers.Where(curPlayer => curPlayer.Id == newPlayer.Id).Count() > 0))
            {
                currentPlayers.Remove(dummyPlayer);
                newList.Remove(dummyPlayer);

                _playersList.AutoGenerateColumns = false;
                currentPlayers = newList;
                SortableBindingList<Player> players = new SortableBindingList<Player>(newList);
                _playersList.DataSource = players ;
            }
        }
        private Player? GetSelectedPlayer()
        {
            if (_playersList.SelectedRows.Count > 0)
            {
                Player selectedPlayer = _playersList.SelectedRows[0].DataBoundItem as Player;
                return selectedPlayer;
            }
            return null;
        }
        private InventoryItem? GetSelectedItem()
        {
            if (inventoryList.SelectedRows.Count > 0)
            {
                InventoryItem selectedItem = inventoryList.SelectedRows[0].DataBoundItem as InventoryItem;
                return selectedItem;
            }
            return null;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            dao.LeaveGame(GameManager.Instance.CurrentPlayer.Id);
            GameTick.Enabled = false;
        }

        private void Leave_Game_Button_Click(object sender, EventArgs e)
        {
            dao.LeaveGame(GameManager.Instance.CurrentPlayer.Id);
            GameTick.Enabled = false;
            Close();
        }

        private void Chat_Button_Click(object sender, EventArgs e)
        {
            ChatForm chatForm = new ChatForm();
            chatForm.ShowDialog();
        }

        private void useOnSelfButton_Click(object sender, EventArgs e)
        {

            InventoryItem selectedItem = GetSelectedItem();
            if(selectedItem == null)
            {
                MessageBox.Show("You must select an item to use it!");
                return;
            }
            string message = dao.UseItem(selectedItem.Id, GameManager.Instance.CurrentPlayer.Id, GameManager.Instance.CurrentPlayer.Id);
            MessageBox.Show(message);
        }

        private void useOnPlayerButton_Click(object sender, EventArgs e)
        {
            InventoryItem selectedItem = GetSelectedItem();
            Player selectedPlayer = GetSelectedPlayer();

            if(selectedItem == null) 
            {
                MessageBox.Show("You must select an item to use it!");
                return;
            }
            if(selectedPlayer == null)
            {
                MessageBox.Show("You must select a player to use this item on!");
                return;
            }
            string message = dao.UseItem(selectedItem.Id, selectedPlayer.Id, GameManager.Instance.CurrentPlayer.Id);
            MessageBox.Show(message);
        }
    }
}
