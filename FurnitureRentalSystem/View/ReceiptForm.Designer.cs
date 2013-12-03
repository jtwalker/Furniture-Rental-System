namespace FurnitureRentalSystem.View
{
    partial class ReceiptForm
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
            this.rentalIDLabel = new System.Windows.Forms.Label();
            this.customerIDLabel = new System.Windows.Forms.Label();
            this.employeeIDLabel = new System.Windows.Forms.Label();
            this.rentalDateLabel = new System.Windows.Forms.Label();
            this.receiptListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // rentalIDLabel
            // 
            this.rentalIDLabel.AutoSize = true;
            this.rentalIDLabel.Location = new System.Drawing.Point(12, 9);
            this.rentalIDLabel.Name = "rentalIDLabel";
            this.rentalIDLabel.Size = new System.Drawing.Size(58, 13);
            this.rentalIDLabel.TabIndex = 0;
            this.rentalIDLabel.Text = "Rental ID: ";
            // 
            // customerIDLabel
            // 
            this.customerIDLabel.AutoSize = true;
            this.customerIDLabel.Location = new System.Drawing.Point(12, 24);
            this.customerIDLabel.Name = "customerIDLabel";
            this.customerIDLabel.Size = new System.Drawing.Size(71, 13);
            this.customerIDLabel.TabIndex = 1;
            this.customerIDLabel.Text = "Customer ID: ";
            // 
            // employeeIDLabel
            // 
            this.employeeIDLabel.AutoSize = true;
            this.employeeIDLabel.Location = new System.Drawing.Point(12, 39);
            this.employeeIDLabel.Name = "employeeIDLabel";
            this.employeeIDLabel.Size = new System.Drawing.Size(73, 13);
            this.employeeIDLabel.TabIndex = 2;
            this.employeeIDLabel.Text = "Employee ID: ";
            // 
            // rentalDateLabel
            // 
            this.rentalDateLabel.AutoSize = true;
            this.rentalDateLabel.Location = new System.Drawing.Point(12, 54);
            this.rentalDateLabel.Name = "rentalDateLabel";
            this.rentalDateLabel.Size = new System.Drawing.Size(70, 13);
            this.rentalDateLabel.TabIndex = 3;
            this.rentalDateLabel.Text = "Rental Date: ";
            // 
            // receiptListView
            // 
            this.receiptListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.receiptListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.receiptListView.Location = new System.Drawing.Point(13, 71);
            this.receiptListView.Name = "receiptListView";
            this.receiptListView.Size = new System.Drawing.Size(339, 179);
            this.receiptListView.TabIndex = 4;
            this.receiptListView.UseCompatibleStateImageBehavior = false;
            this.receiptListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Furniture ID";
            this.columnHeader1.Width = 75;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Quantity";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Daily Rate";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Daily Fee";
            // 
            // ReceiptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 262);
            this.Controls.Add(this.receiptListView);
            this.Controls.Add(this.rentalDateLabel);
            this.Controls.Add(this.employeeIDLabel);
            this.Controls.Add(this.customerIDLabel);
            this.Controls.Add(this.rentalIDLabel);
            this.Name = "ReceiptForm";
            this.Text = "Rental Invoice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label rentalIDLabel;
        private System.Windows.Forms.Label customerIDLabel;
        private System.Windows.Forms.Label employeeIDLabel;
        private System.Windows.Forms.Label rentalDateLabel;
        private System.Windows.Forms.ListView receiptListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;

    }
}