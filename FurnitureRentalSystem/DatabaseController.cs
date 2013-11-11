using System;
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



        public ArrayList getStateAbbrevs()
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
