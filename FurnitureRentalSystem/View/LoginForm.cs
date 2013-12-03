using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
    public partial class loginForm : Form
    {

        private ErrorProvider errorProvider;
        private LoginInformation loginInformation;
        private const int NO_RESULTS = 0;

        public loginForm(LoginInformation loginInformation)
        {
            InitializeComponent();
            this.AcceptButton = this.loginButton;
            this.errorProvider = new ErrorProvider();
            this.loginInformation = loginInformation;
        }

        //***************************************************************************************************************
        //******************************************* LoginForm **********************************************
        //***************************************************************************************************************  

        //**********************************************Click Event Handlers *************************************************
        private void textBox_Validated(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                this.errorProvider.SetError(textBox, "Required");
            }
            else
            {
                this.errorProvider.Clear();
            }
        }

        private void textBox_Entered(object sender, EventArgs e)
        {
            if (this.errorLoginFormLabel.Visible)
            {
                this.errorLoginFormLabel.Visible = false;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.ValidateChildren();

            if (this.userNameLoginTextBox.TextLength > 0 && this.passwordLoginTextBox.TextLength > 0)
            {
                this.ValidateLogin(this.userNameLoginTextBox.Text, this.passwordLoginTextBox.Text);
            }
        }

        //******************************* Login Methods *********************************
        private void ValidateLogin(string username, string password)
        {
            DatabaseAccessController dbc = new DatabaseAccessController();
            ArrayList userData = dbc.GetLogin(username, password);

            if (userData.Count != NO_RESULTS)
            {
                this.loginInformation.setEmployeeID(Convert.ToInt32(userData[0]));
                this.loginInformation.setUsername(username);
                this.loginInformation.setName(userData[1] + " " + userData[2]);
                this.loginInformation.setIsAdmin(Convert.ToInt32(userData[3]));
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.errorLoginFormLabel.Visible = true;
            }
        }
    }
}
