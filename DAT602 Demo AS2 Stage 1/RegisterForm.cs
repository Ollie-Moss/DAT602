using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAT602_Demo
{
    public partial class RegisterForm : Form
    {
        private LoginRegistrationDataAccess dao = new LoginRegistrationDataAccess();

        public RegisterForm()
        {
            InitializeComponent();
        }
        string QuickHash(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var inputHash = SHA256.HashData(inputBytes);
            return Convert.ToHexString(inputHash);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var result = dao.Register(usernameInput.Text, emailInput.Text, QuickHash(passwordInput.Text));
            MessageBox.Show(result.Message);
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            var form = new LoginForm();
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.Manual;
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
    }
}
