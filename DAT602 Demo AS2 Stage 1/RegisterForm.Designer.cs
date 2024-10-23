namespace DAT602_Demo
{
    partial class RegisterForm
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
            label2 = new Label();
            label1 = new Label();
            passwordInput = new TextBox();
            usernameInput = new TextBox();
            button1 = new Button();
            label3 = new Label();
            emailInput = new TextBox();
            loginBtn = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(237, 150);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 9;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(237, 34);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 8;
            label1.Text = "Username";
            // 
            // passwordInput
            // 
            passwordInput.Location = new Point(237, 168);
            passwordInput.Name = "passwordInput";
            passwordInput.Size = new Size(143, 23);
            passwordInput.TabIndex = 3;
            // 
            // usernameInput
            // 
            usernameInput.Location = new Point(237, 52);
            usernameInput.Name = "usernameInput";
            usernameInput.Size = new Size(143, 23);
            usernameInput.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(237, 215);
            button1.Name = "button1";
            button1.Size = new Size(143, 23);
            button1.TabIndex = 4;
            button1.Text = "Register";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(237, 90);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 11;
            label3.Text = "Email";
            // 
            // emailInput
            // 
            emailInput.Location = new Point(237, 108);
            emailInput.Name = "emailInput";
            emailInput.Size = new Size(143, 23);
            emailInput.TabIndex = 2;
            // 
            // loginBtn
            // 
            loginBtn.AutoSize = true;
            loginBtn.Cursor = Cursors.Hand;
            loginBtn.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point);
            loginBtn.ForeColor = Color.Blue;
            loginBtn.Location = new Point(362, 252);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(40, 15);
            loginBtn.TabIndex = 13;
            loginBtn.Text = "Login.";
            loginBtn.Click += loginBtn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(217, 252);
            label4.Name = "label4";
            label4.Size = new Size(142, 15);
            label4.TabIndex = 12;
            label4.Text = "Already have an account?";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(627, 287);
            Controls.Add(loginBtn);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(emailInput);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passwordInput);
            Controls.Add(usernameInput);
            Controls.Add(button1);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private TextBox passwordInput;
        private TextBox usernameInput;
        private Button button1;
        private Label label3;
        private TextBox emailInput;
        private Label loginBtn;
        private Label label4;
    }
}