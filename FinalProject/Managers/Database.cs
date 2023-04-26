using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace FinalProject.Managers
{
    public class Database
    {
        public  MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public  MySqlCommand cmd;
        private static Database instance;

        //Constructor
        private Database()
        {
            Initialize();
        }

        // allowing only one instance of this specific database
        public static Database GetInstance()
        {
            if (instance == null)
            {
                instance = new Database();
                return instance;
            }
            else { return instance; }
        }

        //Initialize values
        private void Initialize()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
            {
                Server = "Localhost",
                UserID = "root",
                Password = "password",
                Database = "testdb"
            };

            connection = new MySqlConnection(builder.ConnectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try

            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //Insert statement
        public void Insert(string query)
        {

            //open connection
            if (OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                CloseConnection();
            }
        }

        //Update statement
        public void Update(string SQL)
        {

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = SQL;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
    }
}

