using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FurnitureRentalSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            loginForm login = new loginForm();
            DialogResult result = login.ShowDialog();
            login.Dispose();
            if (result != DialogResult.Cancel)
            {
                Application.Run(new Form1());
            }
        }
    }
}
