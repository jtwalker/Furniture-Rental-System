﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FurnitureRentalSystem
{
    public partial class Form1 : Form
    {
        private readonly int PHONE_INDEX = 5;
        private readonly int NUMBER_OF_CUSTOMER_DETAILS = 6;
        private readonly int FIRST_NAME_INDEX = 1;
        private readonly int LAST_NAME_INDEX = 3;
        private int customerID = 0;
        private ErrorProvider errorProvider;
        private String[,] customers;

        public Form1()
        {
            InitializeComponent();
            this.firstNameSearchCustomerTextBox.KeyPress += new KeyPressEventHandler(keyPress);
            this.lastNameSearchCustomerTextBox.KeyPress += new KeyPressEventHandler(keyPress);
            this.SetUpRegisterCustomerControls();
            this.createFakeCustomers();
            this.errorProvider = new ErrorProvider();
        }




        //*************************private helper methods********************

       


        private void CheckMaskedTextMaskIsComplete(MaskedTextBox maskedTextBox)
        {
            if (!maskedTextBox.MaskCompleted)
            {
                //toolTip1.ToolTipTitle = "Invalid Data";
                //toolTip1.Show("The field must be completed.", maskedTextBox, 0, 20, 5000);
               
                //maskedTextBox.BackColor = Color.Red;

                maskedTextBox.Tag = false;
                this.errorProvider.SetError(maskedTextBox, "The field must be completed.");
            }
            else
            {
                //maskedTextBox.BackColor = System.Drawing.SystemColors.Window;
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
                          (bool)(this.stateRegisterCustomerMaskedTextBox.Tag) &&
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

            this.stateRegisterCustomerMaskedTextBox.Tag = false;
            this.zipCodeRegisterCustomerMaskedTextBox.Tag = false;
            this.ssnRegisterCustomerMaskedTextBox.Tag = false;
            this.phoneRegisterCustomerMaskedTextBox.Tag = false;

            this.registerCustomerButton.Enabled = false;
        }

        //************************Search Customer ID Methods*************************

        private void createFakeCustomers()
        {
            this.customers = new String[4,6] { {"01", "Justin", "Tyler", "Walker", "123 Somewhere Dr, Villa Rica, GA 30180", "7701234567"},
                                               {"02", "Jennifer", "", "Holland", "456 There Road, Carrollton, GA 30116", "7704567890"},
                                               {"03", "Jonathan", "Kyle", "Walker", "123 Somewhere Dr, Villa Rica, GA 30180", "7701234567"}, 
                                               {"04", "Jennifer", "Something", "Holland", "987 Somewhere Else Parkway", "7700000000" } };
        }

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
            if (this.phoneSearchCustomerRadioButton.Checked)
            {
                this.usePhoneNumberInCustomerSearch();
            }
            else
            {
                this.useNameInCustomerSearch();
            }
        }

        private void usePhoneNumberInCustomerSearch()
        {
            int numberOfCustomers = this.customers.Length / 6 - 1;
            for(int i=0; i<=numberOfCustomers; i++)
            {
                if (this.customers[i, PHONE_INDEX] == this.phoneNumberSearchCustomerMaskedTextBox.Text)
                {
                    this.placeCustomerInList(i);
                }
                else if (i == numberOfCustomers && this.searchResultsSearchCustomerListView.Items.Count == 0)
                {
                    this.noResultsFound();
                }
            }
            
        }

        private void useNameInCustomerSearch()
        {
            int numberOfCustomers = this.customers.Length / 6 - 1;
            for (int i = 0; i <= numberOfCustomers; i++)
            {
                if (this.customers[i, FIRST_NAME_INDEX].ToLower() == this.firstNameSearchCustomerTextBox.Text.ToLower() && this.customers[i, LAST_NAME_INDEX].ToLower() == this.lastNameSearchCustomerTextBox.Text.ToLower())
                {
                    this.placeCustomerInList(i);
                }
                else if (i == numberOfCustomers && this.searchResultsSearchCustomerListView.Items.Count == 0)
                {
                    this.noResultsFound();
                }
            }
        }

        private void noResultsFound()
        {
            this.searchResultsSearchCustomerListView.Items.Clear();
            ListViewItem listViewItem = new ListViewItem("No Customer Found", 0);
            this.searchResultsSearchCustomerListView.Items.Add(listViewItem);
        }

        private void placeCustomerInList(int customerIndex)
        {
            ListViewItem listViewItem = new ListViewItem(this.customers[customerIndex,0], 0);
            for (int i = 1; i < NUMBER_OF_CUSTOMER_DETAILS; i++)
            {
                listViewItem.SubItems.Add(this.customers[customerIndex, i]);
            }
            this.searchResultsSearchCustomerListView.Items.Add(listViewItem);
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

        private void registerCustomerButton_Click(object sender, EventArgs e)
        {

            String firstName = this.firstNameRegisterCustomerTextBox.Text;
            String middleName = this.middleNameRegisterCustomerTextBox.Text;
            String lastName = this.lastNameRegisterCustomerTextBox.Text;
            String streetAddress = this.streetAddressRegisterCustomerTextBox.Text;
            String city = this.cityRegisterCustomerTextBox.Text;
            String state = this.streetAddressRegisterCustomerTextBox.Text;
            String zipCode = this.zipCodeRegisterCustomerMaskedTextBox.Text;
            String ssn = this.ssnRegisterCustomerMaskedTextBox.Text;
            String phone = this.phoneRegisterCustomerMaskedTextBox.Text;

            //TODO: add variables to some data structure
            String message = "Customer registered:\n" +
                            " First Name: " + firstName +
                            "\n  Middle Name: " + middleName +
                            "\n  Last Name: " + lastName +
                            "\n  Street Address: " + streetAddress +
                            "\n  City: " + city +
                            "\n  State: " + state +
                            "\n  ZIP Code: " + zipCode +
                            "\n  SSN: " + ssn +
                            "\n  phone: " + phone +
                            "\n\n Customer ID: " + customerID;
            MessageBox.Show(message, "Registered Customer", MessageBoxButtons.OK, MessageBoxIcon.None);
            this.customerID++;
            this.ResetAllControls();

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

        private void registerCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach (Control control in this.panel1.Controls)
            //{
            //    control.Enabled = true;
            //}
            //this.registerCustomerButton.Enabled = false;

            tabControl.SelectTab(registerCustomerTab);
        }

        private void searchForCustomerIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //String message = "";
            //foreach (Control control in this.tabControl.SelectedTab.Controls)
            //{
            //    control.Enabled = false;
            //    message += control.Name + ", ";
            //}
            //MessageBox.Show(message);

            tabControl.SelectTab(searchForCustomerIDTab);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.ResetAllControls();
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




        //************MouseClick event handlers******************************

        private void maskedTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            MaskedTextBox mTextBox = (MaskedTextBox)sender;

            mTextBox.SelectionStart = 0;
        }



        //*********************Validating event handlers (includes one key up event to validate last field)*************

        private void textBoxEmpty_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            //toolTip1.SetToolTip(textBox, "text");

            String controlName = textBox.Name;
            controlName = controlName.TrimEnd("TextBox".ToCharArray());
            Debug.WriteLine("control name trimmed: " + controlName);
            controlName += "LabelError";

            if (textBox.Text.Length == 0)
            {
                //foreach (Control control in this.registerCustomerTab.Controls)
                //{
                //    Debug.WriteLine("control name: " + control.Name);
                //    Debug.WriteLine("controlName: " + controlName);
                   
                //    if(control.Name.Equals(controlName))
                //    {
                //        Debug.WriteLine("Names are equal");
                //        Label label = (Label)control;

                //        label.Text = "The field must be completed.";
                //        control.Visible = true; 
                //    }


                //}

                //toolTip1.ToolTipTitle = "Invalid Data";
                //toolTip1.Show("The field must be completed.", textBox, 0, 20, 5000);
                //textBox.BackColor = Color.Red;


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
            //toolTip1.SetToolTip(maskedTextBox, "text");

            this.CheckMaskedTextMaskIsComplete(maskedTextBox);
        }


        private void PhoneMaskedTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            MaskedTextBox maskedTextBox = (MaskedTextBox)sender;
            //toolTip1.SetToolTip(maskedTextBox, "text");

            if (maskedTextBox.MaskCompleted)
            {
                this.CheckMaskedTextMaskIsComplete(maskedTextBox);
            }
        }


        //**********************MaskInputRejected event handlers************************

        private void numericMask_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MaskedTextBox maskedTextBox = (MaskedTextBox)sender;
            //toolTip1.SetToolTip(maskedTextBox, "text");
            //if (maskedTextBox.MaskFull)
            //{
            //    toolTip1.ToolTipTitle = "Input Rejected - Too Much Data";

            //    toolTip1.Show("You cannot enter any more data into the date field."
            //    + "Delete some characters in order to insert more data.", maskedTextBox, 0, 20, 5000);
            //}
            //else if (e.Position ==maskedTextBox.Mask.Length)
            //{
            //    toolTip1.ToolTipTitle = "Input Rejected - End of Field";
            //    toolTip1.Show("You cannot add extra characters to the end of this date field.", maskedTextBox, 0, 20, 5000);
            //}
            //else
            //{

            if (!maskedTextBox.MaskFull && e.Position != maskedTextBox.Mask.Length)
            {
                //toolTip1.ToolTipTitle = "Input Rejected";
                //toolTip1.Show("You can only add numeric characters (0-9) into this field.", maskedTextBox, 0, 20, 5000);
                this.errorProvider.SetError(maskedTextBox, "You can only add numeric characters (0-9) into this field.");
            }
        }

        private void letterMask_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MaskedTextBox maskedTextBox = (MaskedTextBox)sender;
            //toolTip1.SetToolTip(maskedTextBox, "text");
            //if (maskedTextBox.MaskFull)
            //{
            //    toolTip1.ToolTipTitle = "Input Rejected - Too Much Data";

            //    toolTip1.Show("You cannot enter any more data into the date field. " +
            //        "Delete some characters in order to insert more data.", maskedTextBox, 0, 20, 5000);
            //}
            //else if (e.Position == maskedTextBox.Mask.Length)
            //{
            //    toolTip1.ToolTipTitle = "Input Rejected - End of Field";
            //    toolTip1.Show("You cannot add extra characters to the end of this date field.", maskedTextBox, 0, 20, 5000);
            //}
            //else
            //{

            if (!maskedTextBox.MaskFull && e.Position != maskedTextBox.Mask.Length)
            {
                //toolTip1.ToolTipTitle = "Input Rejected";
                //toolTip1.Show("You can only add letter characters into this field.", maskedTextBox, 0, 20, 5000);
                this.errorProvider.SetError(maskedTextBox, "You can only add letter characters into this field.");
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

       
       

        
    }
           
}
