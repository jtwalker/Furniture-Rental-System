using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureRentalSystem.Model
{
    public class Customer
    {

        private string fName;
        private string mName;
        private string lName;
        private string streetAddress;
        private string city;
        private string state;
        private string zipCode;
        private string ssn;
        private string phone;
        private string id;


        public string FName
        {
            get { return fName; }
            set { fName = value;  }
        }

        public string MName
        {
            get { return mName; }
            set { mName = value; }
        }

        public string LName
        {
            get { return lName; }
            set { lName = value; }
        }

        public string StreetAddress
        {
            get { return streetAddress; }
            set { streetAddress = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string ZIPCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }

        public string SSN
        {
            get { return ssn; }
            set { ssn = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }




        public Customer()
        {
        }

        public Customer(string fname, string mname, string lname, string streetAddress, 
            string city, string state, string zipcode, string ssn, string phone)
        {
            this.FName = fname;
            this.MName = mname;
            this.LName = lname;
            this.StreetAddress = streetAddress;
            this.City = city;
            this.State = state;
            this.ZIPCode = zipcode;
            this.SSN = ssn;
            this.Phone = phone;
        }

        public Customer(string fname, string mname, string lname, string streetAddress,
            string city, string state, string zipcode, string ssn, string phone, string id)
        {
            this.FName = fname;
            this.MName = mname;
            this.LName = lname;
            this.StreetAddress = streetAddress;
            this.City = city;
            this.State = state;
            this.ZIPCode = zipcode;
            this.SSN = ssn;
            this.Phone = phone;
            this.ID = id;
        }

    }
}
