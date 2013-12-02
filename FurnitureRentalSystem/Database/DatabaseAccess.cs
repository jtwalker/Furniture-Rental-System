using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
using System.Collections;


namespace FurnitureRentalSystem.Database
{
    public class DatabaseAccess
    {

        private const int COLUMN_NAME_INDEX = 0;
        private static String SELECT_ALL_STATES = "SELECT abbrev FROM STATE";
        private MySqlConnection conn;
        private MySqlCommand cmd;
        private const String conStr = "server=cs.westga.edu; port=3307; uid=cs3230f13f;" +
           "pwd=MAFhpJBWRd3NAhFW;database=cs3230f13f;";



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


        public int GetQuantityForFurnitureNumber(int furnitureNumber)
        {

            int totalNumber = 0;
            string rentalQuantity = "";
            string returnQuantity = "";

            try
            {
                conn = new MySqlConnection(conStr);
                conn.Open();

                String selectTotalNumber = "SELECT totalNumber FROM FURNITURE_ITEM WHERE number=@fnumber";
                String selectRentedQuantity = "SELECT SUM(quantity) as quantity FROM RENTAL_ITEM WHERE furnitureNumber=@fnumber";
                String selectReturnedQuantity = "SELECT SUM(i.quantity) as quantity FROM ITEM_RETURN as i JOIN RENTAL_ITEM as r ON rentalItemId = r.id WHERE furnitureNumber=@fnumber";


                MySqlDataReader reader;

                cmd = new MySqlCommand(selectTotalNumber, conn);
                cmd.Parameters.AddWithValue("@fnumber", furnitureNumber);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Debug.WriteLine(reader["totalNumber"]);
                    totalNumber = (int) reader["totalNumber"];
                }

                if (reader != null)
                {
                    reader.Close();
                }

                GetRentalSumQuantity(furnitureNumber, ref rentalQuantity, selectRentedQuantity, ref reader);

                GetReturnedSumQuantity(furnitureNumber, ref returnQuantity, selectReturnedQuantity, ref reader);


                totalNumber = totalNumber - Convert.ToInt32(rentalQuantity) + Convert.ToInt32(returnQuantity);
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

        private void GetReturnedSumQuantity(int furnitureNumber, ref string returnQuantity, String selectReturnedQuantity, ref MySqlDataReader reader)
        {
            cmd = new MySqlCommand(selectReturnedQuantity, conn);
            cmd.Parameters.AddWithValue("@fnumber", furnitureNumber);

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Debug.WriteLine(reader["quantity"]);
                returnQuantity = (reader.IsDBNull(0) ? null : reader["quantity"].ToString());
            }

            if (reader != null)
            {
                reader.Close();
            }
            if (returnQuantity == null)
            {
                returnQuantity = "0";
            }
        }

        private void GetRentalSumQuantity(int furnitureNumber, ref string rentalQuantity, String selectRentedQuantity, ref MySqlDataReader reader)
        {
            cmd = new MySqlCommand(selectRentedQuantity, conn);
            cmd.Parameters.AddWithValue("@fnumber", furnitureNumber);

            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Debug.WriteLine(reader["quantity"]);
                rentalQuantity = (reader.IsDBNull(0) ? null : reader["quantity"].ToString());
            }

            if (reader != null)
            {
                reader.Close();
            }

            if (rentalQuantity == null)
            {
                rentalQuantity = "0";

            }
        }

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

        public void InsertReturns(DataTable returnInfo, int employeeId)
        {
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

                    Debug.WriteLine("DBA - @returnDate:: " + DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@returnDate", DateTime.Now.ToString("yyyy-MM-dd"));

                    Debug.WriteLine("DBA -  @employeeId: " + employeeId);
                    cmd.Parameters.AddWithValue("@employeeId", employeeId);

                    Debug.WriteLine("DBA - @quantity: " + row.ItemArray[1]);
                    cmd.Parameters.AddWithValue("@quantity", row.ItemArray[1]);

                    cmd.ExecuteNonQuery();
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
                cmd.Parameters.AddWithValue("@rentDate", DateTime.Now.ToString("yyyy-MM-dd"));
           

                cmd.ExecuteNonQuery();

                rentalID = cmd.LastInsertedId;

                foreach (DataRow row in rentalInfo.Rows)
                {

                    cmd = new MySqlCommand(insertRentalItemSQL, conn);
                    cmd.Parameters.AddWithValue("@rentID", rentalID);

                    Debug.WriteLine("DBA - FurnNum: " + row.ItemArray[0]);
                    cmd.Parameters.AddWithValue("@furnNum", row.ItemArray[0]);
                    
                    Debug.WriteLine("DBA - dueDate: " + DateTime.Now.AddDays(7).ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@dueDate", DateTime.Now.AddDays(7).ToString("yyyy-MM-dd"));

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


        public void GetRentalInfo(int rentalID, DataTable table)
        {

            string loginQuerySQL = "SELECT number, description, r.id as rentalItemID, (IFNULL(r.quantity, 0) - IFNULL(i.quantity, 0)) as quantityNotReturned, " +
                                    "dailyRentalRate, dailyRentalFee, rentalDate, dueDate " +
                                    "FROM (RENTAL_ITEM as r left join FURNITURE_ITEM on number = furnitureNumber) left join RENTAL as n on n.rentalID = r.rentalID " + 
                                    "left join ITEM_RETURN as i on r.id = rentalItemId " +
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


        public String AddCustomer(String fname, String mname, String lname, String phone, 
            String ssn, String street, String city, String stateAbbrev, String zipCode)
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
                cmd.Parameters.AddWithValue("@fname", fname);
                cmd.Parameters.AddWithValue("@mname", mname);
                cmd.Parameters.AddWithValue("@lname", lname);
                cmd.Parameters.AddWithValue("@phone", phone); 
                cmd.Parameters.AddWithValue("@ssn", ssn);
                cmd.Parameters.AddWithValue("@street", street);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@stateAbbrev", stateAbbrev);
                cmd.Parameters.AddWithValue("@zipCode", zipCode);

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

        public ArrayList getLogin(string username, string password)
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
                        userData.Add((reader.IsDBNull(i) || reader[i] == DBNull.Value ? "NULL" : reader[i].ToString()));
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

        public ArrayList getCustomers(String fname, String lname, String phone)
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
                        customers.Add((reader.IsDBNull(i) || reader[i] == DBNull.Value ? "NULL" : reader[i].ToString()));
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

        public ArrayList searchFurniture(string searchCriteria)
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
                        results.Add((reader.IsDBNull(i) || reader[i] == DBNull.Value ? "NULL" : reader[i].ToString()));
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

        public ArrayList adminQueryResults(string query)
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
                        results.Add((reader.IsDBNull(i) || reader[i] == DBNull.Value ? "NULL" : reader[i].ToString()));
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

        public ArrayList adminQueryColumns(string query)
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

        public string adminNonQuery(string adminSQL)
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
