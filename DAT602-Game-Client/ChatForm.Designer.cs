namespace DAT602_Demo
{
    partial class ChatForm
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
            button1 = new Button();
            chatInput = new TextBox();
            button2 = new Button();
            chatList = new DataGridView();
            ChatUpdateTick = new System.Windows.Forms.Timer(components);
            User = new DataGridViewTextBoxColumn();
            Message = new DataGridViewTextBoxColumn();
            TimeSent = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)chatList).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(391, 330);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // chatInput
            // 
            chatInput.Location = new Point(33, 262);
            chatInput.Name = "chatInput";
            chatInput.Size = new Size(344, 23);
            chatInput.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(391, 262);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Send";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // chatList
            // 
            chatList.AllowUserToAddRows = false;
            chatList.AllowUserToDeleteRows = false;
            chatList.AllowUserToResizeColumns = false;
            chatList.AllowUserToResizeRows = false;
            chatList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            chatList.Columns.AddRange(new DataGridViewColumn[] { User, Message, TimeSent });
            chatList.Location = new Point(33, 23);
            chatList.MultiSelect = false;
            chatList.Name = "chatList";
            chatList.RowHeadersVisible = false;
            chatList.RowTemplate.Height = 25;
            chatList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            chatList.Size = new Size(433, 218);
            chatList.TabIndex = 18;
            // 
            // ChatUpdateTick
            // 
            ChatUpdateTick.Enabled = true;
            ChatUpdateTick.Tick += UpdateChatList;
            // 
            // User
            // 
            User.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            User.DataPropertyName = "PlayerName";
            User.HeaderText = "User";
            User.Name = "User";
            User.ReadOnly = true;
            User.Resizable = DataGridViewTriState.False;
            // 
            // Message
            // 
            Message.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Message.DataPropertyName = "Text";
            Message.HeaderText = "Message";
            Message.Name = "Message";
            Message.ReadOnly = true;
            Message.Resizable = DataGridViewTriState.False;
            // 
            // TimeSent
            // 
            TimeSent.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            TimeSent.DataPropertyName = "TimeSent";
            TimeSent.HeaderText = "Time Sent";
            TimeSent.Name = "TimeSent";
            TimeSent.ReadOnly = true;
            TimeSent.Resizable = DataGridViewTriState.False;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 365);
            Controls.Add(chatList);
            Controls.Add(button2);
            Controls.Add(chatInput);
            Controls.Add(button1);
            Name = "ChatForm";
            Text = "ChatForm";
            ((System.ComponentModel.ISupportInitialize)chatList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox chatInput;
        private Button button2;
        private DataGridView chatList;
        private System.Windows.Forms.Timer ChatUpdateTick;
        private DataGridViewTextBoxColumn User;
        private DataGridViewTextBoxColumn Message;
        private DataGridViewTextBoxColumn TimeSent;
    }
}