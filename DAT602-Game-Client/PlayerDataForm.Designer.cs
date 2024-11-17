namespace DAT602_Demo
{
    partial class PlayerDataForm
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
            label1 = new Label();
            displayNameInput = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 70);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 7;
            label1.Text = "Display Name";
            // 
            // displayNameInput
            // 
            displayNameInput.Location = new Point(25, 88);
            displayNameInput.Name = "displayNameInput";
            displayNameInput.Size = new Size(143, 23);
            displayNameInput.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(142, 151);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 9;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(223, 151);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 10;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(20, 20);
            label3.Name = "label3";
            label3.Size = new Size(117, 21);
            label3.TabIndex = 11;
            label3.Text = "Editing Player";
            // 
            // PlayerDataForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 192);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(displayNameInput);
            Name = "PlayerDataForm";
            Text = "PlayerDataForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox displayNameInput;
        private Button button1;
        private Button button2;
        private Label label3;
    }
}