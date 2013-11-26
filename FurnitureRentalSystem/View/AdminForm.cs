using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FurnitureRentalSystem.Model;


namespace FurnitureRentalSystem
{
    public partial class AdminForm : Form
    {
        public AdminForm(LoginInformation loginInformation)
        {
            InitializeComponent();
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String aboutMessage = "Furniture Rental System\nVersion 0.1\nCreated By: Justin Walker and Jennifer Holland";
            MessageBox.Show(aboutMessage, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (this.sqlStatementTextBox.Text == "")
            {
                this.setErrorMessage("Please enter a SQL statement.");
            }
            else
            {
                this.errorMessageLabel.Visible = false;
                this.clearEverythingExceptSQL();
                //this.printColumnNameTypes(this.sqlStatementTextBox.Text);
                //this.queryDB(this.sqlStatementTextBox.Text);

                resizeListViewColumns(queryResultsListView);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.sqlStatementTextBox.Clear();
            this.clearEverythingExceptSQL();
            this.sqlStatementTextBox.Focus();
        }

        private void setErrorMessage(String errorMessage)
        {
            this.errorMessageLabel.Text = errorMessage;
            this.errorMessageLabel.Visible = true;
        }

        private void resizeListViewColumns(ListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                column.Width = -2;
            }
        }

        private void clearEverythingExceptSQL()
        {
            this.queryResultsListView.Clear();
            this.errorMessageLabel.Visible = false;
            //this.database.clear();
        }
    }
}
