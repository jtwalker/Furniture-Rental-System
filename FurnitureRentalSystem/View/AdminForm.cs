using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

using FurnitureRentalSystem.Model;
using FurnitureRentalSystem.Database;


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
            else if(this.queryRadioButton.Checked)
            {
                this.errorMessageLabel.Visible = false;
                this.clearEverythingExceptSQL();
                this.performQuery();
            }
            else if (this.nonQueryRadioButton.Checked)
            {
                this.errorMessageLabel.Visible = false;
                this.clearEverythingExceptSQL();
                this.performNonQuery();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.clearForm();
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
        }

        private void clearForm()
        {
            this.sqlStatementTextBox.Clear();
            this.clearEverythingExceptSQL();
            this.sqlStatementTextBox.Focus();
        }

        private void performQuery()
        {
            DatabaseAccess dbAccess = new DatabaseAccess();
            ArrayList results = dbAccess.adminQueryResults(this.sqlStatementTextBox.Text);

            if (results.Count != 0)
            {
                this.setColumnHeaders();
                this.placeSearchResultsInList(results, this.queryResultsListView);
            }
            else
            {
                this.noResultsFound(this.queryResultsListView);
            }

            this.resizeListViewColumns(this.queryResultsListView);
        }

        private void performNonQuery()
        {
            DatabaseAccess dbAccess = new DatabaseAccess();
            string result = dbAccess.adminNonQuery(this.sqlStatementTextBox.Text);

            MessageBox.Show(result);
        }

        private void setColumnHeaders()
        {
            DatabaseAccess dbAccess = new DatabaseAccess();
            ArrayList columnHeaders = dbAccess.adminQueryColumns(this.sqlStatementTextBox.Text);

            queryResultsListView.Columns.Clear();

            foreach (string column in columnHeaders)
            {
                this.queryResultsListView.Columns.Add(column);
            }

            queryResultsListView.View = View.Details;
        }

        private void placeSearchResultsInList(ArrayList results, ListView resultView)
        {
            int numberOfColumns = resultView.Columns.Count;
            int counter = 0;
            ListViewItem listViewItem = new ListViewItem();

            while (counter < results.Count)
            {
                if (counter == 0)
                {
                    listViewItem = new ListViewItem(Convert.ToString(results[counter]), 0);
                    counter++;
                }
                else if (counter % numberOfColumns == 0)
                {
                    resultView.Items.Add(listViewItem);
                    listViewItem = new ListViewItem(Convert.ToString(results[counter]), 0);
                    counter++;
                }
                else
                {
                    listViewItem.SubItems.Add(Convert.ToString(results[counter]));
                    counter++;
                }
                if (counter == results.Count)
                {
                    resultView.Items.Add(listViewItem);
                }
            }
        }

        private void noResultsFound(ListView resultView)
        {
            resultView.Items.Clear();
            ListViewItem noResultsViewItem = new ListViewItem("No Results Found", 0);
            resultView.Items.Add(noResultsViewItem);
        }

        private void nonQueryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.clearForm();
        }

        private void queryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.clearForm();
        }
    }
}
