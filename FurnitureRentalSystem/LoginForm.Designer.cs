namespace FurnitureRentalSystem
{
    partial class loginForm
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
            this.userNameLoginLabel = new System.Windows.Forms.Label();
            this.passwordLoginLabel = new System.Windows.Forms.Label();
            this.userNameLoginTextBox = new System.Windows.Forms.TextBox();
            this.passwordLoginTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userNameLoginLabel
            // 
            this.userNameLoginLabel.AutoSize = true;
            this.userNameLoginLabel.Location = new System.Drawing.Point(22, 28);
            this.userNameLoginLabel.Name = "userNameLoginLabel";
            this.userNameLoginLabel.Size = new System.Drawing.Size(61, 13);
            this.userNameLoginLabel.TabIndex = 0;
            this.userNameLoginLabel.Text = "Username: ";
            // 
            // passwordLoginLabel
            // 
            this.passwordLoginLabel.AutoSize = true;
            this.passwordLoginLabel.Location = new System.Drawing.Point(22, 69);
            this.passwordLoginLabel.Name = "passwordLoginLabel";
            this.passwordLoginLabel.Size = new System.Drawing.Size(59, 13);
            this.passwordLoginLabel.TabIndex = 1;
            this.passwordLoginLabel.Text = "Password: ";
            // 
            // userNameLoginTextBox
            // 
            this.userNameLoginTextBox.Location = new System.Drawing.Point(87, 25);
            this.userNameLoginTextBox.Name = "userNameLoginTextBox";
            this.userNameLoginTextBox.Size = new System.Drawing.Size(100, 20);
            this.userNameLoginTextBox.TabIndex = 2;
            // 
            // passwordLoginTextBox
            // 
            this.passwordLoginTextBox.Location = new System.Drawing.Point(87, 66);
            this.passwordLoginTextBox.Name = "passwordLoginTextBox";
            this.passwordLoginTextBox.PasswordChar = '*';
            this.passwordLoginTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordLoginTextBox.TabIndex = 3;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(112, 107);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 155);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordLoginTextBox);
            this.Controls.Add(this.userNameLoginTextBox);
            this.Controls.Add(this.passwordLoginLabel);
            this.Controls.Add(this.userNameLoginLabel);
            this.Name = "loginForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userNameLoginLabel;
        private System.Windows.Forms.Label passwordLoginLabel;
        private System.Windows.Forms.TextBox userNameLoginTextBox;
        private System.Windows.Forms.TextBox passwordLoginTextBox;
        private System.Windows.Forms.Button loginButton;
    }
}