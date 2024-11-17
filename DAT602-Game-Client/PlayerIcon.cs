using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_Demo
{
    public class PlayerIcon
    {
        private PictureBox _icon = new PictureBox();
        private Label _displayNameLabel = new Label();

        public PictureBox Icon { get => _icon; set => _icon = value; }
        public Label DisplayNameLabel { get => _displayNameLabel; set => _displayNameLabel = value; }
    }
}
