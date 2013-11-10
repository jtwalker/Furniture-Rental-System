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

namespace FurnitureRentalSystem
{
    public partial class loginForm : Form
    {

        private ErrorProvider errorProvider;

        public loginForm()
        {
            InitializeComponent();
            this.errorProvider = new ErrorProvider();
            this.userNameLoginTextBox.Validated += new EventHandler(textBox_Validated);
            this.passwordLoginTextBox.Validated += new EventHandler(textBox_Validated);
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

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.ValidateChildren();

            if (this.userNameLoginTextBox.TextLength > 0 && this.passwordLoginTextBox.TextLength > 0)
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
