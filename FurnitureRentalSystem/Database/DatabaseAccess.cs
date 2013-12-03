using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
using System.Collections;

using FurnitureRentalSystem.Model;

namespace FurnitureRentalSystem.Database
{
    /// <summary>
    /// Provides access to the database that contains all the stores information.
    /// </summary>
    public class DatabaseAccess
    {

        private const int COLUMN_NAME_INDEX = 0;
        private static String SELECT_ALL_STATES = "SELECT abbrev FROM STATE";
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private const String conStr = "server=cs.westga.edu; port=3307; uid=cs3230f13f;" +
           "pwd=MAFhpJBWRd3NAhFW;database=cs3230f13f;";


        /// <summary>
        /// Gets the state abbreviations from the database.
        /// </summary>
        /// <returns>ArrayList of State Abbreviations</returns>
        public ArrayList GetStateAbbrevs()
        {

            ArrayList stateAbbrevs = new ArrayList();

            try
            {
                conn = new MySqlConnection(conStr);
                conn.Open();

                MySqlDataReader reader;
                cmd = new MySqlCommand(SELECT_ALL_STATES, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //Debug.WriteLine(reader["abbrev"]);
                    stateAbbrevs.Add(reader["abbrev"]);
                }

                if (reader != null)
                {
                    reader.Close();
                }

            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return stateAbbrevs;
        }

        /// <summary>
        /// Gets the rental id numbers belonging to the specified customerID
        /// </summary>
        /// <param name="custID">Customer ID</param>
        /// <returns>ArrayList of rentalIDS</returns>
         public ArrayList GetRentalIDsNumbers(string custID)
        {
            ArrayList rentalIDs = new ArrayList();

            try
            {
                conn = new MySqlConnection(conStr);
                conn.Open();

                String selectAllFurnitureIDs = "SELECT rentalId FROM RENTAL WHERE customerID = @custID";

                MySqlDataReader reader;
                cmd = new MySqlCommand(selectAllFurnitureIDs, conn);
                cmd.Parameters.AddWithValue("@custID", custID);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Debug.WriteLine(reader["rentalId"]);
                    rentalIDs.Add(reader["rentalId"]);
                }

                if (reader != null)
                {
                    reader.Close();
                }

            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return rentalIDs;
        }

         /// <summary>
         /// Gets all the furniture item numbers.
         /// </summary>
         /// <returns>ArrayList of all the furniture item numbers</returns>
        public ArrayList GetFurnitureItemNumbers()
        {

            ArrayList furnitureIDs = new ArrayList();

            try
            {
                conn = new MySqlConnection(conStr);
                conn.Open();

                String selectAllFurnitureIDs = "SELECT number FROM FURNITURE_ITEM";

                MySqlDataReader reader;
                cmd = new MySqlCommand(selectAllFurnitureIDs, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Debug.WriteLine(reader["number"]);
                    furnitureIDs.Add(reader["number"]);
                }

                if (reader != null)
                {
                    reader.Close();
                }

            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return furnitureIDs;
        }

        /// <summary>
        /// Gets the quantity available for the specified furnitureItem
        /// </summary>
        /// <param name="furnitureNumber">Number of the furniture item</param>
        /// <returns>Quantity available for specified furniture item</returns>
        public int GetQuantityForFurnitureNumber(int furnitureNumber)
        {
            int totalNumber = 0;
          
            try
            {
                conn = new MySqlConnection(conStr);
                conn.Open();

                String selectQuantity = "SELECT (totalNumber - IFNULL(SUM(r.quantity), 0) + IFNULL(" +
                                            "(SELECT SUM(ir.quantity) " +
                                            "FROM ITEM_RETURN as ir join RENTAL_ITEM s " +
                                            "WHERE s.id = ir.rentalItemId AND s.furnitureNumber =f.number) ,0)) as quantity " +
                                        "FROM FURNITURE_ITEM as f  join RENTAL_ITEM  as r on f.number=r.furnitureNumber " +
                                        "WHERE f.number = @furnNumber";



                MySqlDataReader reader;

                cmd = new MySqlCommand(selectQuantity, conn);
                cmd.Parameters.AddWithValue("@furnNumber", furnitureNumber);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Debug.WriteLine(reader["quantity"]);
                    totalNumber = Convert.ToInt32(reader["quantity"]);
                }

                if (reader != null)
                {
                    reader.Close();
                }

                Debug.WriteLine("Final total quantity: " + totalNumber);
            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return totalNumber;
        }

        /// <summary>
        /// Gets the furniture descriptions of the specified furnitureItem
        /// </summary>
        /// <param name="furnitureNumber">Number of the furniture item</param>
        /// <returns>A string[] of the description</returns>
        public string[] GetFurnitureDescription(int furnitureNumber)
        {

            string[] data = new string[3];

            try
            {
                conn = new MySqlConnection(conStr);
                conn.Open();

                String selectQuantity = "SELECT description, dailyRentalRate, dailyRentalFee FROM FURNITURE_ITEM WHERE number=@fnumber";

                MySqlDataReader reader;

                cmd = new MySqlCommand(selectQuantity, conn);
                cmd.Parameters.AddWithValue("@fnumber", furnitureNumber);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Debug.WriteLine(reader["description"]);
                    data[0] = (string)reader["description"];
                    data[1] = reader["dailyRentalRate"].ToString();
                    data[2] = reader["dailyRentalFee"].ToString();
                }

                if (reader != null)
                {
                    reader.Close();
                }

            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return data;
        }



        /// <summary>
        /// Returns an Arraylist containing the customer's first and last name if validated. 
        /// Otherwise, and empty ArrayList.
        /// </summary>
        /// <param name="customerID">Id of customer to validate</param>
        /// <returns>Arraylist containing the customer's first and last name if validated. Otherwise, and empty ArrayList.</returns>
        public ArrayList CustomerValidation(String customerID)
        {
            ArrayList customer = new ArrayList();

            String insertCustomerSQL = "SELECT fname, lname FROM CUSTOMER WHERE id=@customerID";

            try
            {
                conn = new MySqlConnection(conStr);
                conn.Open();

                MySqlDataReader reader;

                cmd = new MySqlCommand(insertCustomerSQL, conn);
                cmd.Parameters.AddWithValue("@customerID", customerID);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            customer.Add((reader[i].ToString()));
                        }
                    }

                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
                //customer = ex.Message;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
                //customer = ex.Message;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return customer;

        }


        /// <summary>
        /// Inserts data into Database, returns true if successful, false otherwise.
        /// </summary>
        /// <param name="returnInfo">Table of information to be inserted into Database</param>
        /// <param name="employeeId">employee id who handled return</param>
        /// <returns>true if success, false otherwise</returns>
        public bool InsertReturns(DataTable returnInfo, int employeeId)
        {
            bool isSuccess = false;


            String insertReturnSQL = "INSERT INTO ITEM_RETURN(rentalItemId, returnDate, employeeId, quantity) VALUES (@rentalItemId, @returnDate, @employeeId, @quantity)";
           
           
            try
            {
                conn = new MySqlConnection(conStr);
                conn.Open();

                foreach (DataRow row in returnInfo.Rows)
                {

                    cmd = new MySqlCommand(insertReturnSQL, conn);
                    Debug.WriteLine("DBA -  @rentalItemId: " + row.ItemArray[0]);
                    cmd.Parameters.AddWithValue("@rentalItemId", row.ItemArray[0]);

                    Debug.WriteLine("DBA - @returnDate:: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@returnDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    Debug.WriteLine("DBA -  @employeeId: " + employeeId);
                    cmd.Parameters.AddWithValue("@employeeId", employeeId);

                    Debug.WriteLine("DBA - @quantity: " + row.ItemArray[1]);
                    cmd.Parameters.AddWithValue("@quantity", row.ItemArray[1]);

                    cmd.ExecuteNonQuery();
                }

                isSuccess = true;
               
            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
                
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
                
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return isSuccess;
            
        }
        /// <summary>
        /// Adds Rental to Database
        /// </summary>
        /// <param name="customerID">customer id who made rental</param>
        /// <param name="employeeID">id of employee who made rental</param>
        /// <param name="rentalInfo">information about the rental</param>
        /// <returns>String containing the RentalID, or an empty string if not successful </returns>
        public String AddRental(int customerID, int employeeID, DataTable rentalInfo)
        {

            String rentalIdString = "";
            long rentalID = 0;

            String insertRentalSQL = "INSERT INTO RENTAL(customerID, employeeID, rentalDate) VALUES (@custID, @empID, @rentDate)";
            String insertRentalItemSQL = "INSERT INTO RENTAL_ITEM(rentalID, furnitureNumber, dueDate, quantity) VALUES (@rentID, @furnNum, @dueDate, @quantity)";
            try
            {
                conn = new MySqlConnection(conStr);
                conn.Open();

                cmd = new MySqlCommand(insertRentalSQL, conn);
                cmd.Parameters.AddWithValue("@custID", customerID);
                cmd.Parameters.AddWithValue("@empID", employeeID);
                cmd.Parameters.AddWithValue("@rentDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
           

                cmd.ExecuteNonQuery();

                rentalID = cmd.LastInsertedId;

                foreach (DataRow row in rentalInfo.Rows)
                {

                    cmd = new MySqlCommand(insertRentalItemSQL, conn);
                    cmd.Parameters.AddWithValue("@rentID", rentalID);

                    Debug.WriteLine("DBA - FurnNum: " + row.ItemArray[0]);
                    cmd.Parameters.AddWithValue("@furnNum", row.ItemArray[0]);

                    Debug.WriteLine("DBA - dueDate: " + DateTime.Now.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@dueDate", DateTime.Now.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss"));

                    Debug.WriteLine("DBA - @quantity: " + row.ItemArray[2]);
                    cmd.Parameters.AddWithValue("@quantity", row.ItemArray[2]);

                    cmd.ExecuteNonQuery();
                }

                rentalIdString = rentalID.ToString();
            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
                rentalIdString = ex.Message;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
                rentalIdString = ex.Message;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }



            return rentalIdString;

        }

        /// <summary>
        /// Places rental info in specified table
        /// </summary>
        /// <param name="rentalID">rental id</param>
        /// <param name="table">table to put the info in </param>
        public void GetRentalInfo(int rentalID, DataTable table)
        {

            string loginQuerySQL = "SELECT number, description, r.id as rentalItemID, (IFNULL(r.quantity, 0) - IFNULL((" +
                                        "Select SUM(i.quantity) " +
                                        "From ITEM_RETURN as i " +
                                        "Where r.id = rentalItemId), 0)) as quantityNotReturned, " +
                                    "dailyRentalRate, dailyRentalFee, rentalDate, dueDate " +
                                    "FROM (RENTAL_ITEM as r join FURNITURE_ITEM on number = furnitureNumber) join RENTAL as n on n.rentalID = r.rentalID  " +
                                    "WHERE r.rentalID = @rentalID";

           



            try
            {
                conn = new MySqlConnection(conStr);
                conn.Open();

                MySqlDataReader reader;
                cmd = new MySqlCommand(loginQuerySQL, conn);
                cmd.Parameters.AddWithValue("@rentalID", rentalID);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Debug.WriteLine("TBL - Furnid: " + reader["number"]);
                    int furnId = (int)reader["number"];

                    Debug.WriteLine("TBL - desc: " + reader["description"].ToString());
                    string desc = reader.IsDBNull(0) ? "NA" : reader["description"].ToString();

                    Debug.WriteLine("TBL - RentalItemId: " + reader["rentalItemID"]);
                    int rentalItemID = (int)reader["rentalItemID"];

                    Debug.WriteLine("TBL - qtyNotRtrn: " + reader["quantityNotReturned"]);
                    int qtyNotReturned = Convert.ToInt32(reader["quantityNotReturned"]);

                    Debug.WriteLine("TBL - rate: " + reader["dailyRentalRate"].ToString());
                    decimal rate = Convert.ToDecimal(reader["dailyRentalRate"]);

                    Debug.WriteLine("TBL - fee: " + reader["dailyRentalFee"].ToString());
                    decimal fee =  Convert.ToDecimal(reader["dailyRentalFee"]);

                    Debug.WriteLine("TBL - rentalDate: " + reader["rentalDate"]);
                    DateTime rentalDate = (DateTime)reader["rentalDate"];

                    Debug.WriteLine("TBL - dueDate: " + reader["dueDate"]);
                    DateTime dueDate = (DateTime)reader["dueDate"];

                    int quantityToReturn = 0;
                    Debug.WriteLine("TBL - qtyToReturn: " + quantityToReturn);
                    decimal amountDue = 0;
                    Debug.WriteLine("TBL - amtDUe " + amountDue);

                    DataRow newRow = table.NewRow();
             
                    newRow["FurnitureID"] = furnId;
                    newRow["Description"] = desc;
                    newRow["RentalItemID"] = rentalItemID;
                    newRow["QuantityNotReturned"] = qtyNotReturned;
                    newRow["DailyRate"] = rate;
                    newRow["DailyFee"] = fee;
                    newRow["RentalDate"] = rentalDate;
                    newRow["DueDate"] = dueDate;
                    newRow["QuantityToReturn"] = quantityToReturn;
                    newRow["AmountDue"] = amountDue;
                    table.Rows.Add(newRow);
                }

                if (reader != null)
                {
                    reader.Close();
                }

            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

           


        }

        /// <summary>
        /// Adds customer to database
        /// </summary>
        /// <param name="customer">customer to add</param>
        /// <returns>String with customer id, or empty string</returns>
        public String AddCustomer(Customer customer)
        {
            String customerID = "Inserted";

            String insertCustomerSQL = "INSERT INTO CUSTOMER(fname, mname, lname, phone, ssn, "
             + "street, city, stateAbbrev, zipCode) VALUES (@fname, @mname, @lname, @phone, @ssn, "
             + "@street, @city, @stateAbbrev, @zipCode)";

            try
            {
                conn = new MySqlConnection(conStr);
                conn.Open();

                cmd = new MySqlCommand(insertCustomerSQL, conn);
                cmd.Parameters.AddWithValue("@fname", customer.FName);
                cmd.Parameters.AddWithValue("@mname", customer.MName);
                cmd.Parameters.AddWithValue("@lname", customer.LName);
                cmd.Parameters.AddWithValue("@phone", customer.Phone); 
                cmd.Parameters.AddWithValue("@ssn", customer.SSN);
                cmd.Parameters.AddWithValue("@street", customer.StreetAddress);
                cmd.Parameters.AddWithValue("@city", customer.City);
                cmd.Parameters.AddWithValue("@stateAbbrev", customer.State);
                cmd.Parameters.AddWithValue("@zipCode", customer.ZIPCode);

                cmd.ExecuteNonQuery();

                customerID = cmd.LastInsertedId.ToString();    

            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
                customerID = ex.Message;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
                customerID = ex.Message;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }



            return customerID;

        }

        /// <summary>
        /// Get login info
        /// </summary>
        /// <param name="username">username to login</param>
        /// <param name="password">password to try</param>
        /// <returns>Information about user</returns>
        public ArrayList GetLogin(string username, string password)
        {
            ArrayList userData = new ArrayList();
            string loginQuerySQL = "SELECT id, fname, lname, isAdmin FROM EMPLOYEE WHERE login=@username AND BINARY password=@password";

            try
            {
                conn = new MySqlConnection(conStr);
                conn.Open();

                MySqlDataReader reader;
                cmd = new MySqlCommand(loginQuerySQL, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        userData.Add((reader.IsDBNull(i) ? "NULL" : reader[i].ToString()));
                    }
                }

                if (reader != null)
                {
                    reader.Close();
                }

            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return userData;
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
            ArrayList customers = new ArrayList();
            String query = "SELECT id, fname, mname, lname, CONCAT(street, ', ', city, ', ', stateAbbrev, ' ', zipCode) AS address, phone FROM CUSTOMER WHERE (fname=@fname AND lname=@lname) OR phone=@phone";

            try
            {
                conn = new MySqlConnection(conStr);

                conn.Open();

                MySqlDataReader reader;
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@phone", phone);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        customers.Add((reader.IsDBNull(i) ? "NULL" : reader[i].ToString()));
                    }
                }

                if (reader != null)
                {
                    reader.Close();
                }

            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return customers;
        }

        /// <summary>
        /// Searches for furniture with specified criteria
        /// </summary>
        /// <param name="searchCriteria">Specified search criteria</param>
        /// <returns>Arraylist of info on furniture</returns>
        public ArrayList SearchFurniture(string searchCriteria)
        {
            ArrayList results = new ArrayList();
            string query = "SELECT number, description, totalNumber, dailyRentalFee, dailyRentalRate, category, style FROM FURNITURE_ITEM WHERE number=@criteria OR category=@criteria OR style=@criteria";

            try
            {
                conn = new MySqlConnection(conStr);

                conn.Open();

                MySqlDataReader reader;
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@criteria", searchCriteria);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        results.Add((reader.IsDBNull(i) ? "NULL" : reader[i].ToString()));
                    }
                }

                if (reader != null)
                {
                    reader.Close();
                }

            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return results;
        }

        /// <summary>
        /// Queries the database 
        /// </summary>
        /// <param name="query">the query to use</param>
        /// <returns>ArrayList of information from query</returns>
        public ArrayList AdminQueryResults(string query)
        {
            ArrayList results = new ArrayList();

            try
            {
                conn = new MySqlConnection(conStr);

                conn.Open();

                MySqlDataReader reader;
                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        results.Add((reader.IsDBNull(i) ? "NULL" : reader[i].ToString()));
                    }
                }

                if (reader != null)
                {
                    reader.Close();
                }

            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return results;
        }


        /// <summary>
        /// Gets the columns for the specified query
        /// </summary>
        /// <param name="query">the query to use</param>
        /// <returns>Arraylist of columns</returns>
        public ArrayList AdminQueryColumns(string query)
        {
            ArrayList columnHeaders = new ArrayList();

            try
            {
                conn = new MySqlConnection(conStr);

                conn.Open();

                MySqlDataReader reader;
                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();

                DataTable dataTable = reader.GetSchemaTable();

                foreach (DataRow row in dataTable.Rows)
                {
                    columnHeaders.Add(row[COLUMN_NAME_INDEX]);
                }

                if (reader != null)
                {
                    reader.Close();
                }

            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return columnHeaders;
        }

        /// <summary>
        /// Runs non-query admininstrator SQL 
        /// </summary>
        /// <param name="adminSQL">sql to run</param>
        /// <returns>String with "Completed" if success, "Failed" otherwise</returns>
        public string AdminNonQuery(string adminSQL)
        {
            string result = "Failed";

            try
            {
                conn = new MySqlConnection(conStr);
                conn.Open();

                cmd = new MySqlCommand(adminSQL, conn);

                cmd.ExecuteNonQuery();

                result = "Completed";

            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
                result = ex.Message;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                result = ex.Message;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return result;
        }

        /// <summary>
        /// Gets all rentals between fromDate and toDate
        /// </summary>
        /// <param name="fromDate">the date from</param>
        /// <param name="toDate">the date to</param>
        /// <returns>The rental information</returns>
        public ArrayList GetRentals(string fromDate, string toDate)
        {
            ArrayList rentals = new ArrayList();
            string query = "SELECT rentalID, customerID, employeeID, DATE_FORMAT(rentalDate,'%Y-%m-%d') FROM RENTAL WHERE rentalDate BETWEEN @fromDate and @toDate";

            try
            {
                conn = new MySqlConnection(conStr);

                conn.Open();

                MySqlDataReader reader;
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@fromDate", fromDate);
                cmd.Parameters.AddWithValue("@toDate", toDate);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        rentals.Add((reader.IsDBNull(i) ? "NULL" : reader[i].ToString()));
                    }
                }

                if (reader != null)
                {
                    reader.Close();
                }

            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return rentals;
        }

        /// <summary>
        /// Gets the rental with the specified rentalID
        /// </summary>
        /// <param name="rentalID">specified rental id</param>
        /// <returns>ArrayList of information on the rental</returns>
        public ArrayList GetRentals(string rentalID)
        {
            ArrayList rentals = new ArrayList();
            string query = "SELECT rentalID, customerID, employeeID, DATE_FORMAT(rentalDate,'%Y-%m-%d') FROM RENTAL WHERE rentalID=@rentalID";

            try
            {
                conn = new MySqlConnection(conStr);

                conn.Open();

                MySqlDataReader reader;
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@rentalID", rentalID);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        rentals.Add((reader.IsDBNull(i) ? "NULL" : reader[i].ToString()));
                    }
                }

                if (reader != null)
                {
                    reader.Close();
                }

            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return rentals;
        }

        /// <summary>
        /// Get rental items of the specified rentalID
        /// </summary>
        /// <param name="rentalID">specified rental id</param>
        /// <returns>ArrayList of rental items</returns>
        public ArrayList GetRentalItems(string rentalID)
        {
            ArrayList rentalItems = new ArrayList();
            string query = "SELECT * FROM RENTAL_ITEM WHERE rentalID=@rentalID";

            try
            {
                conn = new MySqlConnection(conStr);

                conn.Open();

                MySqlDataReader reader;
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@rentalID", rentalID);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        rentalItems.Add((reader.IsDBNull(i) ? "NULL" : reader[i].ToString()));
                    }
                }

                if (reader != null)
                {
                    reader.Close();
                }

            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return rentalItems;
        }


        /// <summary>
        /// Gets the receipt details of the specified rentalID
        /// </summary>
        /// <param name="rentalID">specified rental id</param>
        /// <returns>Arraylist of information about the rental</returns>
        public ArrayList GetReceiptDetails(string rentalID)
        {
            ArrayList receiptDetails = new ArrayList();
            string query = "SELECT number, description, quantity, dailyRentalRate, dailyRentalFee FROM RENTAL_ITEM JOIN FURNITURE_ITEM ON furnitureNumber=number WHERE rentalID=@rentalID";

            try
            {
                conn = new MySqlConnection(conStr);

                conn.Open();

                MySqlDataReader reader;
                cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@rentalID", rentalID);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        receiptDetails.Add((reader.IsDBNull(i) ? "NULL" : reader[i].ToString()));
                    }
                }

                if (reader != null)
                {
                    reader.Close();
                }

            }
            catch (MySqlException ex)
            {
                this.HandleMySqlException(ex);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            return receiptDetails;
        }

        private void HandleMySqlException(MySqlException ex)
        {
            switch (ex.Number)
            {
                case 0:

                    Debug.WriteLine("Cannot connect to server.  Contact administrator");
                    //Console.WriteLine("Cannot connect to server.  Contact administrator");
                    break;
                case 1045:
                    Debug.WriteLine("Invalid username/password, please try again");
                    //Console.WriteLine("Invalid username/password, please try again");
                    break;
                default:
                    Debug.WriteLine(ex.Message + "!\nPlease try again!");
                    //Console.WriteLine(ex.Message + "!\nPlease try again!");
                    break;
            }
        }
    }
}
