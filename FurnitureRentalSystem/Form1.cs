using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurnitureRentalSystem
{
    public partial class Form1 : Form
    {

        private int customerID = 0;


        public Form1()
        {
            InitializeComponent();
           

            this.SetUpRegisterCustomerControls();
        }




        //*************************private helper methods********************

       


        private void CheckMaskedTextMaskIsComplete(MaskedTextBox maskedTextBox)
        {
            if (!maskedTextBox.MaskCompleted)
            {
                toolTip1.ToolTipTitle = "Invalid Data";
                toolTip1.Show("The field must be completed.", maskedTextBox, 0, 20, 5000);
                maskedTextBox.Tag = false;
                maskedTextBox.BackColor = Color.Red;
            }
            else
            {
                maskedTextBox.BackColor = System.Drawing.SystemColors.Window;
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
            toolTip1.SetToolTip(textBox, "text");
            if (textBox.Text.Length == 0)
            {
                toolTip1.ToolTipTitle = "Invalid Data";
                toolTip1.Show("The field must be completed.", textBox, 0, 20, 5000);
                textBox.BackColor = Color.Red;
                
                textBox.Tag = false;
            }
            else
            {
                textBox.BackColor = System.Drawing.SystemColors.Window;
                textBox.Tag = true;
            }

            ValidateAll();
        }


        private void maskedTextBox_Validating(object sender, CancelEventArgs e)
        {
            MaskedTextBox maskedTextBox = (MaskedTextBox)sender;
            toolTip1.SetToolTip(maskedTextBox, "text");

            this.CheckMaskedTextMaskIsComplete(maskedTextBox);
        }


        private void PhoneMaskedTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            MaskedTextBox maskedTextBox = (MaskedTextBox)sender;
            toolTip1.SetToolTip(maskedTextBox, "text");

            if (maskedTextBox.MaskCompleted)
            {
                this.CheckMaskedTextMaskIsComplete(maskedTextBox);
            }
        }


        //**********************MaskInputRejected event handlers************************

        private void numericMask_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MaskedTextBox maskedTextBox = (MaskedTextBox)sender;
            toolTip1.SetToolTip(maskedTextBox, "text");
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
                toolTip1.ToolTipTitle = "Input Rejected";
                toolTip1.Show("You can only add numeric characters (0-9) into this field.", maskedTextBox, 0, 20, 5000);
            }
        }

        private void letterMask_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MaskedTextBox maskedTextBox = (MaskedTextBox)sender;
            toolTip1.SetToolTip(maskedTextBox, "text");
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
                toolTip1.ToolTipTitle = "Input Rejected";
                toolTip1.Show("You can only add letter characters into this field.", maskedTextBox, 0, 20, 5000);
            }
        }



        //************************KeyDown event handlers************** 

        private void MaskedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            MaskedTextBox maskedTextBox = (MaskedTextBox)sender;
            toolTip1.Hide(maskedTextBox);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            toolTip1.Hide(textBox);
        }

       

        
    }
           
}
