namespace DAT602_Demo
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _browseGamesButton = new Button();
            _exitButton = new Button();
            _deleteAccountButton = new Button();
            _managePlayersButton = new Button();
            SuspendLayout();
            // 
            // _browseGamesButton
            // 
            _browseGamesButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            _browseGamesButton.Location = new Point(317, 177);
            _browseGamesButton.Name = "_browseGamesButton";
            _browseGamesButton.Size = new Size(154, 40);
            _browseGamesButton.TabIndex = 5;
            _browseGamesButton.Text = "Browse Games";
            _browseGamesButton.UseVisualStyleBackColor = true;
            _browseGamesButton.Click += _browseGamesButton_Click;
            // 
            // _exitButton
            // 
            _exitButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            _exitButton.Location = new Point(317, 223);
            _exitButton.Name = "_exitButton";
            _exitButton.Size = new Size(154, 40);
            _exitButton.TabIndex = 6;
            _exitButton.Text = "Exit";
            _exitButton.UseVisualStyleBackColor = true;
            _exitButton.Click += _exitButton_Click;
            // 
            // _deleteAccountButton
            // 
            _deleteAccountButton.BackColor = Color.Firebrick;
            _deleteAccountButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            _deleteAccountButton.ForeColor = SystemColors.Control;
            _deleteAccountButton.Location = new Point(317, 269);
            _deleteAccountButton.Name = "_deleteAccountButton";
            _deleteAccountButton.Size = new Size(154, 40);
            _deleteAccountButton.TabIndex = 7;
            _deleteAccountButton.Text = "Delete Account";
            _deleteAccountButton.UseVisualStyleBackColor = false;
            _deleteAccountButton.Click += _deleteAccountButton_Click;
            // 
            // _managePlayersButton
            // 
            _managePlayersButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            _managePlayersButton.Location = new Point(317, 89);
            _managePlayersButton.Name = "_managePlayersButton";
            _managePlayersButton.Size = new Size(154, 40);
            _managePlayersButton.TabIndex = 8;
            _managePlayersButton.Text = "Manage Players";
            _managePlayersButton.UseVisualStyleBackColor = true;
            _managePlayersButton.Click += _managePlayersButton_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(_managePlayersButton);
            Controls.Add(_deleteAccountButton);
            Controls.Add(_exitButton);
            Controls.Add(_browseGamesButton);
            Name = "MainMenuForm";
            Text = "MainMenuForm";
            ResumeLayout(false);
        }

        #endregion

        private Button _browseGamesButton;
        private Button _exitButton;
        private Button _deleteAccountButton;
        private Button _managePlayersButton;
    }
}