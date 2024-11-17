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
    public partial class MainMenuForm : Form
    {
        private AdminDataAccess adminDao = new AdminDataAccess();
        public MainMenuForm()
        {
            InitializeComponent();
            int accId = GameManager.Instance.AccountId?? -1;
            if (accId == -1 || !adminDao.IsAdmin(accId))
            {
                Controls.Remove(_managePlayersButton);
            }
        }

        private void _browseGamesButton_Click(object sender, EventArgs e)
        {
            BrowserForm browser = new BrowserForm();
            Hide();
            browser.ShowDialog();
            if(browser.DialogResult == DialogResult.Cancel)
            {
                Show();
            }
        }

        private void _exitButton_Click(object sender, EventArgs e)
        {
            Close();
            Environment.Exit(1);
        }

        private void _deleteAccountButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you wish to delete your account?", "Are you sure?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int accId = GameManager.Instance.AccountId?? -1;
                if (accId == -1) return;

                // Delete Account
                adminDao.DeleteAccount(accId);
                Close();
                GameManager.Instance.AccountId = null;
            }
        }

        private void _managePlayersButton_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            Hide();
            adminForm.ShowDialog();
            if(adminForm.DialogResult == DialogResult.Cancel)
            {
                Show();
            }
        }
    }
}
