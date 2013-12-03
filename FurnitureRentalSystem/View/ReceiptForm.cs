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
using FurnitureRentalSystem.Database;

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
            this.formatReceipt();
        }

        private void formatReceipt()
        {
            this.receiptHeader();
            this.receiptBody();
        }

        private void receiptHeader()
        {
            ArrayList rentals = this.getRentals();
            this.rentalIDLabel.Text = String.Format("Rental ID: {0}", rentals[0]);
            this.customerIDLabel.Text = String.Format("Customer ID: {0}", rentals[1]);
            this.employeeIDLabel.Text = String.Format("Employee ID: {0}", rentals[2]);
            this.rentalDateLabel.Text = String.Format("Rental Date: {0}", rentals[3]);
        }

        private void receiptBody()
        {
            DatabaseAccess dbAccess = new DatabaseAccess();
            ArrayList receiptDetails = dbAccess.getReceiptDetails(this.rentalID);

            this.placeSearchResultsInList(receiptDetails, this.receiptListView);
        }

        private ArrayList getRentals()
        {
            DatabaseAccess dbAccess = new DatabaseAccess();
            ArrayList rentals = dbAccess.getRentals(this.rentalID);

            return rentals;
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
    }
}
