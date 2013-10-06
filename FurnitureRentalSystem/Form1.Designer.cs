﻿namespace FurnitureRentalSystem
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchForCustomerIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.registerCustomerTab = new System.Windows.Forms.TabPage();
            this.searchForCustomerIDTab = new System.Windows.Forms.TabPage();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.firstNameRegisterCustomerLabel = new System.Windows.Forms.Label();
            this.middleNameRegisterCustomerLabel = new System.Windows.Forms.Label();
            this.stateRegisterCustomerMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.firstNameRegisterCustomerTextBox = new System.Windows.Forms.TextBox();
            this.middleNameRegisterCustomerTextBox = new System.Windows.Forms.TextBox();
            this.lastNameRegisterCustomerLabel = new System.Windows.Forms.Label();
            this.lastNameRegisterCustomerTextBox = new System.Windows.Forms.TextBox();
            this.streetAddressRegisterCustomerlabel = new System.Windows.Forms.Label();
            this.streetAddressRegisterCustomerTextBox = new System.Windows.Forms.TextBox();
            this.cityRegisterCustomerlabel = new System.Windows.Forms.Label();
            this.cityRegisterCustomerTextBox = new System.Windows.Forms.TextBox();
            this.stateRegisterCustomerlabel = new System.Windows.Forms.Label();
            this.zipCodeRegisterCustomerlabel = new System.Windows.Forms.Label();
            this.zipCodeRegisterCustomerMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.ssnRegisterCustomerLabel = new System.Windows.Forms.Label();
            this.ssnRegisterCustomerMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.phoneRegisterCustomerLabel = new System.Windows.Forms.Label();
            this.phoneRegisterCustomerMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.registerCustomerButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.registerCustomerTab.SuspendLayout();
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
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registerCustomerToolStripMenuItem,
            this.searchForCustomerIDToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // registerCustomerToolStripMenuItem
            // 
            this.registerCustomerToolStripMenuItem.Name = "registerCustomerToolStripMenuItem";
            this.registerCustomerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.registerCustomerToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.registerCustomerToolStripMenuItem.Text = "Register Customer";
            this.registerCustomerToolStripMenuItem.Click += new System.EventHandler(this.registerCustomerToolStripMenuItem_Click);
            // 
            // searchForCustomerIDToolStripMenuItem
            // 
            this.searchForCustomerIDToolStripMenuItem.Name = "searchForCustomerIDToolStripMenuItem";
            this.searchForCustomerIDToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.searchForCustomerIDToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.searchForCustomerIDToolStripMenuItem.Text = "Search For Customer ID";
            this.searchForCustomerIDToolStripMenuItem.Click += new System.EventHandler(this.searchForCustomerIDToolStripMenuItem_Click);
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
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.CausesValidation = false;
            this.tabControl.Controls.Add(this.registerCustomerTab);
            this.tabControl.Controls.Add(this.searchForCustomerIDTab);
            this.tabControl.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabControl.Location = new System.Drawing.Point(13, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(746, 552);
            this.tabControl.TabIndex = 1;
            // 
            // registerCustomerTab
            // 
            this.registerCustomerTab.CausesValidation = false;
            this.registerCustomerTab.Controls.Add(this.clearButton);
            this.registerCustomerTab.Controls.Add(this.registerCustomerButton);
            this.registerCustomerTab.Controls.Add(this.phoneRegisterCustomerMaskedTextBox);
            this.registerCustomerTab.Controls.Add(this.phoneRegisterCustomerLabel);
            this.registerCustomerTab.Controls.Add(this.ssnRegisterCustomerMaskedTextBox);
            this.registerCustomerTab.Controls.Add(this.ssnRegisterCustomerLabel);
            this.registerCustomerTab.Controls.Add(this.zipCodeRegisterCustomerMaskedTextBox);
            this.registerCustomerTab.Controls.Add(this.zipCodeRegisterCustomerlabel);
            this.registerCustomerTab.Controls.Add(this.stateRegisterCustomerlabel);
            this.registerCustomerTab.Controls.Add(this.cityRegisterCustomerTextBox);
            this.registerCustomerTab.Controls.Add(this.cityRegisterCustomerlabel);
            this.registerCustomerTab.Controls.Add(this.streetAddressRegisterCustomerTextBox);
            this.registerCustomerTab.Controls.Add(this.streetAddressRegisterCustomerlabel);
            this.registerCustomerTab.Controls.Add(this.lastNameRegisterCustomerTextBox);
            this.registerCustomerTab.Controls.Add(this.lastNameRegisterCustomerLabel);
            this.registerCustomerTab.Controls.Add(this.middleNameRegisterCustomerTextBox);
            this.registerCustomerTab.Controls.Add(this.firstNameRegisterCustomerTextBox);
            this.registerCustomerTab.Controls.Add(this.stateRegisterCustomerMaskedTextBox);
            this.registerCustomerTab.Controls.Add(this.middleNameRegisterCustomerLabel);
            this.registerCustomerTab.Controls.Add(this.firstNameRegisterCustomerLabel);
            this.registerCustomerTab.Location = new System.Drawing.Point(4, 22);
            this.registerCustomerTab.Name = "registerCustomerTab";
            this.registerCustomerTab.Padding = new System.Windows.Forms.Padding(3);
            this.registerCustomerTab.Size = new System.Drawing.Size(738, 526);
            this.registerCustomerTab.TabIndex = 0;
            this.registerCustomerTab.Text = "Register Customer";
            this.registerCustomerTab.UseVisualStyleBackColor = true;
            // 
            // searchForCustomerIDTab
            // 
            this.searchForCustomerIDTab.CausesValidation = false;
            this.searchForCustomerIDTab.Location = new System.Drawing.Point(4, 22);
            this.searchForCustomerIDTab.Name = "searchForCustomerIDTab";
            this.searchForCustomerIDTab.Padding = new System.Windows.Forms.Padding(3);
            this.searchForCustomerIDTab.Size = new System.Drawing.Size(738, 526);
            this.searchForCustomerIDTab.TabIndex = 1;
            this.searchForCustomerIDTab.Text = "Search For Customer ID";
            this.searchForCustomerIDTab.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // firstNameRegisterCustomerLabel
            // 
            this.firstNameRegisterCustomerLabel.AutoSize = true;
            this.firstNameRegisterCustomerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstNameRegisterCustomerLabel.Location = new System.Drawing.Point(104, 62);
            this.firstNameRegisterCustomerLabel.Name = "firstNameRegisterCustomerLabel";
            this.firstNameRegisterCustomerLabel.Size = new System.Drawing.Size(60, 13);
            this.firstNameRegisterCustomerLabel.TabIndex = 0;
            this.firstNameRegisterCustomerLabel.Text = "First Name:";
            // 
            // middleNameRegisterCustomerLabel
            // 
            this.middleNameRegisterCustomerLabel.AutoSize = true;
            this.middleNameRegisterCustomerLabel.Location = new System.Drawing.Point(92, 111);
            this.middleNameRegisterCustomerLabel.Name = "middleNameRegisterCustomerLabel";
            this.middleNameRegisterCustomerLabel.Size = new System.Drawing.Size(72, 13);
            this.middleNameRegisterCustomerLabel.TabIndex = 4;
            this.middleNameRegisterCustomerLabel.Text = "Middle Name:";
            // 
            // stateRegisterCustomerMaskedTextBox
            // 
            this.stateRegisterCustomerMaskedTextBox.Location = new System.Drawing.Point(427, 258);
            this.stateRegisterCustomerMaskedTextBox.Mask = ">LL";
            this.stateRegisterCustomerMaskedTextBox.Name = "stateRegisterCustomerMaskedTextBox";
            this.stateRegisterCustomerMaskedTextBox.PromptChar = ' ';
            this.stateRegisterCustomerMaskedTextBox.ResetOnSpace = false;
            this.stateRegisterCustomerMaskedTextBox.Size = new System.Drawing.Size(34, 20);
            this.stateRegisterCustomerMaskedTextBox.TabIndex = 13;
            this.stateRegisterCustomerMaskedTextBox.Tag = "";
            this.stateRegisterCustomerMaskedTextBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.letterMask_MaskInputRejected);
            this.stateRegisterCustomerMaskedTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.maskedTextBox_MouseClick);
            this.stateRegisterCustomerMaskedTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaskedTextBox_KeyDown);
            this.stateRegisterCustomerMaskedTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.maskedTextBox_Validating);
            // 
            // firstNameRegisterCustomerTextBox
            // 
            this.firstNameRegisterCustomerTextBox.Location = new System.Drawing.Point(187, 59);
            this.firstNameRegisterCustomerTextBox.Name = "firstNameRegisterCustomerTextBox";
            this.firstNameRegisterCustomerTextBox.Size = new System.Drawing.Size(402, 20);
            this.firstNameRegisterCustomerTextBox.TabIndex = 3;
            this.firstNameRegisterCustomerTextBox.Tag = "";
            this.firstNameRegisterCustomerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.firstNameRegisterCustomerTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxEmpty_Validating);
            // 
            // middleNameRegisterCustomerTextBox
            // 
            this.middleNameRegisterCustomerTextBox.Location = new System.Drawing.Point(187, 108);
            this.middleNameRegisterCustomerTextBox.Name = "middleNameRegisterCustomerTextBox";
            this.middleNameRegisterCustomerTextBox.Size = new System.Drawing.Size(402, 20);
            this.middleNameRegisterCustomerTextBox.TabIndex = 5;
            this.middleNameRegisterCustomerTextBox.Tag = "";
            this.middleNameRegisterCustomerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // lastNameRegisterCustomerLabel
            // 
            this.lastNameRegisterCustomerLabel.AutoSize = true;
            this.lastNameRegisterCustomerLabel.Location = new System.Drawing.Point(103, 159);
            this.lastNameRegisterCustomerLabel.Name = "lastNameRegisterCustomerLabel";
            this.lastNameRegisterCustomerLabel.Size = new System.Drawing.Size(61, 13);
            this.lastNameRegisterCustomerLabel.TabIndex = 6;
            this.lastNameRegisterCustomerLabel.Text = "Last Name:";
            // 
            // lastNameRegisterCustomerTextBox
            // 
            this.lastNameRegisterCustomerTextBox.Location = new System.Drawing.Point(187, 156);
            this.lastNameRegisterCustomerTextBox.Name = "lastNameRegisterCustomerTextBox";
            this.lastNameRegisterCustomerTextBox.Size = new System.Drawing.Size(402, 20);
            this.lastNameRegisterCustomerTextBox.TabIndex = 7;
            this.lastNameRegisterCustomerTextBox.Tag = "";
            this.lastNameRegisterCustomerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.lastNameRegisterCustomerTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxEmpty_Validating);
            // 
            // streetAddressRegisterCustomerlabel
            // 
            this.streetAddressRegisterCustomerlabel.AutoSize = true;
            this.streetAddressRegisterCustomerlabel.Location = new System.Drawing.Point(85, 208);
            this.streetAddressRegisterCustomerlabel.Name = "streetAddressRegisterCustomerlabel";
            this.streetAddressRegisterCustomerlabel.Size = new System.Drawing.Size(79, 13);
            this.streetAddressRegisterCustomerlabel.TabIndex = 8;
            this.streetAddressRegisterCustomerlabel.Text = "Street Address:";
            // 
            // streetAddressRegisterCustomerTextBox
            // 
            this.streetAddressRegisterCustomerTextBox.Location = new System.Drawing.Point(187, 205);
            this.streetAddressRegisterCustomerTextBox.Name = "streetAddressRegisterCustomerTextBox";
            this.streetAddressRegisterCustomerTextBox.Size = new System.Drawing.Size(402, 20);
            this.streetAddressRegisterCustomerTextBox.TabIndex = 9;
            this.streetAddressRegisterCustomerTextBox.Tag = "";
            this.streetAddressRegisterCustomerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.streetAddressRegisterCustomerTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxEmpty_Validating);
            // 
            // cityRegisterCustomerlabel
            // 
            this.cityRegisterCustomerlabel.AutoSize = true;
            this.cityRegisterCustomerlabel.Location = new System.Drawing.Point(137, 261);
            this.cityRegisterCustomerlabel.Name = "cityRegisterCustomerlabel";
            this.cityRegisterCustomerlabel.Size = new System.Drawing.Size(27, 13);
            this.cityRegisterCustomerlabel.TabIndex = 10;
            this.cityRegisterCustomerlabel.Text = "City:";
            // 
            // cityRegisterCustomerTextBox
            // 
            this.cityRegisterCustomerTextBox.Location = new System.Drawing.Point(187, 258);
            this.cityRegisterCustomerTextBox.Name = "cityRegisterCustomerTextBox";
            this.cityRegisterCustomerTextBox.Size = new System.Drawing.Size(180, 20);
            this.cityRegisterCustomerTextBox.TabIndex = 11;
            this.cityRegisterCustomerTextBox.Tag = "";
            this.cityRegisterCustomerTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            this.cityRegisterCustomerTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxEmpty_Validating);
            // 
            // stateRegisterCustomerlabel
            // 
            this.stateRegisterCustomerlabel.AutoSize = true;
            this.stateRegisterCustomerlabel.Location = new System.Drawing.Point(386, 261);
            this.stateRegisterCustomerlabel.Name = "stateRegisterCustomerlabel";
            this.stateRegisterCustomerlabel.Size = new System.Drawing.Size(35, 13);
            this.stateRegisterCustomerlabel.TabIndex = 12;
            this.stateRegisterCustomerlabel.Text = "State:";
            // 
            // zipCodeRegisterCustomerlabel
            // 
            this.zipCodeRegisterCustomerlabel.AutoSize = true;
            this.zipCodeRegisterCustomerlabel.Location = new System.Drawing.Point(479, 261);
            this.zipCodeRegisterCustomerlabel.Name = "zipCodeRegisterCustomerlabel";
            this.zipCodeRegisterCustomerlabel.Size = new System.Drawing.Size(55, 13);
            this.zipCodeRegisterCustomerlabel.TabIndex = 14;
            this.zipCodeRegisterCustomerlabel.Text = "ZIP Code:";
            // 
            // zipCodeRegisterCustomerMaskedTextBox
            // 
            this.zipCodeRegisterCustomerMaskedTextBox.Location = new System.Drawing.Point(540, 258);
            this.zipCodeRegisterCustomerMaskedTextBox.Mask = "00000";
            this.zipCodeRegisterCustomerMaskedTextBox.Name = "zipCodeRegisterCustomerMaskedTextBox";
            this.zipCodeRegisterCustomerMaskedTextBox.PromptChar = ' ';
            this.zipCodeRegisterCustomerMaskedTextBox.Size = new System.Drawing.Size(49, 20);
            this.zipCodeRegisterCustomerMaskedTextBox.TabIndex = 15;
            this.zipCodeRegisterCustomerMaskedTextBox.Tag = "";
            this.zipCodeRegisterCustomerMaskedTextBox.ValidatingType = typeof(int);
            this.zipCodeRegisterCustomerMaskedTextBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.numericMask_MaskInputRejected);
            this.zipCodeRegisterCustomerMaskedTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.maskedTextBox_MouseClick);
            this.zipCodeRegisterCustomerMaskedTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaskedTextBox_KeyDown);
            this.zipCodeRegisterCustomerMaskedTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.maskedTextBox_Validating);
            // 
            // ssnRegisterCustomerLabel
            // 
            this.ssnRegisterCustomerLabel.AutoSize = true;
            this.ssnRegisterCustomerLabel.Location = new System.Drawing.Point(132, 319);
            this.ssnRegisterCustomerLabel.Name = "ssnRegisterCustomerLabel";
            this.ssnRegisterCustomerLabel.Size = new System.Drawing.Size(32, 13);
            this.ssnRegisterCustomerLabel.TabIndex = 16;
            this.ssnRegisterCustomerLabel.Text = "SSN:";
            // 
            // ssnRegisterCustomerMaskedTextBox
            // 
            this.ssnRegisterCustomerMaskedTextBox.Location = new System.Drawing.Point(187, 312);
            this.ssnRegisterCustomerMaskedTextBox.Mask = "000-00-0000";
            this.ssnRegisterCustomerMaskedTextBox.Name = "ssnRegisterCustomerMaskedTextBox";
            this.ssnRegisterCustomerMaskedTextBox.PromptChar = ' ';
            this.ssnRegisterCustomerMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.ssnRegisterCustomerMaskedTextBox.TabIndex = 17;
            this.ssnRegisterCustomerMaskedTextBox.Tag = "";
            this.ssnRegisterCustomerMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ssnRegisterCustomerMaskedTextBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.numericMask_MaskInputRejected);
            this.ssnRegisterCustomerMaskedTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.maskedTextBox_MouseClick);
            this.ssnRegisterCustomerMaskedTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaskedTextBox_KeyDown);
            this.ssnRegisterCustomerMaskedTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.maskedTextBox_Validating);
            // 
            // phoneRegisterCustomerLabel
            // 
            this.phoneRegisterCustomerLabel.AutoSize = true;
            this.phoneRegisterCustomerLabel.Location = new System.Drawing.Point(123, 366);
            this.phoneRegisterCustomerLabel.Name = "phoneRegisterCustomerLabel";
            this.phoneRegisterCustomerLabel.Size = new System.Drawing.Size(41, 13);
            this.phoneRegisterCustomerLabel.TabIndex = 18;
            this.phoneRegisterCustomerLabel.Text = "Phone:";
            // 
            // phoneRegisterCustomerMaskedTextBox
            // 
            this.phoneRegisterCustomerMaskedTextBox.Location = new System.Drawing.Point(187, 363);
            this.phoneRegisterCustomerMaskedTextBox.Mask = "(999) 000-0000";
            this.phoneRegisterCustomerMaskedTextBox.Name = "phoneRegisterCustomerMaskedTextBox";
            this.phoneRegisterCustomerMaskedTextBox.PromptChar = ' ';
            this.phoneRegisterCustomerMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.phoneRegisterCustomerMaskedTextBox.TabIndex = 19;
            this.phoneRegisterCustomerMaskedTextBox.Tag = "";
            this.phoneRegisterCustomerMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.phoneRegisterCustomerMaskedTextBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.numericMask_MaskInputRejected);
            this.phoneRegisterCustomerMaskedTextBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.maskedTextBox_MouseClick);
            this.phoneRegisterCustomerMaskedTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaskedTextBox_KeyDown);
            this.phoneRegisterCustomerMaskedTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PhoneMaskedTextBox_KeyUp);
            this.phoneRegisterCustomerMaskedTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.maskedTextBox_Validating);
            // 
            // registerCustomerButton
            // 
            this.registerCustomerButton.Location = new System.Drawing.Point(514, 426);
            this.registerCustomerButton.Name = "registerCustomerButton";
            this.registerCustomerButton.Size = new System.Drawing.Size(75, 23);
            this.registerCustomerButton.TabIndex = 20;
            this.registerCustomerButton.Text = "Register";
            this.registerCustomerButton.UseVisualStyleBackColor = true;
            this.registerCustomerButton.Click += new System.EventHandler(this.registerCustomerButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(427, 426);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 21;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 591);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Furniture Rental System";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.registerCustomerTab.ResumeLayout(false);
            this.registerCustomerTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage registerCustomerTab;
        private System.Windows.Forms.TabPage searchForCustomerIDTab;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchForCustomerIDToolStripMenuItem;
        private System.Windows.Forms.Button registerCustomerButton;
        private System.Windows.Forms.MaskedTextBox phoneRegisterCustomerMaskedTextBox;
        private System.Windows.Forms.Label phoneRegisterCustomerLabel;
        private System.Windows.Forms.MaskedTextBox ssnRegisterCustomerMaskedTextBox;
        private System.Windows.Forms.Label ssnRegisterCustomerLabel;
        private System.Windows.Forms.MaskedTextBox zipCodeRegisterCustomerMaskedTextBox;
        private System.Windows.Forms.Label zipCodeRegisterCustomerlabel;
        private System.Windows.Forms.Label stateRegisterCustomerlabel;
        private System.Windows.Forms.TextBox cityRegisterCustomerTextBox;
        private System.Windows.Forms.Label cityRegisterCustomerlabel;
        private System.Windows.Forms.TextBox streetAddressRegisterCustomerTextBox;
        private System.Windows.Forms.Label streetAddressRegisterCustomerlabel;
        private System.Windows.Forms.TextBox lastNameRegisterCustomerTextBox;
        private System.Windows.Forms.Label lastNameRegisterCustomerLabel;
        private System.Windows.Forms.TextBox middleNameRegisterCustomerTextBox;
        private System.Windows.Forms.TextBox firstNameRegisterCustomerTextBox;
        private System.Windows.Forms.MaskedTextBox stateRegisterCustomerMaskedTextBox;
        private System.Windows.Forms.Label middleNameRegisterCustomerLabel;
        private System.Windows.Forms.Label firstNameRegisterCustomerLabel;
        private System.Windows.Forms.Button clearButton;
    }
}

