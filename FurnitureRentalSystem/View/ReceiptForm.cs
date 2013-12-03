using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FurnitureRentalSystem.Controller;

namespace FurnitureRentalSystem.View
{
    public partial class ReceiptForm : Form
    {
        private string rentalID;
        private DataTable dataTable;

        public ReceiptForm(string rentalID)
        {
            InitializeComponent();
            this.rentalID = rentalID;
            this.FormatReceipt();
        }

        //***************************************************************************************************************
        //*******************************************Receipt Form **********************************************
        //***************************************************************************************************************  

        //********************************************** Methods *************************************************
        private void FormatReceipt()
        {
            this.ReceiptHeader();
            this.ReceiptBody();
        }

        private void ReceiptHeader()
        {
            ArrayList rentals = this.GetRentals();
            this.rentalIDLabel.Text = String.Format("Rental ID: {0}", rentals[0]);
            this.customerIDLabel.Text = String.Format("Customer ID: {0}", rentals[1]);
            this.employeeIDLabel.Text = String.Format("Employee ID: {0}", rentals[2]);
            this.rentalDateLabel.Text = String.Format("Rental Date: {0}", rentals[3]);
        }

        private void ReceiptBody()
        {
            DatabaseAccessController dbc = new DatabaseAccessController();
            ArrayList receiptDetails = dbc.GetReceiptDetails(this.rentalID);

            this.PlaceSearchResultsInList(receiptDetails, this.receiptListView);
        }

        private ArrayList GetRentals()
        {
            DatabaseAccessController dbc = new DatabaseAccessController();
            ArrayList rentals = dbc.GetRentals(this.rentalID);

            return rentals;
        }

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
    }
}
