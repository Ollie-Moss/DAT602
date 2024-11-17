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
    public partial class ControlPanelForm : Form
    {
        //private LoginForm loginForm = new LoginForm();
        //private AdminForm adminForm = new AdminForm();
        //private GameplayForm gameplayForm = new GameplayForm();

        private LoginRegistrationDataAccess loginDAO = new LoginRegistrationDataAccess();
        private AdminDataAccess adminDAO = new AdminDataAccess();
        private GameplayDataAccess gameplayDAO = new GameplayDataAccess();

        private string usernameInput = "username123";
        private string emailInput = "email@example.com";
        private string passwordInput = "password123";

        private string gameCode = "ABCD";
        private int gameId = 1;
        private int mapSize = 100;

        private int playerId = 1;
        private int accountId = 1;

        private string message = "Message from me!";
        private string displayName = "My Name!";

        public ControlPanelForm()
        {
            InitializeComponent();

        }

        // Login Form Button
        private void button1_Click(object sender, EventArgs e)
        {
            //loginForm.ShowDialog();
        }

        // Admin Form Button
        private void button2_Click(object sender, EventArgs e)
        {
           // adminForm.ShowDialog();
        }

        // Gameplay Form Button
        private void button3_Click(object sender, EventArgs e)
        {
            //gameplayForm.ShowDialog();
        }

        // Login Button
        private void button4_Click(object sender, EventArgs e)
        {
            var result = loginDAO.Login(usernameInput, passwordInput);
            MessageBox.Show(result.Message);
        }

        // Register Button
        private void button5_Click(object sender, EventArgs e)
        {
            var result = loginDAO.Register(usernameInput, emailInput, passwordInput);
            MessageBox.Show(result.Message);
        }

        // Create Game Button
        private void button6_Click(object sender, EventArgs e)
        {
            var result = gameplayDAO.CreateGame(gameCode, mapSize);
            MessageBox.Show(result.Message);
        }

        // Kill Game Button
        private void button10_Click(object sender, EventArgs e)
        {
            var result = adminDAO.KillGame(gameId);
            MessageBox.Show(result.Message);
        }

        // Delete Account Button
        private void button8_Click(object sender, EventArgs e)
        {
            var result = adminDAO.DeleteAccount(accountId);
            MessageBox.Show(result.Message);
        }

        // Edit Account Button
        private void button7_Click(object sender, EventArgs e)
        {
            //var result = adminDAO.EditAccount(accountId, usernameInput, emailInput, passwordInput);
            //MessageBox.Show(result.Message);
        }

        // Join Game Button
        private void button9_Click(object sender, EventArgs e)
        {
            var result = gameplayDAO.JoinGame(gameCode, displayName, accountId);
        }

        // Remove Player (Leaving) Button
        private void button11_Click(object sender, EventArgs e)
        {
            var result = gameplayDAO.LeaveGame(playerId);
            MessageBox.Show(result.Message);
        }

        // Send Message Button
        private void button12_Click(object sender, EventArgs e)
        {
            var result = gameplayDAO.SendChat(playerId, message);
            MessageBox.Show(result.Message);
        }

        // Roll Dice Button
        private void button13_Click(object sender, EventArgs e)
        {
            var result = gameplayDAO.RollDice(playerId);
            MessageBox.Show(result);
        }

        // Pick Up Item Button
        private void button14_Click(object sender, EventArgs e)
        {
            var result = gameplayDAO.PickUpItem(playerId);
            MessageBox.Show(result.Message);
        }
    }
}
