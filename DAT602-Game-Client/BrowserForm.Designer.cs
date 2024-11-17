namespace DAT602_Demo
{
    partial class BrowserForm
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
            _createGameButton = new Button();
            _joinGameButton = new Button();
            label1 = new Label();
            label2 = new Label();
            _codeInput = new TextBox();
            _backButton = new Button();
            _joinGameFromListButton = new Button();
            label3 = new Label();
            _displayNameInput = new TextBox();
            label4 = new Label();
            ActiveGamesList = new DataGridView();
            refreshButton = new Button();
            Code = new DataGridViewTextBoxColumn();
            PlayerCount = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)ActiveGamesList).BeginInit();
            SuspendLayout();
            // 
            // _createGameButton
            // 
            _createGameButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            _createGameButton.Location = new Point(54, 126);
            _createGameButton.Name = "_createGameButton";
            _createGameButton.Size = new Size(215, 40);
            _createGameButton.TabIndex = 5;
            _createGameButton.Text = "Create Game";
            _createGameButton.UseVisualStyleBackColor = true;
            _createGameButton.Click += _createGameButton_Click;
            // 
            // _joinGameButton
            // 
            _joinGameButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            _joinGameButton.Location = new Point(54, 187);
            _joinGameButton.Name = "_joinGameButton";
            _joinGameButton.Size = new Size(215, 40);
            _joinGameButton.TabIndex = 6;
            _joinGameButton.Text = "Join Game";
            _joinGameButton.UseVisualStyleBackColor = true;
            _joinGameButton.Click += _joinGameButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(153, 169);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 7;
            label1.Text = "or";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 236);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 8;
            label2.Text = "Code";
            // 
            // _codeInput
            // 
            _codeInput.Location = new Point(96, 233);
            _codeInput.Name = "_codeInput";
            _codeInput.Size = new Size(173, 23);
            _codeInput.TabIndex = 9;
            // 
            // _backButton
            // 
            _backButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            _backButton.Location = new Point(54, 387);
            _backButton.Name = "_backButton";
            _backButton.Size = new Size(107, 40);
            _backButton.TabIndex = 10;
            _backButton.Text = "Back";
            _backButton.UseVisualStyleBackColor = true;
            _backButton.Click += _backButton_Click;
            // 
            // _joinGameFromListButton
            // 
            _joinGameFromListButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            _joinGameFromListButton.Location = new Point(381, 341);
            _joinGameFromListButton.Name = "_joinGameFromListButton";
            _joinGameFromListButton.Size = new Size(233, 40);
            _joinGameFromListButton.TabIndex = 11;
            _joinGameFromListButton.Text = "Join";
            _joinGameFromListButton.UseVisualStyleBackColor = true;
            _joinGameFromListButton.Click += _joinGameFromListButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(500, 33);
            label3.Name = "label3";
            label3.Size = new Size(130, 25);
            label3.TabIndex = 12;
            label3.Text = "Active Games";
            // 
            // _displayNameInput
            // 
            _displayNameInput.Location = new Point(142, 91);
            _displayNameInput.Name = "_displayNameInput";
            _displayNameInput.Size = new Size(127, 23);
            _displayNameInput.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(56, 94);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 13;
            label4.Text = "Display Name";
            // 
            // ActiveGamesList
            // 
            ActiveGamesList.AllowUserToAddRows = false;
            ActiveGamesList.AllowUserToDeleteRows = false;
            ActiveGamesList.AllowUserToResizeColumns = false;
            ActiveGamesList.AllowUserToResizeRows = false;
            ActiveGamesList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ActiveGamesList.Columns.AddRange(new DataGridViewColumn[] { Code, PlayerCount });
            ActiveGamesList.Location = new Point(381, 77);
            ActiveGamesList.MultiSelect = false;
            ActiveGamesList.Name = "ActiveGamesList";
            ActiveGamesList.RowHeadersVisible = false;
            ActiveGamesList.RowTemplate.Height = 25;
            ActiveGamesList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ActiveGamesList.Size = new Size(387, 230);
            ActiveGamesList.TabIndex = 15;
            // 
            // refreshButton
            // 
            refreshButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            refreshButton.Location = new Point(620, 341);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(148, 40);
            refreshButton.TabIndex = 16;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // Code
            // 
            Code.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Code.DataPropertyName = "Code";
            Code.HeaderText = "Code";
            Code.Name = "Code";
            Code.ReadOnly = true;
            Code.Resizable = DataGridViewTriState.False;
            // 
            // PlayerCount
            // 
            PlayerCount.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PlayerCount.DataPropertyName = "NumOfPlayers";
            PlayerCount.HeaderText = "Number of Players";
            PlayerCount.Name = "PlayerCount";
            PlayerCount.ReadOnly = true;
            PlayerCount.Resizable = DataGridViewTriState.False;
            // 
            // BrowserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(refreshButton);
            Controls.Add(ActiveGamesList);
            Controls.Add(_displayNameInput);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(_joinGameFromListButton);
            Controls.Add(_backButton);
            Controls.Add(_codeInput);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(_joinGameButton);
            Controls.Add(_createGameButton);
            Name = "BrowserForm";
            Text = "Browser";
            ((System.ComponentModel.ISupportInitialize)ActiveGamesList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button _createGameButton;
        private Button _joinGameButton;
        private Label label1;
        private Label label2;
        private TextBox _codeInput;
        private Button _backButton;
        private Button _joinGameFromListButton;
        private Label label3;
        private TextBox _displayNameInput;
        private Label label4;
        private DataGridView ActiveGamesList;
        private Button refreshButton;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn PlayerCount;
    }
}