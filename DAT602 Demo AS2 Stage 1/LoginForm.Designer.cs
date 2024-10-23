using System.Net;
using System.Security.Cryptography;

namespace DAT602_Demo
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.

        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            usernameInput = new TextBox();
            passwordInput = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            signupBtn = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(226, 206);
            button1.Name = "button1";
            button1.Size = new Size(143, 23);
            button1.TabIndex = 3;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // usernameInput
            // 
            usernameInput.Location = new Point(226, 70);
            usernameInput.Name = "usernameInput";
            usernameInput.Size = new Size(143, 23);
            usernameInput.TabIndex = 1;
            // 
            // passwordInput
            // 
            passwordInput.Location = new Point(226, 159);
            passwordInput.Name = "passwordInput";
            passwordInput.Size = new Size(143, 23);
            passwordInput.TabIndex = 2;
            passwordInput.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(226, 52);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 3;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(226, 141);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(202, 243);
            label3.Name = "label3";
            label3.Size = new Size(131, 15);
            label3.TabIndex = 5;
            label3.Text = "Don't have an account?";
            // 
            // signupBtn
            // 
            signupBtn.AccessibleRole = AccessibleRole.Link;
            signupBtn.AutoSize = true;
            signupBtn.Cursor = Cursors.Hand;
            signupBtn.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point);
            signupBtn.ForeColor = Color.Blue;
            signupBtn.Location = new Point(339, 243);
            signupBtn.Name = "signupBtn";
            signupBtn.Size = new Size(50, 15);
            signupBtn.TabIndex = 4;
            signupBtn.Text = "Sign up.";
            signupBtn.Click += signupBtn_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(627, 287);
            Controls.Add(signupBtn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passwordInput);
            Controls.Add(usernameInput);
            Controls.Add(button1);
            Name = "LoginForm";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox usernameInput;
        private TextBox passwordInput;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label signupBtn;
    }
}
