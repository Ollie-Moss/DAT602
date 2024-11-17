namespace DAT602_Demo
{
    partial class AdminForm
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
            components = new System.ComponentModel.Container();
            _playersList = new DataGridView();
            Code = new DataGridViewTextBoxColumn();
            DisplayName = new DataGridViewTextBoxColumn();
            _activeGamesList = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            label3 = new Label();
            label1 = new Label();
            _killGameButton = new Button();
            _deletePlayerButton = new Button();
            _editPlayerButton = new Button();
            back_button = new Button();
            UpdateTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)_playersList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_activeGamesList).BeginInit();
            SuspendLayout();
            // 
            // _playersList
            // 
            _playersList.AllowUserToAddRows = false;
            _playersList.AllowUserToDeleteRows = false;
            _playersList.AllowUserToResizeColumns = false;
            _playersList.AllowUserToResizeRows = false;
            _playersList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _playersList.Columns.AddRange(new DataGridViewColumn[] { Code, DisplayName });
            _playersList.Location = new Point(441, 64);
            _playersList.MultiSelect = false;
            _playersList.Name = "_playersList";
            _playersList.RowHeadersVisible = false;
            _playersList.RowTemplate.Height = 25;
            _playersList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _playersList.Size = new Size(325, 230);
            _playersList.TabIndex = 16;
            // 
            // Code
            // 
            Code.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Code.DataPropertyName = "GameCode";
            Code.HeaderText = "Game Code";
            Code.Name = "Code";
            Code.ReadOnly = true;
            Code.Resizable = DataGridViewTriState.False;
            // 
            // DisplayName
            // 
            DisplayName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DisplayName.DataPropertyName = "DisplayName";
            DisplayName.HeaderText = "Display Name";
            DisplayName.Name = "DisplayName";
            DisplayName.ReadOnly = true;
            DisplayName.Resizable = DataGridViewTriState.False;
            // 
            // _activeGamesList
            // 
            _activeGamesList.AllowUserToAddRows = false;
            _activeGamesList.AllowUserToDeleteRows = false;
            _activeGamesList.AllowUserToResizeColumns = false;
            _activeGamesList.AllowUserToResizeRows = false;
            _activeGamesList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _activeGamesList.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            _activeGamesList.Location = new Point(38, 64);
            _activeGamesList.MultiSelect = false;
            _activeGamesList.Name = "_activeGamesList";
            _activeGamesList.RowHeadersVisible = false;
            _activeGamesList.RowTemplate.Height = 25;
            _activeGamesList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _activeGamesList.Size = new Size(310, 230);
            _activeGamesList.TabIndex = 17;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.DataPropertyName = "Code";
            dataGridViewTextBoxColumn1.HeaderText = "Code";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn2.DataPropertyName = "NumOfPlayers";
            dataGridViewTextBoxColumn2.HeaderText = "Number of Players";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Resizable = DataGridViewTriState.False;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(38, 36);
            label3.Name = "label3";
            label3.Size = new Size(130, 25);
            label3.TabIndex = 18;
            label3.Text = "Active Games";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(441, 36);
            label1.Name = "label1";
            label1.Size = new Size(75, 25);
            label1.TabIndex = 19;
            label1.Text = "Players";
            // 
            // _killGameButton
            // 
            _killGameButton.BackColor = Color.Firebrick;
            _killGameButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            _killGameButton.ForeColor = SystemColors.Control;
            _killGameButton.Location = new Point(38, 311);
            _killGameButton.Name = "_killGameButton";
            _killGameButton.Size = new Size(310, 40);
            _killGameButton.TabIndex = 20;
            _killGameButton.Text = "Kill Game";
            _killGameButton.UseVisualStyleBackColor = false;
            _killGameButton.Click += _killGameButton_Click;
            // 
            // _deletePlayerButton
            // 
            _deletePlayerButton.BackColor = Color.Firebrick;
            _deletePlayerButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            _deletePlayerButton.ForeColor = SystemColors.Control;
            _deletePlayerButton.Location = new Point(600, 311);
            _deletePlayerButton.Name = "_deletePlayerButton";
            _deletePlayerButton.Size = new Size(166, 40);
            _deletePlayerButton.TabIndex = 21;
            _deletePlayerButton.Text = "Delete Player";
            _deletePlayerButton.UseVisualStyleBackColor = false;
            _deletePlayerButton.Click += _deletePlayerButton_Click;
            // 
            // _editPlayerButton
            // 
            _editPlayerButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            _editPlayerButton.Location = new Point(441, 311);
            _editPlayerButton.Name = "_editPlayerButton";
            _editPlayerButton.Size = new Size(154, 40);
            _editPlayerButton.TabIndex = 22;
            _editPlayerButton.Text = "Edit Player";
            _editPlayerButton.UseVisualStyleBackColor = true;
            _editPlayerButton.Click += _editPlayerButton_Click;
            // 
            // back_button
            // 
            back_button.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            back_button.Location = new Point(38, 386);
            back_button.Name = "back_button";
            back_button.Size = new Size(154, 40);
            back_button.TabIndex = 23;
            back_button.Text = "Back";
            back_button.UseVisualStyleBackColor = true;
            back_button.Click += back_button_Click;
            // 
            // UpdateTimer
            // 
            UpdateTimer.Enabled = true;
            UpdateTimer.Interval = 1000;
            UpdateTimer.Tick += UpdateState;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(back_button);
            Controls.Add(_editPlayerButton);
            Controls.Add(_deletePlayerButton);
            Controls.Add(_killGameButton);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(_activeGamesList);
            Controls.Add(_playersList);
            Name = "AdminForm";
            Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)_playersList).EndInit();
            ((System.ComponentModel.ISupportInitialize)_activeGamesList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView _playersList;
        private DataGridView _activeGamesList;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private Label label3;
        private Label label1;
        private Button _killGameButton;
        private Button _deletePlayerButton;
        private Button _editPlayerButton;
        private Button back_button;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn DisplayName;
        private System.Windows.Forms.Timer UpdateTimer;
    }
}