namespace DAT602_Demo
{
    public partial class LoginAndRegistrationForm : Form
    {
        private LoginRegistrationDataAccess dao = new LoginRegistrationDataAccess();
        public LoginAndRegistrationForm()
        {
            InitializeComponent();
            var gameplayform = new GameplayForm();
            var adminform = new AdminForm();

            gameplayform.Show();
            adminform.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dao.TestLogin());
        }
    }
}
