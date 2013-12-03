namespace FurnitureRentalSystem
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageRentals = new System.Windows.Forms.TabPage();
            this.searchRentalsButton = new System.Windows.Forms.Button();
            this.contentsListView = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contentsLabel = new System.Windows.Forms.Label();
            this.rentalsLabel = new System.Windows.Forms.Label();
            this.ordersListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toDateLabel = new System.Windows.Forms.Label();
            this.fromDateLabel = new System.Windows.Forms.Label();
            this.toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tabPageSQL = new System.Windows.Forms.TabPage();
            this.nonQueryRadioButton = new System.Windows.Forms.RadioButton();
            this.queryRadioButton = new System.Windows.Forms.RadioButton();
            this.errorMessageLabel = new System.Windows.Forms.Label();
            this.performBtn = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.queryResultsListView = new System.Windows.Forms.ListView();
            this.queryResultLabel = new System.Windows.Forms.Label();
            this.sqlStatementTextBox = new System.Windows.Forms.TextBox();
            this.sqlStatementLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageRentals.SuspendLayout();
            this.tabPageSQL.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(771, 24);
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageRentals);
            this.tabControl.Controls.Add(this.tabPageSQL);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(771, 567);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageRentals
            // 
            this.tabPageRentals.Controls.Add(this.searchRentalsButton);
            this.tabPageRentals.Controls.Add(this.contentsListView);
            this.tabPageRentals.Controls.Add(this.contentsLabel);
            this.tabPageRentals.Controls.Add(this.rentalsLabel);
            this.tabPageRentals.Controls.Add(this.ordersListView);
            this.tabPageRentals.Controls.Add(this.toDateLabel);
            this.tabPageRentals.Controls.Add(this.fromDateLabel);
            this.tabPageRentals.Controls.Add(this.toDateTimePicker);
            this.tabPageRentals.Controls.Add(this.fromDateTimePicker);
            this.tabPageRentals.Location = new System.Drawing.Point(4, 22);
            this.tabPageRentals.Name = "tabPageRentals";
            this.tabPageRentals.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRentals.Size = new System.Drawing.Size(479, 337);
            this.tabPageRentals.TabIndex = 0;
            this.tabPageRentals.Text = "Rentals";
            this.tabPageRentals.UseVisualStyleBackColor = true;
            // 
            // searchRentalsButton
            // 
            this.searchRentalsButton.Location = new System.Drawing.Point(377, 14);
            this.searchRentalsButton.Name = "searchRentalsButton";
            this.searchRentalsButton.Size = new System.Drawing.Size(75, 23);
            this.searchRentalsButton.TabIndex = 8;
            this.searchRentalsButton.Text = "Search";
            this.searchRentalsButton.UseVisualStyleBackColor = true;
            this.searchRentalsButton.Click += new System.EventHandler(this.searchRentalsButton_Click);
            // 
            // contentsListView
            // 
            this.contentsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.contentsListView.FullRowSelect = true;
            this.contentsListView.GridLines = true;
            this.contentsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.contentsListView.Location = new System.Drawing.Point(9, 214);
            this.contentsListView.MultiSelect = false;
            this.contentsListView.Name = "contentsListView";
            this.contentsListView.Size = new System.Drawing.Size(462, 115);
            this.contentsListView.TabIndex = 7;
            this.contentsListView.UseCompatibleStateImageBehavior = false;
            this.contentsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ID";
            this.columnHeader5.Width = 75;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Rental ID";
            this.columnHeader6.Width = 75;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Furniture Number";
            this.columnHeader7.Width = 125;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Due Date";
            this.columnHeader8.Width = 75;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Quantity";
            this.columnHeader9.Width = 75;
            // 
            // contentsLabel
            // 
            this.contentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentsLabel.AutoSize = true;
            this.contentsLabel.Location = new System.Drawing.Point(8, 198);
            this.contentsLabel.Name = "contentsLabel";
            this.contentsLabel.Size = new System.Drawing.Size(52, 13);
            this.contentsLabel.TabIndex = 6;
            this.contentsLabel.Text = "Contents:";
            // 
            // rentalsLabel
            // 
            this.rentalsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rentalsLabel.AutoSize = true;
            this.rentalsLabel.Location = new System.Drawing.Point(8, 52);
            this.rentalsLabel.Name = "rentalsLabel";
            this.rentalsLabel.Size = new System.Drawing.Size(46, 13);
            this.rentalsLabel.TabIndex = 5;
            this.rentalsLabel.Text = "Rentals:";
            // 
            // ordersListView
            // 
            this.ordersListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ordersListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ordersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.ordersListView.FullRowSelect = true;
            this.ordersListView.GridLines = true;
            this.ordersListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ordersListView.Location = new System.Drawing.Point(9, 68);
            this.ordersListView.MultiSelect = false;
            this.ordersListView.Name = "ordersListView";
            this.ordersListView.Size = new System.Drawing.Size(462, 115);
            this.ordersListView.TabIndex = 4;
            this.ordersListView.UseCompatibleStateImageBehavior = false;
            this.ordersListView.View = System.Windows.Forms.View.Details;
            this.ordersListView.DoubleClick += new System.EventHandler(this.ordersListView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Rental ID";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Customer ID";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Employee ID";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Rental Date";
            this.columnHeader4.Width = 100;
            // 
            // toDateLabel
            // 
            this.toDateLabel.AutoSize = true;
            this.toDateLabel.Location = new System.Drawing.Point(243, 19);
            this.toDateLabel.Name = "toDateLabel";
            this.toDateLabel.Size = new System.Drawing.Size(26, 13);
            this.toDateLabel.TabIndex = 3;
            this.toDateLabel.Text = "To: ";
            // 
            // fromDateLabel
            // 
            this.fromDateLabel.AutoSize = true;
            this.fromDateLabel.Location = new System.Drawing.Point(27, 19);
            this.fromDateLabel.Name = "fromDateLabel";
            this.fromDateLabel.Size = new System.Drawing.Size(108, 13);
            this.fromDateLabel.TabIndex = 2;
            this.fromDateLabel.Text = "Select Rentals From: ";
            // 
            // toDateTimePicker
            // 
            this.toDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.toDateTimePicker.Location = new System.Drawing.Point(273, 15);
            this.toDateTimePicker.Name = "toDateTimePicker";
            this.toDateTimePicker.Size = new System.Drawing.Size(100, 20);
            this.toDateTimePicker.TabIndex = 1;
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fromDateTimePicker.Location = new System.Drawing.Point(139, 15);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(100, 20);
            this.fromDateTimePicker.TabIndex = 0;
            // 
            // tabPageSQL
            // 
            this.tabPageSQL.Controls.Add(this.nonQueryRadioButton);
            this.tabPageSQL.Controls.Add(this.queryRadioButton);
            this.tabPageSQL.Controls.Add(this.errorMessageLabel);
            this.tabPageSQL.Controls.Add(this.performBtn);
            this.tabPageSQL.Controls.Add(this.clearButton);
            this.tabPageSQL.Controls.Add(this.queryResultsListView);
            this.tabPageSQL.Controls.Add(this.queryResultLabel);
            this.tabPageSQL.Controls.Add(this.sqlStatementTextBox);
            this.tabPageSQL.Controls.Add(this.sqlStatementLabel);
            this.tabPageSQL.Location = new System.Drawing.Point(4, 22);
            this.tabPageSQL.Name = "tabPageSQL";
            this.tabPageSQL.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSQL.Size = new System.Drawing.Size(763, 541);
            this.tabPageSQL.TabIndex = 1;
            this.tabPageSQL.Text = "SQL";
            this.tabPageSQL.UseVisualStyleBackColor = true;
            // 
            // nonQueryRadioButton
            // 
            this.nonQueryRadioButton.AutoSize = true;
            this.nonQueryRadioButton.Location = new System.Drawing.Point(172, 6);
            this.nonQueryRadioButton.Name = "nonQueryRadioButton";
            this.nonQueryRadioButton.Size = new System.Drawing.Size(73, 17);
            this.nonQueryRadioButton.TabIndex = 21;
            this.nonQueryRadioButton.Text = "NonQuery";
            this.nonQueryRadioButton.UseVisualStyleBackColor = true;
            this.nonQueryRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // queryRadioButton
            // 
            this.queryRadioButton.AutoSize = true;
            this.queryRadioButton.Checked = true;
            this.queryRadioButton.Location = new System.Drawing.Point(113, 6);
            this.queryRadioButton.Name = "queryRadioButton";
            this.queryRadioButton.Size = new System.Drawing.Size(53, 17);
            this.queryRadioButton.TabIndex = 20;
            this.queryRadioButton.TabStop = true;
            this.queryRadioButton.Text = "Query";
            this.queryRadioButton.UseVisualStyleBackColor = true;
            this.queryRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // errorMessageLabel
            // 
            this.errorMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.errorMessageLabel.Location = new System.Drawing.Point(378, 34);
            this.errorMessageLabel.Name = "errorMessageLabel";
            this.errorMessageLabel.Size = new System.Drawing.Size(192, 70);
            this.errorMessageLabel.TabIndex = 19;
            this.errorMessageLabel.Text = "Error Message";
            this.errorMessageLabel.Visible = false;
            // 
            // performBtn
            // 
            this.performBtn.Location = new System.Drawing.Point(576, 208);
            this.performBtn.Name = "performBtn";
            this.performBtn.Size = new System.Drawing.Size(75, 23);
            this.performBtn.TabIndex = 18;
            this.performBtn.Text = "Perform";
            this.performBtn.UseVisualStyleBackColor = true;
            this.performBtn.Click += new System.EventHandler(this.performBtn_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(495, 208);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 17;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // queryResultsListView
            // 
            this.queryResultsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queryResultsListView.AutoArrange = false;
            this.queryResultsListView.FullRowSelect = true;
            this.queryResultsListView.GridLines = true;
            this.queryResultsListView.Location = new System.Drawing.Point(3, 250);
            this.queryResultsListView.Name = "queryResultsListView";
            this.queryResultsListView.Size = new System.Drawing.Size(757, 288);
            this.queryResultsListView.TabIndex = 16;
            this.queryResultsListView.TabStop = false;
            this.queryResultsListView.UseCompatibleStateImageBehavior = false;
            this.queryResultsListView.View = System.Windows.Forms.View.Details;
            // 
            // queryResultLabel
            // 
            this.queryResultLabel.AutoSize = true;
            this.queryResultLabel.Location = new System.Drawing.Point(5, 234);
            this.queryResultLabel.Name = "queryResultLabel";
            this.queryResultLabel.Size = new System.Drawing.Size(45, 13);
            this.queryResultLabel.TabIndex = 15;
            this.queryResultLabel.Text = "Results:";
            // 
            // sqlStatementTextBox
            // 
            this.sqlStatementTextBox.Location = new System.Drawing.Point(8, 31);
            this.sqlStatementTextBox.Multiline = true;
            this.sqlStatementTextBox.Name = "sqlStatementTextBox";
            this.sqlStatementTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.sqlStatementTextBox.Size = new System.Drawing.Size(356, 200);
            this.sqlStatementTextBox.TabIndex = 14;
            // 
            // sqlStatementLabel
            // 
            this.sqlStatementLabel.AutoSize = true;
            this.sqlStatementLabel.Location = new System.Drawing.Point(5, 8);
            this.sqlStatementLabel.Name = "sqlStatementLabel";
            this.sqlStatementLabel.Size = new System.Drawing.Size(82, 13);
            this.sqlStatementLabel.TabIndex = 13;
            this.sqlStatementLabel.Text = "SQL Statement:";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 591);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(787, 629);
            this.Name = "AdminForm";
            this.Text = "Administrator";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageRentals.ResumeLayout(false);
            this.tabPageRentals.PerformLayout();
            this.tabPageSQL.ResumeLayout(false);
            this.tabPageSQL.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageRentals;
        private System.Windows.Forms.TabPage tabPageSQL;
        private System.Windows.Forms.RadioButton nonQueryRadioButton;
        private System.Windows.Forms.RadioButton queryRadioButton;
        private System.Windows.Forms.Label errorMessageLabel;
        private System.Windows.Forms.Button performBtn;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ListView queryResultsListView;
        private System.Windows.Forms.Label queryResultLabel;
        private System.Windows.Forms.TextBox sqlStatementTextBox;
        private System.Windows.Forms.Label sqlStatementLabel;
        private System.Windows.Forms.Label toDateLabel;
        private System.Windows.Forms.Label fromDateLabel;
        private System.Windows.Forms.DateTimePicker toDateTimePicker;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.ListView ordersListView;
        private System.Windows.Forms.ListView contentsListView;
        private System.Windows.Forms.Label contentsLabel;
        private System.Windows.Forms.Label rentalsLabel;
        private System.Windows.Forms.Button searchRentalsButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;

    }
}