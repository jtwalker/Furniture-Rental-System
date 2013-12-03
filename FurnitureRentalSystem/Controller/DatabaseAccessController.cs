using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FurnitureRentalSystem.Database;
using FurnitureRentalSystem.Model;

namespace FurnitureRentalSystem.Controller
{
    /// <summary>
    /// DatabaseAccessController controls the DatabaseAccess class.
    /// </summary>
    public class DatabaseAccessController
    {

        private DatabaseAccess dba;

        /// <summary>
        /// Gets the state abbreviations from the databaseAccess class.
        /// </summary>
        /// <returns>ArrayList of State Abbreviations</returns>
        public ArrayList GetStateAbbrevs()
        {
            this.dba = new DatabaseAccess();
            return this.dba.GetStateAbbrevs();
        }

        /// <summary>
        /// Gets the rental id numbers belonging to the specified customerID
        /// </summary>
        /// <param name="custID">Customer ID</param>
        /// <returns>ArrayList of rentalIDS</returns>
        public ArrayList GetRentalIDsNumbers(string custID)
        {
            this.dba = new DatabaseAccess();
            return this.dba.GetRentalIDsNumbers(custID);
        }

        /// <summary>
        /// Gets all the furniture item numbers.
        /// </summary>
        /// <returns>ArrayList of all the furniture item numbers</returns>
        public ArrayList GetFurnitureItemNumbers()
        {
            this.dba = new DatabaseAccess();
            return this.dba.GetFurnitureItemNumbers();
            
        }

        /// <summary>
        /// Gets the quantity available for the specified furnitureItem
        /// </summary>
        /// <param name="furnitureNumber">Number of the furniture item</param>
        /// <returns>Quantity available for specified furniture item</returns>
        public int GetQuantityForFurnitureNumber(int furnitureNumber)
        {
            this.dba = new DatabaseAccess();
            return this.dba.GetQuantityForFurnitureNumber(furnitureNumber);
        }

        /// <summary>
        /// Gets the furniture descriptions of the specified furnitureItem
        /// </summary>
        /// <param name="furnitureNumber">Number of the furniture item</param>
        /// <returns>A string[] of the description</returns>
        public string[] GetFurnitureDescription(int furnitureNumber)
        {
            this.dba = new DatabaseAccess();
            return this.dba.GetFurnitureDescription(furnitureNumber);
        }

        /// <summary>
        /// Returns an Arraylist containing the customer's first and last name if validated. 
        /// Otherwise, and empty ArrayList.
        /// </summary>
        /// <param name="customerID">Id of customer to validate</param>
        /// <returns>Arraylist containing the customer's first and last name if validated. Otherwise, and empty ArrayList.</returns>
        public ArrayList CustomerValidation(String customerID)
        {
            this.dba = new DatabaseAccess();
            return this.dba.CustomerValidation(customerID);
        }

        /// <summary>
        /// Inserts data into Database, returns true if successful, false otherwise.
        /// </summary>
        /// <param name="returnInfo">Table of information to be inserted into Database</param>
        /// <param name="employeeId">employee id who handled return</param>
        /// <returns>true if success, false otherwise</returns>
        public bool InsertReturns(DataTable returnInfo, int employeeId)
        {
            this.dba = new DatabaseAccess();
            return this.dba.InsertReturns(returnInfo, employeeId);
        }

        /// <summary>
        /// Adds Rental to Database
        /// </summary>
        /// <param name="customerID">customer id who made rental</param>
        /// <param name="employeeID">id of employee who made rental</param>
        /// <param name="rentalInfo">information about the rental</param>
        /// <returns>String containing the RentalID, or an empty string if not successful</returns>
        public String AddRental(int customerID, int employeeID, DataTable rentalInfo)
        {
            this.dba = new DatabaseAccess();
            return this.dba.AddRental(customerID, employeeID, rentalInfo);
        }

        /// <summary>
        /// Places rental info in specified table
        /// </summary>
        /// <param name="rentalID">rental id</param>
        /// <param name="table">table to put the info in </param>
        public void GetRentalInfo(int rentalID, DataTable table)
        {
            this.dba = new DatabaseAccess();
            this.dba.GetRentalInfo(rentalID, table);
        }

        /// <summary>
        /// Adds customer to database
        /// </summary>
        /// <param name="customer">customer to add</param>
        /// <returns>String with customer id, or empty string</returns>
        public String AddCustomer(Customer customer)
        {
            this.dba = new DatabaseAccess();
            return this.dba.AddCustomer(customer);
        }


        /// <summary>
        /// Get login info
        /// </summary>
        /// <param name="username">username to login</param>
        /// <param name="password">password to try</param>
        /// <returns>Information about user</returns>
        public ArrayList GetLogin(string username, string password)
        {
            this.dba = new DatabaseAccess();
            return this.dba.GetLogin(username, password);
        }

        /// <summary>
        /// Gets Customers with matching fname, lname, or phone#
        /// </summary>
        /// <param name="fname">first name</param>
        /// <param name="lname">last name</param>
        /// <param name="phone">phone number</param>
        /// <returns>Information about the customers</returns>
        public ArrayList GetCustomers(String fname, String lname, String phone)
        {
            this.dba = new DatabaseAccess();
            return this.dba.GetCustomers(fname, lname, phone);

        }

        /// <summary>
        /// Searches for furniture with specified criteria
        /// </summary>
        /// <param name="searchCriteria">Specified search criteria</param>
        /// <returns>Arraylist of info on furniture</returns>
        public ArrayList SearchFurniture(string searchCriteria)
        {
            this.dba = new DatabaseAccess();
            return this.dba.SearchFurniture(searchCriteria);
        }

        /// <summary>
        /// Queries the database 
        /// </summary>
        /// <param name="query">the query to use</param>
        /// <returns>ArrayList of information from query</returns>
        public ArrayList AdminQueryResults(string query)
        {
            this.dba = new DatabaseAccess();
            return this.dba.AdminQueryResults(query);
        }

        /// <summary>
        /// Gets the columns for the specified query
        /// </summary>
        /// <param name="query">the query to use</param>
        /// <returns>Arraylist of columns</returns>
        public ArrayList AdminQueryColumns(string query)
        {
            this.dba = new DatabaseAccess();
            return this.dba.AdminQueryColumns(query);
        }

        /// <summary>
        /// Runs non-query admininstrator SQL 
        /// </summary>
        /// <param name="adminSQL">sql to run</param>
        /// <returns>String with "Completed" if success, "Failed" otherwise</returns>
        public string AdminNonQuery(string adminSQL)
        {
            this.dba = new DatabaseAccess();
            return this.dba.AdminNonQuery(adminSQL);
        }

        /// <summary>
        /// Gets all rentals between fromDate and toDate
        /// </summary>
        /// <param name="fromDate">the date from</param>
        /// <param name="toDate">the date to</param>
        /// <returns>The rental information</returns>
        public ArrayList GetRentals(string fromDate, string toDate)
        {
            this.dba = new DatabaseAccess();
            return this.dba.GetRentals(fromDate, toDate);
        }

        /// <summary>
        /// Gets the rental with the specified rentalID
        /// </summary>
        /// <param name="rentalID">specified rental id</param>
        /// <returns>ArrayList of information on the rental</returns>
        public ArrayList GetRentals(string rentalID)
        {
            this.dba = new DatabaseAccess();
            return this.dba.GetRentals(rentalID);
        }

        /// <summary>
        /// Get rental items of the specified rentalID
        /// </summary>
        /// <param name="rentalID">specified rental id</param>
        /// <returns>ArrayList of rental items</returns>
        public ArrayList GetRentalItems(string rentalID)
        {
            this.dba = new DatabaseAccess();
            return this.dba.GetRentalItems(rentalID);
        }

        /// <summary>
        /// Gets the receipt details of the specified rentalID
        /// </summary>
        /// <param name="rentalID">specified rental id</param>
        /// <returns>Arraylist of information about the rental</returns>
        public ArrayList GetReceiptDetails(string rentalID)
        {
            this.dba = new DatabaseAccess();
            return this.dba.GetReceiptDetails(rentalID);
        }

    }
}
