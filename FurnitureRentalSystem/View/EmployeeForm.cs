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

namespace FurnitureRentalSystem
{
    public partial class EmployeeForm : Form
    {
        private ErrorProvider errorProvider;
        private LoginInformation loginInformation;
        private ArrayList stateAbbrevs;
        private ErrorProvider rentErrorProvider;

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
            else if(String.IsNullOrEmpty(this.phoneNumberSearchCustomerMaskedTextBox.Text) && this.phoneSearchCustomerRadioButton.Checked)
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
            if(canPerformSearch)
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

            String firstName = this.firstNameRegisterCustomerTextBox.Text;
            String middleName = this.middleNameRegisterCustomerTextBox.Text;
            String lastName = this.lastNameRegisterCustomerTextBox.Text;
            String streetAddress = this.streetAddressRegisterCustomerTextBox.Text;
            String city = this.cityRegisterCustomerTextBox.Text;
            String state = this.stateAbbrevComboBox.SelectedItem.ToString();
            String zipCode = this.zipCodeRegisterCustomerMaskedTextBox.Text;
            String ssn = this.ssnRegisterCustomerMaskedTextBox.Text;
            String phone = this.phoneRegisterCustomerMaskedTextBox.Text;

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

            String customerID = dbc.AddCustomer(firstName, middleName, lastName, phone, ssn, streetAddress, city, state, zipCode);
            MessageBox.Show(firstName + " " + lastName + "\n\nCustomer ID: " + customerID, "Registered Customer", MessageBoxButtons.OK, MessageBoxIcon.None);
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
            DatabaseAccess dba = new DatabaseAccess();
            ArrayList customerInfo = dba.CustomerValidation(this.customerIDTextBox.Text);

            if (customerInfo.Count == 2)
            {
                this.errorProvider.SetError(this.customerIDTextBox, "");
                this.rentCustomerNameTextBox.Visible = true;

            
                this.rentCustomerNameTextBox.Text = customerInfo[0] + " " + customerInfo[1];
            }
            else
            {
                this.errorProvider.SetError(this.customerIDTextBox, "Invalid Customer ID");
            }


        }

        
        
    }
           
}
