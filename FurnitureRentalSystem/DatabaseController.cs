﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
using System.Collections;


namespace FurnitureRentalSystem
{
    public class DatabaseController
    {


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
                    Debug.WriteLine(reader["abbrev"]);
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