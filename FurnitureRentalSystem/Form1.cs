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

       
        public Form1()
        {
            InitializeComponent();
            this.firstNameSearchCustomerTextBox.KeyPress += new KeyPressEventHandler(keyPress);
            this.lastNameSearchCustomerTextBox.KeyPress += new KeyPressEventHandler(keyPress);
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


    }
}
