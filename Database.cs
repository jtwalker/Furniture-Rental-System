using System;
using MySql.Data.MySqlClient;


public class Database
{

    private static String SELECT_ALL_STATES = "SELECT abbrev FROM STATES";






    private MySqlConnection conn;
    private MySqlCommand cmd;
    private const String conStr = "server=cs.westga.edu; port=3307; uid=cs3230f13f;" +
       "pwd=MAFhpJBWRd3NAhFW;database=cs3230f13f;";





	public Database()
	{

	}


    public ArrayList<String> getStateAbbrev()
    {
        try
        {
            conn = new MySqlConnection(conStr);
            conn.Open();

            MySqlDataReader reader;
            cmd = new MySqlCommand(SELECT_ALL_STATES, conn);
            reader = cmd.ExecuteReader();

            ArrayList<String> stateAbbrevs = new ArrayList<String>();
            while (reader.Read())
            {
                stateAbbrevs.add(reader["abbrev"]);
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
            Console.WriteLine(ex.Message);
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
                Console.WriteLine("Cannot connect to server.  Contact administrator");
                break;
            case 1045:
                Console.WriteLine("Invalid username/password, please try again");
                break;
            default:
                Console.WriteLine(ex.Message + "!\nPlease try again!");
                break;
        }
    }


}
