using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace DAT602_Demo
{
    public partial class LoginForm : Form
    {
        private LoginRegistrationDataAccess _dataAccess = new LoginRegistrationDataAccess();
        private ErrorProvider _errorProvider = new ErrorProvider();
        public LoginForm()
        {
            InitializeComponent();
            _errorProvider.BlinkRate = 0;
            _errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
        }
        string QuickHash(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var inputHash = SHA256.HashData(inputBytes);
            return Convert.ToHexString(inputHash);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginResult = _dataAccess.Login(usernameInput.Text, QuickHash(passwordInput.Text));
            if (loginResult.Response != null)
            {
                GameManager.Instance.AccountId = (int) loginResult.Response;
            }
            if(loginResult.StatusCode == DataResult.ERROR)
            {
                _errorProvider.SetError(usernameInput, loginResult.Message);
                _errorProvider.SetError(passwordInput, loginResult.Message);
            }
            if(loginResult.StatusCode == DataResult.OK)
            {
                MainMenuForm mainMenu = new MainMenuForm();
                mainMenu.Show();
                GameManager.Instance.CurrentPlayer.Id = (int) loginResult.Response;
                Debug.WriteLine($"Account Id: {GameManager.Instance.AccountId}");
            }
        }

        private void signupBtn_Click(object sender, EventArgs e)
        {
            var form = new RegisterForm();
            Hide();
            form.ShowDialog();
            if(form.DialogResult == DialogResult.Cancel)
            {
                Show();
            }
        }
    }
}
