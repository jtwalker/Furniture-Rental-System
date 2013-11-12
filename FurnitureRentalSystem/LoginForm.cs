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
                this.validateLogin(this.userNameLoginTextBox.Text, this.passwordLoginTextBox.Text);
            }
        }

        private void validateLogin(string username, string password)
        {
            DatabaseController dbc = new DatabaseController();
            string query = String.Format("SELECT id, fname, lname, isAdmin FROM EMPLOYEE WHERE login='{0}' AND BINARY password='{1}'", username, password);
            ArrayList userData = dbc.getLogin(query);

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
