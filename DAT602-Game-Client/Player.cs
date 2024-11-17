using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_Demo
{
	public class Player
	{
		private int _id;
		private string gameCode;
		private int _tileId;
		private string? _displayName;
		private PictureBox playerIcon = new PictureBox();

        public int TileId { get => _tileId; set => _tileId = value; }
        public string DisplayName { get => _displayName; set => _displayName = value; }
        public int Id { get => _id; set => _id = value; }
        public PictureBox PlayerIcon { get => playerIcon; set => playerIcon = value; }
        public string GameCode { get => gameCode; set => gameCode = value; }
    }
}
