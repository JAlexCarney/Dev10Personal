using System;
using System.Data;
using System.Data.SqlClient;

namespace SimpleSchoolADODAL
{
    class Controller
    {
        static readonly ConsoleIO io = new ConsoleIO();
        const string CONNECTION_STRING = "Server=localhost;Database=SimpleSchool;User Id=sa;Password=YOUR_strong_*pass4w0rd*;";

        public void Run() 
        {
            MenuLoop();
        }

        private void MenuLoop() 
        {
            while (true) 
            {
                io.Clear();
                io.PrintLineYellow("Simple School DataBase Manager");
                io.PrintLineYellow("==============================");
                io.PrintLine("");
                io.PrintLineYellow("Main Menu");
                io.PrintLineYellow("=========");
                io.PrintLineDarkYellow("0. Exit");
                io.PrintLineDarkYellow("1. Display Class Information By Section ID");
                int choice = io.ReadInt("Make a selection: ", 0, 1);
                switch (choice) 
                {
                    case 0:
                        return;
                    case 1:
                        DisplayClassRoster();
                        break;
                }
            }
            
        }

        private void DisplayClassRoster() 
        {
            io.Clear();
            io.PrintLineYellow("Simple School DataBase Manager");
            io.PrintLineYellow("==============================");
            int sectionId = io.ReadInt("Enter SectionID: ");
            
            // 1 instantiate connection
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var sql = "SELECT * FROM Teacher";

                // 2 instantiate command, give it SQL and the connection to use
                var command = new SqlCommand(sql, connection);

                try
                {
                    // 3 open connection
                    connection.Open();

                    // 4 execute command, use ExecuteReader() for SELECT with multiple rows
                    using (var reader = command.ExecuteReader())
                    {
                        // 5 Loop reader
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["TeacherID"]} : {reader["LastName"]}, {reader["FirstName"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            io.PrintLine("");
            io.ReadString("Press Enter to Continue...");
        }
    }
}
