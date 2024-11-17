using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAT602_Demo
{
    public partial class PlayerDataForm : Form
    {
        
        private AdminDataAccess dao = new AdminDataAccess();
        private Player _currentPlayer;
        public PlayerDataForm(Player player)
        {
            _currentPlayer = player;

            InitializeComponent();
            displayNameInput.Text = _currentPlayer.DisplayName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dao.EditPlayer(_currentPlayer.Id, displayNameInput.Text);
            //update player
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
