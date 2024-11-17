using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace DAT602_Demo
{
    public class InventoryItem
    {
        private int _id;
        private int _quantity;
        private string _displayName;

        public int Id { get => _id; set => _id = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public string DisplayName { get => _displayName; set => _displayName = value; }
    }
}
