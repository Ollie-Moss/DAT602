using System.Security.Cryptography;
using System.Text;

namespace DAT602_Demo
{
    public partial class LoginForm : Form
    {
        private LoginRegistrationDataAccess dao = new LoginRegistrationDataAccess();
        public LoginForm()
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
            var loginResult = dao.Login(usernameInput.Text, QuickHash(passwordInput.Text));
            if (loginResult.Response != null)
            {
                GameManager.Instance.PlayerId = (int) loginResult.Response;
            }
            MessageBox.Show(loginResult.Message + GameManager.Instance.PlayerId.ToString());
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            var form = new RegisterForm();
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.Manual;
            Hide();
            form.ShowDialog();
            Close();
        }
    }
}
