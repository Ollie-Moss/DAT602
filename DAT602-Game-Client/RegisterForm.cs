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
            Data result = dao.Register(usernameInput.Text, emailInput.Text, QuickHash(passwordInput.Text));
            if(result.StatusCode == DataResult.OK)
            {
                result_label.ForeColor = Color.Green;
            }
            else if(result.StatusCode == DataResult.ERROR)
            {
                result_label.ForeColor = Color.Red;
            }
            result_label.Text = result.Message;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
