﻿using System;
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
            this.formatDateTimePickers();
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

        private void performBtn_Click(object sender, EventArgs e)
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
            ArrayList results = dbAccess.AdminQueryResults(this.sqlStatementTextBox.Text);

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
            string result = dbAccess.AdminNonQuery(this.sqlStatementTextBox.Text);

            MessageBox.Show(result);
        }

        private void setColumnHeaders()
        {
            DatabaseAccess dbAccess = new DatabaseAccess();
            ArrayList columnHeaders = dbAccess.AdminQueryColumns(this.sqlStatementTextBox.Text);

            queryResultsListView.Columns.Clear();

            foreach (string column in columnHeaders)
            {
                this.queryResultsListView.Columns.Add(column);
            }

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

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.clearForm();
        }

        private void formatDateTimePickers()
        {
            this.fromDateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.toDateTimePicker.CustomFormat = "yyyy-MM-dd";
        }

        private void searchRentalsButton_Click(object sender, EventArgs e)
        {
            this.ordersListView.Items.Clear();
            this.performGetRentals();
        }

        private void performGetRentals()
        {
            string fromDate = this.fromDateTimePicker.Text;
            string toDate = this.toDateTimePicker.Text;

            DatabaseAccess dbAccess = new DatabaseAccess();
            ArrayList rentals = dbAccess.GetRentals(fromDate, toDate);

            if (rentals.Count != 0)
            {
                this.placeSearchResultsInList(rentals, this.ordersListView);
            }
            else
            {
                this.noResultsFound(this.ordersListView);
            }

            this.resizeListViewColumns(this.ordersListView);
        }

        private void performGetRentalDetails()
        {
            ListView.SelectedListViewItemCollection rental = this.ordersListView.SelectedItems;
            string rentalID = rental[0].SubItems[0].Text;

            DatabaseAccess dbAccess = new DatabaseAccess();
            ArrayList rentalItems = dbAccess.GetRentalItems(rentalID);

            if (rentalItems.Count != 0)
            {
                this.placeSearchResultsInList(rentalItems, this.contentsListView);
            }
            else
            {
                this.noResultsFound(this.contentsListView);
            }

            this.resizeListViewColumns(this.contentsListView);
        }

        private void ordersListView_DoubleClick(object sender, EventArgs e)
        {
            this.contentsListView.Items.Clear();
            this.performGetRentalDetails();
        }
    }
}
