
namespace DAT602_Demo
{
    partial class GameplayForm
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
            label1 = new Label();
            Leave_Game_Button = new Button();
            Chat_Button = new Button();
            Roll_Button = new Button();
            last_roll_label = new Label();
            gameBoard = new Panel();
            inventoryList = new DataGridView();
            DisplayName = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            useOnSelfButton = new Button();
            useOnPlayerButton = new Button();
            _playersList = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            GameTick = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)inventoryList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_playersList).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(546, 28);
            label1.Name = "label1";
            label1.Size = new Size(100, 25);
            label1.TabIndex = 1;
            label1.Text = "Inventory";
            // 
            // Leave_Game_Button
            // 
            Leave_Game_Button.BackColor = Color.Firebrick;
            Leave_Game_Button.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Leave_Game_Button.ForeColor = SystemColors.Control;
            Leave_Game_Button.Location = new Point(647, 387);
            Leave_Game_Button.Name = "Leave_Game_Button";
            Leave_Game_Button.Size = new Size(124, 40);
            Leave_Game_Button.TabIndex = 3;
            Leave_Game_Button.Text = "Leave Game";
            Leave_Game_Button.UseVisualStyleBackColor = false;
            Leave_Game_Button.Click += Leave_Game_Button_Click;
            // 
            // Chat_Button
            // 
            Chat_Button.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Chat_Button.Location = new Point(546, 387);
            Chat_Button.Name = "Chat_Button";
            Chat_Button.Size = new Size(95, 40);
            Chat_Button.TabIndex = 4;
            Chat_Button.Text = "Chat";
            Chat_Button.UseVisualStyleBackColor = true;
            Chat_Button.Click += Chat_Button_Click;
            // 
            // Roll_Button
            // 
            Roll_Button.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Roll_Button.Location = new Point(35, 387);
            Roll_Button.Name = "Roll_Button";
            Roll_Button.Size = new Size(95, 40);
            Roll_Button.TabIndex = 5;
            Roll_Button.Text = "Roll";
            Roll_Button.UseVisualStyleBackColor = true;
            Roll_Button.Click += Roll_Button_Click;
            // 
            // last_roll_label
            // 
            last_roll_label.AutoSize = true;
            last_roll_label.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            last_roll_label.Location = new Point(158, 394);
            last_roll_label.Name = "last_roll_label";
            last_roll_label.Size = new Size(71, 25);
            last_roll_label.TabIndex = 6;
            last_roll_label.Text = "Dice: 0";
            // 
            // gameBoard
            // 
            gameBoard.Location = new Point(35, 28);
            gameBoard.Name = "gameBoard";
            gameBoard.Size = new Size(486, 314);
            gameBoard.TabIndex = 7;
            // 
            // inventoryList
            // 
            inventoryList.AllowUserToAddRows = false;
            inventoryList.AllowUserToDeleteRows = false;
            inventoryList.AllowUserToResizeColumns = false;
            inventoryList.AllowUserToResizeRows = false;
            inventoryList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            inventoryList.Columns.AddRange(new DataGridViewColumn[] { DisplayName, Quantity });
            inventoryList.Location = new Point(546, 56);
            inventoryList.MultiSelect = false;
            inventoryList.Name = "inventoryList";
            inventoryList.RowHeadersVisible = false;
            inventoryList.RowTemplate.Height = 25;
            inventoryList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            inventoryList.Size = new Size(225, 197);
            inventoryList.TabIndex = 17;
            // 
            // DisplayName
            // 
            DisplayName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DisplayName.DataPropertyName = "DisplayName";
            DisplayName.HeaderText = "Name";
            DisplayName.Name = "DisplayName";
            DisplayName.ReadOnly = true;
            DisplayName.Resizable = DataGridViewTriState.False;
            // 
            // Quantity
            // 
            Quantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Quantity.DataPropertyName = "Quantity";
            Quantity.HeaderText = "Quantity";
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            Quantity.Resizable = DataGridViewTriState.False;
            // 
            // useOnSelfButton
            // 
            useOnSelfButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            useOnSelfButton.Location = new Point(546, 259);
            useOnSelfButton.Name = "useOnSelfButton";
            useOnSelfButton.Size = new Size(225, 28);
            useOnSelfButton.TabIndex = 18;
            useOnSelfButton.Text = "Use on self";
            useOnSelfButton.UseVisualStyleBackColor = true;
            useOnSelfButton.Click += useOnSelfButton_Click;
            // 
            // useOnPlayerButton
            // 
            useOnPlayerButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            useOnPlayerButton.Location = new Point(546, 293);
            useOnPlayerButton.Name = "useOnPlayerButton";
            useOnPlayerButton.Size = new Size(73, 28);
            useOnPlayerButton.TabIndex = 19;
            useOnPlayerButton.Text = "Use on";
            useOnPlayerButton.UseVisualStyleBackColor = true;
            useOnPlayerButton.Click += useOnPlayerButton_Click;
            // 
            // _playersList
            // 
            _playersList.AllowUserToAddRows = false;
            _playersList.AllowUserToDeleteRows = false;
            _playersList.AllowUserToResizeColumns = false;
            _playersList.AllowUserToResizeRows = false;
            _playersList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _playersList.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1 });
            _playersList.Location = new Point(625, 293);
            _playersList.MultiSelect = false;
            _playersList.Name = "_playersList";
            _playersList.RowHeadersVisible = false;
            _playersList.RowTemplate.Height = 25;
            _playersList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _playersList.Size = new Size(146, 49);
            _playersList.TabIndex = 20;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.DataPropertyName = "DisplayName";
            dataGridViewTextBoxColumn1.HeaderText = "Display Name";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.False;
            // 
            // GameTick
            // 
            GameTick.Interval = 125;
            GameTick.Tick += UpdateGameState;
            // 
            // GameplayForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(_playersList);
            Controls.Add(useOnPlayerButton);
            Controls.Add(useOnSelfButton);
            Controls.Add(inventoryList);
            Controls.Add(gameBoard);
            Controls.Add(last_roll_label);
            Controls.Add(Roll_Button);
            Controls.Add(Chat_Button);
            Controls.Add(Leave_Game_Button);
            Controls.Add(label1);
            Name = "GameplayForm";
            Text = "Gameplay";
            ((System.ComponentModel.ISupportInitialize)inventoryList).EndInit();
            ((System.ComponentModel.ISupportInitialize)_playersList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button Leave_Game_Button;
        private Button Chat_Button;
        private Button Roll_Button;
        private Label last_roll_label;
        private Panel gameBoard;
        private DataGridView inventoryList;
        private Button useOnSelfButton;
        private Button useOnPlayerButton;
        private DataGridViewTextBoxColumn DisplayName;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridView _playersList;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Timer GameTick;
    }
}