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
using FurnitureRentalSystem.Controller;


namespace FurnitureRentalSystem
{
    public partial class AdminForm : Form
    {
        public AdminForm(LoginInformation loginInformation)
        {
            InitializeComponent();
            this.FormatDateTimePickers();
        }

        //******************************Menu Item Event Handlers**************************

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

        //***************************************************************************************************************
        //******************************************* ADMIN SQL TAB **********************************************
        //***************************************************************************************************************

        //************************Click Event Handlers*******************************
        private void performBtn_Click(object sender, EventArgs e)
        {
            if (this.sqlStatementTextBox.Text == "")
            {
                this.SetErrorMessage("Please enter a SQL statement.");
            }
            else if(this.queryRadioButton.Checked)
            {
                this.errorMessageLabel.Visible = false;
                this.ClearEverythingExceptSQL();
                this.PerformQuery();
            }
            else if (this.nonQueryRadioButton.Checked)
            {
                this.errorMessageLabel.Visible = false;
                this.ClearEverythingExceptSQL();
                this.PerformNonQuery();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.clearForm();
        }

        //************************SQL Methods***************************
        private void SetErrorMessage(String errorMessage)
        {
            this.errorMessageLabel.Text = errorMessage;
            this.errorMessageLabel.Visible = true;
        }

        private void ClearEverythingExceptSQL()
        {
            this.queryResultsListView.Clear();
            this.errorMessageLabel.Visible = false;
        }

        private void clearForm()
        {
            this.sqlStatementTextBox.Clear();
            this.ClearEverythingExceptSQL();
            this.sqlStatementTextBox.Focus();
        }

        private void PerformQuery()
        {
            DatabaseAccessController dbc = new DatabaseAccessController();
            ArrayList results = dbc.AdminQueryResults(this.sqlStatementTextBox.Text);

            if (results.Count != 0)
            {
                this.SetColumnHeaders();
                this.PlaceSearchResultsInList(results, this.queryResultsListView);
            }
            else
            {
                this.NoResultsFound(this.queryResultsListView);
            }

            this.ResizeListViewColumns(this.queryResultsListView);
        }

        private void PerformNonQuery()
        {
            DatabaseAccessController dbc = new DatabaseAccessController();
            string result = dbc.AdminNonQuery(this.sqlStatementTextBox.Text);

            MessageBox.Show(result);
        }

        private void SetColumnHeaders()
        {
            DatabaseAccessController dbc = new DatabaseAccessController();
            ArrayList columnHeaders = dbc.AdminQueryColumns(this.sqlStatementTextBox.Text);

            queryResultsListView.Columns.Clear();

            foreach (string column in columnHeaders)
            {
                this.queryResultsListView.Columns.Add(column);
            }

        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.clearForm();
        }

        //***************************************************************************************************************
        //*******************************************SEARCH RENTALS TAB **********************************************
        //***************************************************************************************************************

        //******************************************Click Event Handlers************************************************

        private void searchRentalsButton_Click(object sender, EventArgs e)
        {
            this.ordersListView.Items.Clear();
            this.PerformGetRentals();
        }

        private void ordersListView_DoubleClick(object sender, EventArgs e)
        {
            this.contentsListView.Items.Clear();
            this.PerformGetRentalDetails();
        }

        //************************Search RENTALS ID Methods*************************
        private void FormatDateTimePickers()
        {
            this.fromDateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.toDateTimePicker.CustomFormat = "yyyy-MM-dd";
        }

        private void PerformGetRentals()
        {
            string fromDate = this.fromDateTimePicker.Text;
            string toDate = this.toDateTimePicker.Text;

            DatabaseAccessController dbc = new DatabaseAccessController();
            ArrayList rentals = dbc.GetRentals(fromDate, toDate);

            if (rentals.Count != 0)
            {
                this.PlaceSearchResultsInList(rentals, this.ordersListView);
            }
            else
            {
                this.NoResultsFound(this.ordersListView);
            }

            this.ResizeListViewColumns(this.ordersListView);
        }

        private void PerformGetRentalDetails()
        {
            ListView.SelectedListViewItemCollection rental = this.ordersListView.SelectedItems;
            string rentalID = rental[0].SubItems[0].Text;

            DatabaseAccessController dbc = new DatabaseAccessController();
            ArrayList rentalItems = dbc.GetRentalItems(rentalID);

            if (rentalItems.Count != 0)
            {
                this.PlaceSearchResultsInList(rentalItems, this.contentsListView);
            }
            else
            {
                this.NoResultsFound(this.contentsListView);
            }

            this.ResizeListViewColumns(this.contentsListView);
        }

        //***************************************************************************************************************
        //*******************************************SEARCH TABS SHARED **********************************************
        //***************************************************************************************************************  

        //**********************************************Shared Methods*************************************************
        private void PlaceSearchResultsInList(ArrayList results, ListView resultView)
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

        private void NoResultsFound(ListView resultView)
        {
            resultView.Items.Clear();
            ListViewItem noResultsViewItem = new ListViewItem("No Results Found", 0);
            resultView.Items.Add(noResultsViewItem);
        }

        private void ResizeListViewColumns(ListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                column.Width = -2;
            }
        }
    }
}
