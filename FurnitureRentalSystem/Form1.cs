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

namespace FurnitureRentalSystem
{
    public partial class Form1 : Form
    {
        private String EMPTY_PHONE = "(   )    -    ";
        private int customerID = 0;
        private ErrorProvider errorProvider;

        public Form1()
        {
            InitializeComponent();
            this.firstNameSearchCustomerTextBox.KeyPress += new KeyPressEventHandler(keyPress);
            this.lastNameSearchCustomerTextBox.KeyPress += new KeyPressEventHandler(keyPress);
            this.SetUpRegisterCustomerControls();

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
            bool canPerformSearch = this.ensureSearchCustomerFieldsAreCompleted();
            if(canPerformSearch)
            {
                this.performCustomerSearch();
            }
        }

        private bool ensureSearchCustomerFieldsAreCompleted()
        {
            if ((String.IsNullOrEmpty(this.firstNameSearchCustomerTextBox.Text) || String.IsNullOrEmpty(this.lastNameSearchCustomerTextBox.Text)) && String.IsNullOrEmpty(this.phoneNumberSearchCustomerMaskedTextBox.Text))
            {
                this.errorSearchCustomerLabel.Text = "Please fill out both the first and last name\n or enter a phone number.";
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
            if(!String.IsNullOrEmpty(this.phoneNumberSearchCustomerMaskedTextBox.Text))
            {
                MessageBox.Show("Use phone in search");
            }
            else 
            {
                MessageBox.Show("Use name for search");
            }
        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            int asciiCode = Convert.ToInt32(e.KeyChar);
            if (!(asciiCode >= 65 && asciiCode <= 90) && !(asciiCode >= 97 && asciiCode <= 122) && !(asciiCode == 8) && !(asciiCode == 45) && !(asciiCode == 39))
            {
                //MessageBox.Show("Not allowed!");
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
