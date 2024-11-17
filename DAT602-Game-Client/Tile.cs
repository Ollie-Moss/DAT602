using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace DAT602_Demo
{
	public class Tile
	{
		private int _id;

        public PictureBox tilePic;
        public int Id { get => _id; set => _id = value; }

    }

    public class MoveTile: Tile
    {
        private int _distance;

        public int Distance { get => _distance; set => _distance = value; }
    }

    public class ItemTile: Tile
    {
        private int _itemId;
        private string _itemName;

        public int ItemId { get => _itemId; set => _itemId = value; }
        public string ItemName { get => _itemName; set => _itemName = value; }
    }

}
