﻿namespace FurnitureRentalSystem
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqlStatementLabel = new System.Windows.Forms.Label();
            this.sqlStatementTextBox = new System.Windows.Forms.TextBox();
            this.queryResultLabel = new System.Windows.Forms.Label();
            this.queryResultsListView = new System.Windows.Forms.ListView();
            this.clearButton = new System.Windows.Forms.Button();
            this.performBtn = new System.Windows.Forms.Button();
            this.errorMessageLabel = new System.Windows.Forms.Label();
            this.queryRadioButton = new System.Windows.Forms.RadioButton();
            this.nonQueryRadioButton = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logOut_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
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
            // sqlStatementLabel
            // 
            this.sqlStatementLabel.AutoSize = true;
            this.sqlStatementLabel.Location = new System.Drawing.Point(12, 30);
            this.sqlStatementLabel.Name = "sqlStatementLabel";
            this.sqlStatementLabel.Size = new System.Drawing.Size(82, 13);
            this.sqlStatementLabel.TabIndex = 4;
            this.sqlStatementLabel.Text = "SQL Statement:";
            // 
            // sqlStatementTextBox
            // 
            this.sqlStatementTextBox.Location = new System.Drawing.Point(15, 53);
            this.sqlStatementTextBox.Multiline = true;
            this.sqlStatementTextBox.Name = "sqlStatementTextBox";
            this.sqlStatementTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sqlStatementTextBox.Size = new System.Drawing.Size(259, 75);
            this.sqlStatementTextBox.TabIndex = 5;
            // 
            // queryResultLabel
            // 
            this.queryResultLabel.AutoSize = true;
            this.queryResultLabel.Location = new System.Drawing.Point(12, 131);
            this.queryResultLabel.Name = "queryResultLabel";
            this.queryResultLabel.Size = new System.Drawing.Size(45, 13);
            this.queryResultLabel.TabIndex = 6;
            this.queryResultLabel.Text = "Results:";
            // 
            // queryResultsListView
            // 
            this.queryResultsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.queryResultsListView.AutoArrange = false;
            this.queryResultsListView.FullRowSelect = true;
            this.queryResultsListView.GridLines = true;
            this.queryResultsListView.Location = new System.Drawing.Point(15, 147);
            this.queryResultsListView.Name = "queryResultsListView";
            this.queryResultsListView.Size = new System.Drawing.Size(457, 203);
            this.queryResultsListView.TabIndex = 7;
            this.queryResultsListView.TabStop = false;
            this.queryResultsListView.UseCompatibleStateImageBehavior = false;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(303, 118);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // performBtn
            // 
            this.performBtn.Location = new System.Drawing.Point(384, 118);
            this.performBtn.Name = "performBtn";
            this.performBtn.Size = new System.Drawing.Size(75, 23);
            this.performBtn.TabIndex = 9;
            this.performBtn.Text = "Perform";
            this.performBtn.UseVisualStyleBackColor = true;
            this.performBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // errorMessageLabel
            // 
            this.errorMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.errorMessageLabel.Location = new System.Drawing.Point(280, 30);
            this.errorMessageLabel.Name = "errorMessageLabel";
            this.errorMessageLabel.Size = new System.Drawing.Size(192, 70);
            this.errorMessageLabel.TabIndex = 10;
            this.errorMessageLabel.Text = "Error Message";
            this.errorMessageLabel.Visible = false;
            // 
            // queryRadioButton
            // 
            this.queryRadioButton.AutoSize = true;
            this.queryRadioButton.Checked = true;
            this.queryRadioButton.Location = new System.Drawing.Point(120, 28);
            this.queryRadioButton.Name = "queryRadioButton";
            this.queryRadioButton.Size = new System.Drawing.Size(53, 17);
            this.queryRadioButton.TabIndex = 11;
            this.queryRadioButton.TabStop = true;
            this.queryRadioButton.Text = "Query";
            this.queryRadioButton.UseVisualStyleBackColor = true;
            this.queryRadioButton.CheckedChanged += new System.EventHandler(this.queryRadioButton_CheckedChanged);
            // 
            // nonQueryRadioButton
            // 
            this.nonQueryRadioButton.AutoSize = true;
            this.nonQueryRadioButton.Location = new System.Drawing.Point(179, 28);
            this.nonQueryRadioButton.Name = "nonQueryRadioButton";
            this.nonQueryRadioButton.Size = new System.Drawing.Size(73, 17);
            this.nonQueryRadioButton.TabIndex = 12;
            this.nonQueryRadioButton.Text = "NonQuery";
            this.nonQueryRadioButton.UseVisualStyleBackColor = true;
            this.nonQueryRadioButton.CheckedChanged += new System.EventHandler(this.nonQueryRadioButton_CheckedChanged);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.Controls.Add(this.nonQueryRadioButton);
            this.Controls.Add(this.queryRadioButton);
            this.Controls.Add(this.errorMessageLabel);
            this.Controls.Add(this.performBtn);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.queryResultsListView);
            this.Controls.Add(this.queryResultLabel);
            this.Controls.Add(this.sqlStatementTextBox);
            this.Controls.Add(this.sqlStatementLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminForm";
            this.Text = "Administrator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label sqlStatementLabel;
        private System.Windows.Forms.TextBox sqlStatementTextBox;
        private System.Windows.Forms.Label queryResultLabel;
        private System.Windows.Forms.ListView queryResultsListView;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button performBtn;
        private System.Windows.Forms.Label errorMessageLabel;
        private System.Windows.Forms.RadioButton queryRadioButton;
        private System.Windows.Forms.RadioButton nonQueryRadioButton;

    }
}