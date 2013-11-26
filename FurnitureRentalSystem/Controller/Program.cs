using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using FurnitureRentalSystem.Model;

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
            LoginInformation loginInformation = new LoginInformation();
            loginForm login = new loginForm(loginInformation);
            DialogResult result = login.ShowDialog();
            login.Dispose();
            if (result != DialogResult.Cancel)
            {
                //Application.Run(new EmployeeForm(loginInformation));
                determineForm(loginInformation);
            }
        }

        private static void determineForm(LoginInformation loginInformation)
        {
            bool isAdmin = loginInformation.getIsAdmin();

            if (isAdmin)
            {
                Application.Run(new AdminForm(loginInformation));
            }
            else
            {
                Application.Run(new EmployeeForm(loginInformation));
            }
        }
    }
}
