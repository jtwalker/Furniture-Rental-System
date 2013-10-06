namespace FurnitureRentalSystem
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.firstNameRegisterCustomerLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.firstNameSearchCustomerLabel = new System.Windows.Forms.Label();
            this.firstNameSearchCustomerTextBox = new System.Windows.Forms.TextBox();
            this.lastNameSearchCustomerLabel = new System.Windows.Forms.Label();
            this.lastNameSearchCustomerTextBox = new System.Windows.Forms.TextBox();
            this.phoneNumberSearchCustomerLabel = new System.Windows.Forms.Label();
            this.phoneNumberSearchCustomerTextBox = new System.Windows.Forms.TextBox();
            this.searchSearchCustomerButton = new System.Windows.Forms.Button();
            this.searchResultsSearchCustomerListView = new System.Windows.Forms.ListView();
            this.membershipIDSearchCustomerColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.firstNameSearchCustomerColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lastNameSearchCustomerColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.phoneNumberSearchCustomerColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(771, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(746, 470);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.firstNameRegisterCustomerLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(738, 444);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Register Customer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(108, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // firstNameRegisterCustomerLabel
            // 
            this.firstNameRegisterCustomerLabel.AutoSize = true;
            this.firstNameRegisterCustomerLabel.Location = new System.Drawing.Point(51, 21);
            this.firstNameRegisterCustomerLabel.Name = "firstNameRegisterCustomerLabel";
            this.firstNameRegisterCustomerLabel.Size = new System.Drawing.Size(57, 13);
            this.firstNameRegisterCustomerLabel.TabIndex = 0;
            this.firstNameRegisterCustomerLabel.Text = "First Name";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.searchResultsSearchCustomerListView);
            this.tabPage2.Controls.Add(this.searchSearchCustomerButton);
            this.tabPage2.Controls.Add(this.phoneNumberSearchCustomerTextBox);
            this.tabPage2.Controls.Add(this.phoneNumberSearchCustomerLabel);
            this.tabPage2.Controls.Add(this.lastNameSearchCustomerTextBox);
            this.tabPage2.Controls.Add(this.lastNameSearchCustomerLabel);
            this.tabPage2.Controls.Add(this.firstNameSearchCustomerTextBox);
            this.tabPage2.Controls.Add(this.firstNameSearchCustomerLabel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(738, 444);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Search For Customer ID";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // firstNameSearchCustomerLabel
            // 
            this.firstNameSearchCustomerLabel.AutoSize = true;
            this.firstNameSearchCustomerLabel.Location = new System.Drawing.Point(48, 26);
            this.firstNameSearchCustomerLabel.Name = "firstNameSearchCustomerLabel";
            this.firstNameSearchCustomerLabel.Size = new System.Drawing.Size(60, 13);
            this.firstNameSearchCustomerLabel.TabIndex = 0;
            this.firstNameSearchCustomerLabel.Text = "First Name:";
            // 
            // firstNameSearchCustomerTextBox
            // 
            this.firstNameSearchCustomerTextBox.Location = new System.Drawing.Point(114, 23);
            this.firstNameSearchCustomerTextBox.Name = "firstNameSearchCustomerTextBox";
            this.firstNameSearchCustomerTextBox.Size = new System.Drawing.Size(100, 20);
            this.firstNameSearchCustomerTextBox.TabIndex = 1;
            // 
            // lastNameSearchCustomerLabel
            // 
            this.lastNameSearchCustomerLabel.AutoSize = true;
            this.lastNameSearchCustomerLabel.Location = new System.Drawing.Point(51, 59);
            this.lastNameSearchCustomerLabel.Name = "lastNameSearchCustomerLabel";
            this.lastNameSearchCustomerLabel.Size = new System.Drawing.Size(61, 13);
            this.lastNameSearchCustomerLabel.TabIndex = 2;
            this.lastNameSearchCustomerLabel.Text = "Last Name:";
            // 
            // lastNameSearchCustomerTextBox
            // 
            this.lastNameSearchCustomerTextBox.Location = new System.Drawing.Point(114, 56);
            this.lastNameSearchCustomerTextBox.Name = "lastNameSearchCustomerTextBox";
            this.lastNameSearchCustomerTextBox.Size = new System.Drawing.Size(100, 20);
            this.lastNameSearchCustomerTextBox.TabIndex = 3;
            // 
            // phoneNumberSearchCustomerLabel
            // 
            this.phoneNumberSearchCustomerLabel.AutoSize = true;
            this.phoneNumberSearchCustomerLabel.Location = new System.Drawing.Point(281, 26);
            this.phoneNumberSearchCustomerLabel.Name = "phoneNumberSearchCustomerLabel";
            this.phoneNumberSearchCustomerLabel.Size = new System.Drawing.Size(81, 13);
            this.phoneNumberSearchCustomerLabel.TabIndex = 4;
            this.phoneNumberSearchCustomerLabel.Text = "Phone Number:";
            // 
            // phoneNumberSearchCustomerTextBox
            // 
            this.phoneNumberSearchCustomerTextBox.Location = new System.Drawing.Point(368, 23);
            this.phoneNumberSearchCustomerTextBox.Name = "phoneNumberSearchCustomerTextBox";
            this.phoneNumberSearchCustomerTextBox.Size = new System.Drawing.Size(100, 20);
            this.phoneNumberSearchCustomerTextBox.TabIndex = 5;
            // 
            // searchSearchCustomerButton
            // 
            this.searchSearchCustomerButton.Location = new System.Drawing.Point(393, 54);
            this.searchSearchCustomerButton.Name = "searchSearchCustomerButton";
            this.searchSearchCustomerButton.Size = new System.Drawing.Size(75, 23);
            this.searchSearchCustomerButton.TabIndex = 6;
            this.searchSearchCustomerButton.Text = "Search";
            this.searchSearchCustomerButton.UseVisualStyleBackColor = true;
            // 
            // searchResultsSearchCustomerListView
            // 
            this.searchResultsSearchCustomerListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchResultsSearchCustomerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.membershipIDSearchCustomerColumnHeader,
            this.firstNameSearchCustomerColumnHeader,
            this.lastNameSearchCustomerColumnHeader,
            this.phoneNumberSearchCustomerColumnHeader});
            this.searchResultsSearchCustomerListView.FullRowSelect = true;
            this.searchResultsSearchCustomerListView.GridLines = true;
            this.searchResultsSearchCustomerListView.Location = new System.Drawing.Point(7, 97);
            this.searchResultsSearchCustomerListView.Name = "searchResultsSearchCustomerListView";
            this.searchResultsSearchCustomerListView.Size = new System.Drawing.Size(725, 341);
            this.searchResultsSearchCustomerListView.TabIndex = 7;
            this.searchResultsSearchCustomerListView.UseCompatibleStateImageBehavior = false;
            this.searchResultsSearchCustomerListView.View = System.Windows.Forms.View.Details;
            // 
            // membershipIDSearchCustomerColumnHeader
            // 
            this.membershipIDSearchCustomerColumnHeader.Text = "Membership ID";
            this.membershipIDSearchCustomerColumnHeader.Width = 180;
            // 
            // firstNameSearchCustomerColumnHeader
            // 
            this.firstNameSearchCustomerColumnHeader.Text = "First Name";
            this.firstNameSearchCustomerColumnHeader.Width = 180;
            // 
            // lastNameSearchCustomerColumnHeader
            // 
            this.lastNameSearchCustomerColumnHeader.Text = "Last Name";
            this.lastNameSearchCustomerColumnHeader.Width = 180;
            // 
            // phoneNumberSearchCustomerColumnHeader
            // 
            this.phoneNumberSearchCustomerColumnHeader.Text = "Phone Number";
            this.phoneNumberSearchCustomerColumnHeader.Width = 180;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 509);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Furniture Rental System";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label firstNameRegisterCustomerLabel;
        private System.Windows.Forms.TextBox lastNameSearchCustomerTextBox;
        private System.Windows.Forms.Label lastNameSearchCustomerLabel;
        private System.Windows.Forms.TextBox firstNameSearchCustomerTextBox;
        private System.Windows.Forms.Label firstNameSearchCustomerLabel;
        private System.Windows.Forms.TextBox phoneNumberSearchCustomerTextBox;
        private System.Windows.Forms.Label phoneNumberSearchCustomerLabel;
        private System.Windows.Forms.ListView searchResultsSearchCustomerListView;
        private System.Windows.Forms.Button searchSearchCustomerButton;
        private System.Windows.Forms.ColumnHeader membershipIDSearchCustomerColumnHeader;
        private System.Windows.Forms.ColumnHeader firstNameSearchCustomerColumnHeader;
        private System.Windows.Forms.ColumnHeader lastNameSearchCustomerColumnHeader;
        private System.Windows.Forms.ColumnHeader phoneNumberSearchCustomerColumnHeader;
    }
}

