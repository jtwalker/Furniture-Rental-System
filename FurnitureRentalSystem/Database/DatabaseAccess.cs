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
