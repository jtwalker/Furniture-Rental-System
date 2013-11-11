using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureRentalSystem
{
    public class LoginInformation
    {
        private int employeeID;
        private string username;
        private string name;
        private bool isAdmin;

        public LoginInformation()
        {
            this.employeeID = 0;
            this.username = "default";
            this.name = "default";
            this.isAdmin = false;
        }

        public void setEmployeeID(int id)
        {
            this.employeeID = id;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setIsAdmin(int accessLevel)
        {
            if (accessLevel == 1)
            {
                this.isAdmin = true;
            }
            else
            {
                this.isAdmin = false;
            }
        }

        public int getEmployeeID()
        {
            return this.employeeID;
        }

        public string getUsername()
        {
            return this.username;
        }

        public string getName()
        {
            return this.name;
        }

        public bool getIsAdmin()
        {
            return this.isAdmin;
        }

    }
}
