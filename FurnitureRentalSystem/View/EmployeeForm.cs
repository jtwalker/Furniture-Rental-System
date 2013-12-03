using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;

using FurnitureRentalSystem.Model;
using FurnitureRentalSystem.Database;
using FurnitureRentalSystem.View;

namespace FurnitureRentalSystem
{
    public partial class EmployeeForm : Form
    {
        private ErrorProvider errorProvider;
        private LoginInformation loginInformation;
        private ArrayList stateAbbrevs;
        private ErrorProvider rentErrorProvider;
        private DataTable rentalInfoTable;
        private DataTable returnInfoTable;

        public EmployeeForm(LoginInformation loginInformation)
        {
            InitializeComponent();
            this.AcceptButton = this.registerCustomerButton;
            this.PopulateStateComboBox();
            this.SetUpRegisterCustomerControls();
            this.errorProvider = new ErrorProvider();
            this.loginInformation = loginInformation;
            this.loggedInLabel.Text = String.Format("You are logged in as: {0}. Click to logout.", this.loginInformation.getName());

            this.rentErrorProvider = new ErrorProvider();

            this.SetUpRentalInfoTable();
            this.SetUpReturnInfoTable();
        }

     




        //******************************Menu Item Event Handlers**************************

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String aboutMessage = "Furniture Rental System\nVersion 0.1\nCreated By: Justin Walker and Jennifer Holland";
            MessageBox.Show(aboutMessage, "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void registerCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(registerCustomerTab);
        }

        private void searchForCustomerIDToolStripMenuItem_Click(object sender, EventArgs e)
        {

            tabControl.SelectTab(searchForCustomerIDTab);
        }

        private void searchForFurnitureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(searchFurnitureTab);
        }

        private void rentFurnitureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(rentFurnitureTab);
        }

        private void returnFurnitureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(returnFurnitureTab);
        }


        //****************************Tab Control Event Handlers***************************

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    this.AcceptButton = this.registerCustomerButton;
                    break;
                case 1:
                    this.AcceptButton = this.searchSearchCustomerButton;
                    break;
              
            }
        }


        //***************************Login Label Event Handlers*******************
        private void loggedInLabel_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }



        //***************************************************************************************************************
        //*******************************************SEARCH FURNITURE TAB **********************************************
        //***************************************************************************************************************

        //************************Search Furniture Methods***************************

        private bool ensureSearchFurnitureFieldsAreCompleted()
        {
            if (String.IsNullOrEmpty(this.searchFurnitureCriteriaTextBox.Text))
            {
                this.errorSearchFurnitureLabel.Text = "Please provide search criteria.";
                this.errorSearchFurnitureLabel.Visible = true;
                return false;
            }
            else
            {
                this.errorSearchFurnitureLabel.Visible = false;
                return true;
            }
        }

        private void performFurnitureSearch()
        {
            DatabaseAccess dbAccess = new DatabaseAccess();
            string searchCriteria = this.searchFurnitureCriteriaTextBox.Text;
            ArrayList results = dbAccess.searchFurniture(searchCriteria);

            if (results.Count != 0)
            {
                this.placeSearchResultsInList(results, this.searchResultsSearchFurnitureListView);
            }
            else
            {
                this.noResultsFound(this.searchResultsSearchFurnitureListView);
            }

            this.resizeListViewColumns(this.searchResultsSearchFurnitureListView);
        }


        //************************Click Event Handlers*******************************

        private void searchSearchFurnitureButton_Click(object sender, EventArgs e)
        {
            this.searchResultsSearchFurnitureListView.Items.Clear();
            bool canPerformSearch = this.ensureSearchFurnitureFieldsAreCompleted();
            if (canPerformSearch)
            {
                this.performFurnitureSearch();
            }
        }



        //***************************************************************************************************************
        //*******************************************SEARCH CUSTOMER TAB **********************************************
        //***************************************************************************************************************


        //************************Search Customer ID Methods*************************

        private bool ensureSearchCustomerFieldsAreCompleted()
        {
            if ((String.IsNullOrEmpty(this.firstNameSearchCustomerTextBox.Text) || String.IsNullOrEmpty(this.lastNameSearchCustomerTextBox.Text)) && this.nameSearchCustomerRadioButton.Checked)
            {
                this.errorSearchCustomerLabel.Text = "Please fill out both First and Last Name.";
                this.errorSearchCustomerLabel.Visible = true;
                return false;
            }
            else if (String.IsNullOrEmpty(this.phoneNumberSearchCustomerMaskedTextBox.Text) && this.phoneSearchCustomerRadioButton.Checked)
            {
                this.errorSearchCustomerLabel.Text = "Please enter a valid Phone Number.";
                this.errorSearchCustomerLabel.Visible = true;
                return false;
            }
            else
            {
                this.errorSearchCustomerLabel.Visible = false;
                return true;
            }
        }

        private void performCustomerSearch()
        {
            DatabaseAccess dbc = new DatabaseAccess();
            String fname = this.firstNameSearchCustomerTextBox.Text;
            String lname = this.lastNameSearchCustomerTextBox.Text;
            String phone = this.phoneNumberSearchCustomerMaskedTextBox.Text;
            ArrayList customers = dbc.getCustomers(fname, lname, phone);

            if (customers.Count != 0)
            {
                this.placeSearchResultsInList(customers, this.searchResultsSearchCustomerListView);
            }
            else
            {
                this.noResultsFound(this.searchResultsSearchCustomerListView);
            }

            this.resizeListViewColumns(this.searchResultsSearchCustomerListView);
        }

        private void clearSearchCustomerFields()
        {
            this.firstNameSearchCustomerTextBox.Text = "";
            this.lastNameSearchCustomerTextBox.Text = "";
            this.phoneNumberSearchCustomerMaskedTextBox.Text = "";

            this.errorSearchCustomerLabel.Visible = false;
            this.errorProvider.Clear();
        }


        //************************Click event handlers*************************
        private void searchSearchCustomerButton_Click(object sender, EventArgs e)
        {
            this.searchResultsSearchCustomerListView.Items.Clear();
            bool canPerformSearch = this.ensureSearchCustomerFieldsAreCompleted();
            if (canPerformSearch)
            {
                this.performCustomerSearch();
            }
        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            int asciiCode = Convert.ToInt32(e.KeyChar);
            if (!(asciiCode >= 65 && asciiCode <= 90) && !(asciiCode >= 97 && asciiCode <= 122) && !(asciiCode == 8) && !(asciiCode == 45) && !(asciiCode == 39))
            {
                e.Handled = true;
            }
        }


        //************************KeyDown event handlers************** 

        private void nameSearchCustomerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.clearSearchCustomerFields();
            if (this.nameSearchCustomerRadioButton.Checked)
            {
                this.phoneNumberSearchCustomerMaskedTextBox.Enabled = false;
            }
            else
            {
                this.phoneNumberSearchCustomerMaskedTextBox.Enabled = true;
            }
        }

        private void phoneSearchCustomerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.clearSearchCustomerFields();
            if (this.phoneSearchCustomerRadioButton.Checked)
            {
                this.firstNameSearchCustomerTextBox.Enabled = false;
                this.lastNameSearchCustomerTextBox.Enabled = false;
            }
            else
            {
                this.firstNameSearchCustomerTextBox.Enabled = true;
                this.lastNameSearchCustomerTextBox.Enabled = true;
            }
        }



        //***************************************************************************************************************
        //*******************************************SEARCH TABS SHARED **********************************************
        //***************************************************************************************************************  


        //**********************************************Search Methods*************************************************


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

        private void resizeListViewColumns(ListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                column.Width = -2;
            }
        }








        //***************************************************************************************************************
        //*******************************************REGISTER CUSTOMER TAB **********************************************
        //***************************************************************************************************************




        //**********************Select ComboBox Item Event Handlers******************************

        private void stateAbbrevComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.stateAbbrevs.Contains(this.stateAbbrevComboBox.SelectedItem))
            {
                this.errorProvider.SetError(this.stateAbbrevComboBox, "Must make selection.");
            }
            else
            {
                this.errorProvider.SetError(this.stateAbbrevComboBox, "");
            }

            this.stateAbbrevComboBox.Tag = this.stateAbbrevs.Contains(this.stateAbbrevComboBox.SelectedItem);

            this.ValidateAll();
        }




        //**********************MaskInputRejected event handlers************************

        private void numericMask_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MaskedTextBox maskedTextBox = (MaskedTextBox)sender;

            if (!maskedTextBox.MaskFull && e.Position != maskedTextBox.Mask.Length)
            {
                this.errorProvider.SetError(maskedTextBox, "You can only add numeric characters (0-9) into this field.");
            }
        }

        private void letterMask_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MaskedTextBox maskedTextBox = (MaskedTextBox)sender;

            if (!maskedTextBox.MaskFull && e.Position != maskedTextBox.Mask.Length)
            {
                this.errorProvider.SetError(maskedTextBox, "You can only add letter characters into this field.");
            }
        }



        //*********************Validating event handlers (includes one key up event to validate last field)*************

        private void textBoxEmpty_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            String controlName = textBox.Name;
            controlName = controlName.TrimEnd("TextBox".ToCharArray());
            Debug.WriteLine("control name trimmed: " + controlName);
            controlName += "LabelError";

            if (textBox.Text.Length == 0)
            {
                this.errorProvider.SetError(textBox, "The field must be completed.");
                textBox.Tag = false;
            }
            else
            {
                textBox.BackColor = System.Drawing.SystemColors.Window;
                textBox.Tag = true;
                this.errorProvider.SetError(textBox, "");
            }

            ValidateAll();
        }


        private void maskedTextBox_Validating(object sender, CancelEventArgs e)
        {
            MaskedTextBox maskedTextBox = (MaskedTextBox)sender;

            this.CheckMaskedTextMaskIsComplete(maskedTextBox);
        }


        private void PhoneMaskedTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            MaskedTextBox maskedTextBox = (MaskedTextBox)sender;

            if (maskedTextBox.MaskCompleted)
            {
                this.CheckMaskedTextMaskIsComplete(maskedTextBox);
            }
        }

        //************MouseClick event handlers******************************

        private void maskedTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            MaskedTextBox mTextBox = (MaskedTextBox)sender;

            mTextBox.SelectionStart = 0;
        }




        //************************Click event handlers*************************

        private void registerCustomerButton_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();


            customer.FName = this.firstNameRegisterCustomerTextBox.Text;
            customer.MName = this.middleNameRegisterCustomerTextBox.Text;
            customer.LName = this.lastNameRegisterCustomerTextBox.Text;
            customer.StreetAddress = this.streetAddressRegisterCustomerTextBox.Text;
            customer.City = this.cityRegisterCustomerTextBox.Text;
            customer.State = this.stateAbbrevComboBox.SelectedItem.ToString();
            customer.ZIPCode = this.zipCodeRegisterCustomerMaskedTextBox.Text;
            customer.SSN = this.ssnRegisterCustomerMaskedTextBox.Text;
            customer.Phone = this.phoneRegisterCustomerMaskedTextBox.Text;



            /**
            String firstName = this.firstNameRegisterCustomerTextBox.Text;
            String middleName = this.middleNameRegisterCustomerTextBox.Text;
            String lastName = this.lastNameRegisterCustomerTextBox.Text;
            String streetAddress = this.streetAddressRegisterCustomerTextBox.Text;
            String city = this.cityRegisterCustomerTextBox.Text;
            String state = this.stateAbbrevComboBox.SelectedItem.ToString();
            String zipCode = this.zipCodeRegisterCustomerMaskedTextBox.Text;
            String ssn = this.ssnRegisterCustomerMaskedTextBox.Text;
            String phone = this.phoneRegisterCustomerMaskedTextBox.Text;
            **/
            //String message = "Customer registered:\n" +
            //                " First Name: " + firstName +
            //                "\n  Middle Name: " + middleName +
            //                "\n  Last Name: " + lastName +
            //                "\n  Street Address: " + streetAddress +
            //                "\n  City: " + city +
            //                "\n  State: " + state +
            //                "\n  ZIP Code: " + zipCode +
            //                "\n  SSN: " + ssn +
            //                "\n  phone: " + phone;

            //MessageBox.Show(message, "Entered Info", MessageBoxButtons.OK, MessageBoxIcon.None);
            //this.customerID++;

            DatabaseAccess dbc = new DatabaseAccess();

            String customerID = dbc.AddCustomer(customer);
            MessageBox.Show(customer.FName + " " + customer.LName + "\n\nCustomer ID: " + customerID, "Registered Customer", MessageBoxButtons.OK, MessageBoxIcon.None);
            this.ResetAllControls();

        }


        private void clearButton_Click(object sender, EventArgs e)
        {
            this.ResetAllControls();
        }



        //*************************private helper methods********************

        private void CheckMaskedTextMaskIsComplete(MaskedTextBox maskedTextBox)
        {
            if (!maskedTextBox.MaskCompleted)
            {

                maskedTextBox.Tag = false;
                this.errorProvider.SetError(maskedTextBox, "The field must be completed.");
            }
            else
            {
                this.errorProvider.SetError(maskedTextBox, "");
                maskedTextBox.Tag = true;
            }
            ValidateAll();
        }

        private void ValidateAll()
        {
            bool enable = ((bool)(this.firstNameRegisterCustomerTextBox.Tag) &&
                          (bool)(this.lastNameRegisterCustomerTextBox.Tag) &&
                          (bool)(this.streetAddressRegisterCustomerTextBox.Tag) &&
                          (bool)(this.cityRegisterCustomerTextBox.Tag) &&
                          (bool)(this.stateAbbrevComboBox.Tag) &&
                          (bool)(this.zipCodeRegisterCustomerMaskedTextBox.Tag) &&
                          (bool)(this.ssnRegisterCustomerMaskedTextBox.Tag) &&
                          (bool)(this.phoneRegisterCustomerMaskedTextBox.Tag));

            this.registerCustomerButton.Enabled = enable;
        }

        private void SetUpRegisterCustomerControls()
        {
            this.firstNameRegisterCustomerTextBox.Tag = false;
            this.lastNameRegisterCustomerTextBox.Tag = false;
            this.streetAddressRegisterCustomerTextBox.Tag = false;
            this.cityRegisterCustomerTextBox.Tag = false;

            this.stateAbbrevComboBox.Tag = false;

            this.zipCodeRegisterCustomerMaskedTextBox.Tag = false;
            this.ssnRegisterCustomerMaskedTextBox.Tag = false;
            this.phoneRegisterCustomerMaskedTextBox.Tag = false;

            this.registerCustomerButton.Enabled = false;
        }


        private void PopulateStateComboBox()
        {
            DatabaseAccess dbc = new DatabaseAccess();
            stateAbbrevs = dbc.GetStateAbbrevs();

            foreach (String abbrev in stateAbbrevs)
            {
                this.stateAbbrevComboBox.Items.Add(abbrev);
            }


        }

        private void ResetAllControls()
        {
            foreach (Control control in this.registerCustomerTab.Controls)
            {
                if (control is TextBox || control is MaskedTextBox)
                {
                    control.Text = "";
                }
            }
            this.errorProvider.Clear();
            this.SetUpRegisterCustomerControls();
        }


        //****************************************************************************
        //****************************Rent Furniture Tab******************************
        //****************************************************************************

        private void customerIDValidation(object sender, CancelEventArgs e)
        {
            HandleCustomerIDValidation();


        }

        private void HandleCustomerIDValidation()
        {
            DatabaseAccess dba = new DatabaseAccess();
            ArrayList customerInfo = dba.CustomerValidation(this.rentCustomerIDTextBox.Text);

            if (customerInfo.Count == 2)
            {
                this.errorProvider.SetError(this.rentCustomerIDTextBox, "");
                this.rentCustomerNameTextBox.Visible = true;
                this.rentFurnitureNumLabel.Enabled = true;
                this.rentFurnitureNumberCombBox.Enabled = true;


                this.rentCustomerNameTextBox.Text = customerInfo[0] + " " + customerInfo[1];
                this.SetUpFurnitureNumberComboBox();
                this.rentFurnitureNumberCombBox.Focus();
            }
            else
            {
                this.errorProvider.SetError(this.rentCustomerIDTextBox, "Invalid Customer ID");
            }
        }

        private void SetUpFurnitureNumberComboBox()
        {
            DatabaseAccess dba = new DatabaseAccess();
            ArrayList furnitureNums = dba.GetFurnitureItemNumbers();

            this.rentFurnitureNumberCombBox.Items.Clear();
           
            foreach (int number in furnitureNums)
            {
                this.rentFurnitureNumberCombBox.Items.Add(number);
            }

        }


        private void rentCustomerIDTextBox_KeyUp(object sender, KeyEventArgs e)
        {

            //MessageBox.Show(((e.KeyCode == Keys.Return) || (e.KeyCode == Keys.Enter)).ToString(), "Key Press", MessageBoxButtons.OK, MessageBoxIcon.None);

            if ((e.KeyCode == Keys.Return) || (e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Tab))
            {
                this.HandleCustomerIDValidation();
            }



        }

        private void rentFurnitureNumberCombBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.rentQuantityComboBox.Items.Clear();
            this.ValidateFurnitureNumberSelection();

        }

        private void ValidateFurnitureNumberSelection()
        {

            DatabaseAccess dba = new DatabaseAccess();
            int furnNum = (int)this.rentFurnitureNumberCombBox.SelectedItem;

            int quantity = dba.GetQuantityForFurnitureNumber(furnNum);

            if (quantity < 1)
            {
                this.errorProvider.SetError(this.rentFurnitureNumberCombBox, "Out of stock");
                //this.rentQuantityComboBox.Enabled = false;
                this.rentAddItemButton.Enabled = false;
            }
            else
            {
                this.errorProvider.SetError(this.rentFurnitureNumberCombBox, "");
                this.SetUpQuantityComboBox(quantity);
                this.rentQuantityComboBox.Enabled = true;
                this.rentQuantityLabel.Enabled = true;
            }

        }

        private void SetUpQuantityComboBox(int quantity)
        {
            for (int i = 1; i <= quantity; i++)
            {
                this.rentQuantityComboBox.Items.Add(i);
            }
        }

        private void rentQuantityComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.rentAddItemButton.Enabled = true;
        }

        private void rentAddItemButton_Click(object sender, EventArgs e)
        {
            int furnitureNumber = (int)this.rentFurnitureNumberCombBox.SelectedItem;

            DatabaseAccess dba = new DatabaseAccess();

            string[] data = dba.GetFurnitureDescription(furnitureNumber);
            string description = data[0];
            string dailyRate = data[1];
            string dailyFee = data[2];


            DataRow newRow = this.rentalInfoTable.NewRow();

            newRow["FurnitureID"] = this.rentFurnitureNumberCombBox.SelectedItem;
            newRow["Description"] = description;
            newRow["Quantity"] = this.rentQuantityComboBox.SelectedItem;
            newRow["DailyRate"] = Convert.ToDecimal(dailyRate);
            newRow["DailyFee"] = Convert.ToDecimal(dailyFee);
            this.rentalInfoTable.Rows.Add(newRow);

            //dataGridView1.Rows.Add(new object[] { this.rentFurnitureNumberCombBox.SelectedItem, description, this.rentQuantityComboBox.SelectedItem });
            this.rentFurnitureNumberCombBox.SelectedIndex = -1;
            this.rentFurnitureNumberCombBox.Items.Remove(furnitureNumber);
            this.rentQuantityComboBox.Items.Clear();

            this.rentButton.Enabled = true;
            this.rentalInfoDataGridView.Enabled = true;
        }

        private void rentFurnitureNumberCombBox_Validating(object sender, CancelEventArgs e)
        {
            if (this.rentFurnitureNumberCombBox.SelectedItem != null)
            {
                this.rentQuantityComboBox.Items.Clear();
                this.ValidateFurnitureNumberSelection();
            }
            else
            {
                this.errorProvider.SetError(this.rentFurnitureNumberCombBox, "Must make selection");
               // this.rentQuantityComboBox.Enabled = false;
                this.rentAddItemButton.Enabled = false;
            }
        }

        private void rentalInfoDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            ArrayList data = new ArrayList();

            foreach (DataGridViewCell cell in e.Row.Cells)
            {
                data.Add(cell.Value);
            }

            this.rentFurnitureNumberCombBox.Items.Add(data[0]);
            
        }

        private void rentButton_Click(object sender, EventArgs e)
        {
            string custID = this.rentCustomerIDTextBox.Text;
            int customerID = Convert.ToInt32(custID);
            int empID = this.loginInformation.getEmployeeID();

            DatabaseAccess dba = new DatabaseAccess();
            string rentalID = dba.AddRental(customerID, empID, rentalInfoTable);
            this.setUpRentForm();
        }
        //4 represents the rentalID number. I'm not going to add this to your methods without permission.
        //It doesn't do the no results thing the other list views do because it should always exist.
        //ReceiptForm receipt = new ReceiptForm("4");
        //receipt.ShowDialog();

        private void setUpRentForm()
        {
            this.rentFurnitureNumberCombBox.Items.Clear();
            this.rentFurnitureNumberCombBox.Enabled = false;
            this.errorProvider.SetError(this.rentFurnitureNumberCombBox, "");

            this.rentCustomerIDTextBox.Text = "";
            this.rentCustomerNameTextBox.Text = "";


            this.rentQuantityComboBox.Items.Clear();
            this.rentQuantityComboBox.Enabled = false;
            
            this.rentalInfoTable.Rows.Clear();
            this.rentalInfoDataGridView.Enabled = false;

            this.rentCustomerIDTextBox.Focus();

        }

        private void rentClearButton_Click(object sender, EventArgs e)
        {
            this.setUpRentForm();
        }

        private void SetUpRentalInfoTable()
        {
            rentalInfoTable = new DataTable();
            rentalInfoTable.Columns.Add("FurnitureID", typeof(int));
            rentalInfoTable.Columns.Add("Description", typeof(string));
            rentalInfoTable.Columns.Add("Quantity", typeof(int));
            rentalInfoTable.Columns.Add("DailyRate", typeof(decimal));
            rentalInfoTable.Columns.Add("DailyFee", typeof(decimal));

            this.rentalInfoDataGridView.DataSource = rentalInfoTable;
        }
    



        //******************************************************************************
        //****************************Return Furniture Tab******************************
        //******************************************************************************


        private void returnCustomerIdTextBox_Validating(object sender, CancelEventArgs e)
        {
            this.HandleReturnCustomerIDValidation();
        }

        private void HandleReturnCustomerIDValidation()
        {
            DatabaseAccess dba = new DatabaseAccess();
            ArrayList customerInfo = dba.CustomerValidation(this.returnCustomerIdTextBox.Text);

            if (customerInfo.Count == 2)
            {
                this.errorProvider.SetError(this.returnCustomerIdTextBox, "");

                this.returnRentalIDComboBox.Enabled = true;

                this.SetUpReturnRentalIDComboBox();
                this.returnRentalIDComboBox.Focus();
            }
            else
            {
                this.errorProvider.SetError(this.returnCustomerIdTextBox, "Invalid Customer ID");
            }
        }

        private void SetUpReturnRentalIDComboBox()
        {

            DatabaseAccess dba = new DatabaseAccess();
            ArrayList rentalIDs = dba.GetRentalIDsNumbers(this.returnCustomerIdTextBox.Text.ToString());

            this.returnRentalIDComboBox.Items.Clear();

            foreach (int id in rentalIDs)
            {
                this.returnRentalIDComboBox.Items.Add(id);
            }
            
        }

        private void returnRentalIDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int rentalID = (int)this.returnRentalIDComboBox.SelectedItem;

            DatabaseAccess dba = new DatabaseAccess();
            returnInfoTable.Rows.Clear();
            dba.GetRentalInfo(rentalID, returnInfoTable);
         
        
        }

        private void SetUpReturnInfoTable()
        {
            returnInfoTable = new DataTable();
            returnInfoTable.Columns.Add("FurnitureID", typeof(int));
            returnInfoTable.Columns.Add("Description", typeof(string));
            returnInfoTable.Columns.Add("RentalItemID", typeof(int));
            returnInfoTable.Columns.Add("QuantityNotReturned", typeof(int));
            returnInfoTable.Columns.Add("DailyRate", typeof(decimal));
            returnInfoTable.Columns.Add("DailyFee", typeof(decimal));
            returnInfoTable.Columns.Add("RentalDate", typeof(DateTime));
            returnInfoTable.Columns.Add("DueDate", typeof(DateTime));
            returnInfoTable.Columns.Add("QuantityToReturn", typeof(int));
            returnInfoTable.Columns.Add("AmountDue", typeof(decimal));

            this.returnDataGridView.DataSource = returnInfoTable;

            this.returnDataGridView.Columns[0].ReadOnly = true;
            this.returnDataGridView.Columns[1].ReadOnly = true;
            this.returnDataGridView.Columns[2].ReadOnly = true;
            this.returnDataGridView.Columns[3].ReadOnly = true;
            this.returnDataGridView.Columns[4].ReadOnly = true;
            this.returnDataGridView.Columns[5].ReadOnly = true;
            this.returnDataGridView.Columns[6].ReadOnly = true;
            this.returnDataGridView.Columns[7].ReadOnly = true;
            this.returnDataGridView.Columns[9].ReadOnly = true;
        }

        private void returnDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
            string columnName = returnInfoTable.Columns[e.ColumnIndex].ColumnName;
            int value = 0;
           
            if (!columnName.Equals("QuantityToReturn")) return;

            try
            {
               value = Convert.ToInt32(e.FormattedValue);
            }
            catch (Exception ex)
            {
                returnInfoTable.Rows[e.RowIndex].RowError =
                    "Quantity must be an integer";
                e.Cancel = true;
                this.returnReturnButton.Enabled = false;
            }

           
            int maxValue = Convert.ToInt32(returnInfoTable.Rows[e.RowIndex].ItemArray.ElementAt(3));

             
            if (value > maxValue || value < 0)
            {
                returnInfoTable.Rows[e.RowIndex].RowError =
                    "Quantity must be between 0 and "+ maxValue+ ".";
                e.Cancel = true;
                this.returnReturnButton.Enabled = false;
            }
        }

        private void returnDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.   
            returnInfoTable.Rows[e.RowIndex].RowError = String.Empty;

            DateTime today = DateTime.Now;
            Debug.WriteLine("Today: " + today);
            decimal amount;
            int numberReturning = Convert.ToInt32(returnInfoTable.Rows[e.RowIndex].ItemArray.ElementAt(8));
            DateTime rentalDate = Convert.ToDateTime(returnInfoTable.Rows[e.RowIndex].ItemArray.ElementAt(6));
            DateTime dueDate = Convert.ToDateTime(returnInfoTable.Rows[e.RowIndex].ItemArray.ElementAt(7));
            
            int days = (today - rentalDate).Days;
            decimal rate = Convert.ToDecimal(returnInfoTable.Rows[e.RowIndex].ItemArray.ElementAt(4));

            if (today.Date <= dueDate.Date)
            {
                amount = rate * days * numberReturning;
            }
            else
            {
                days = (dueDate - rentalDate).Days;
                int overdays = (today - dueDate).Days;
                
                decimal fee = Convert.ToDecimal(returnInfoTable.Rows[e.RowIndex].ItemArray.ElementAt(5));

                amount = (days * rate* numberReturning) + (overdays * fee* numberReturning);
            }

            Debug.WriteLine("amount: " + amount);
            Debug.WriteLine("amount shown: " + this.returnInfoTable.Rows[e.RowIndex][9]);
            Debug.WriteLine("e.RowIndesx: " + e.RowIndex);
            this.returnInfoTable.Rows[e.RowIndex][9]= amount;
            Debug.WriteLine("amount after: " + this.returnInfoTable.Rows[e.RowIndex][9]);

            this.returnReturnButton.Enabled = true;
        }

        private void returnClearButton_Click(object sender, EventArgs e)
        {
            this.returnReturnButton.Enabled = false;
            this.returnRentalIDComboBox.Items.Clear();
            this.returnCustomerIdTextBox.Text = String.Empty;
            this.returnInfoTable.Rows.Clear();
        }

        private void returnReturnButton_Click(object sender, EventArgs e)
        {
            
            int employeeID = loginInformation.getEmployeeID();
            int rentalID = Convert.ToInt32(this.returnRentalIDComboBox.SelectedItem);

            DataTable data = new DataTable();
            data.Columns.Add("rentalItemID", typeof(int));
            data.Columns.Add("quantityReturned", typeof(int));

            foreach (DataRow row in this.returnInfoTable.Rows)
            {
                int rentalItemID = Convert.ToInt32(row[2]);
                Debug.WriteLine("rentalItemId: " + rentalItemID);
                
                int quantity = Convert.ToInt32(row[8]);
                Debug.WriteLine("quantity: " + quantity);

                DataRow newRow = data.NewRow();
                newRow["rentalItemID"] = rentalItemID;
                Debug.WriteLine("newRow rentalItemId: " + newRow["rentalItemID"]);
                newRow["quantityReturned"] = quantity;
                Debug.WriteLine("newRow quantityReturned: " + newRow["quantityReturned"]);

                data.Rows.Add(newRow);
            }

            DatabaseAccess dba = new DatabaseAccess();
            dba.InsertReturns(data, employeeID);
        }


    }

}
