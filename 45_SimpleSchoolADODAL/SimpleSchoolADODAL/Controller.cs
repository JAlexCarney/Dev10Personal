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
            io.PrintLineYellow("Display Class Information");
            io.PrintLineYellow("=========================");
            int sectionId = io.ReadInt("Enter SectionID: ");
            
            // 1 instantiate connection
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var selectSectionSQL = "SELECT "
                    + "Course.CourseName, "
                    + "StartDate, "
                    + "EndDate, "
                    + "Teacher.FirstName, "
                    + "Teacher.LastName "
                    + "FROM Section "
                    + "INNER JOIN Course ON Course.CourseID = Section.CourseID "
                    + "INNER JOIN Teacher ON Teacher.TeacherID = Section.TeacherID "
                    + "INNER JOIN Semester ON Semester.SemesterID = Section.SemesterID "
                    + "INNER JOIN[Period] ON[Period].[PeriodID] = Section.[PeriodID] "
                    + "WHERE SectionID = @SectionId;";

                // 2 instantiate command, give it SQL and the connection to use
                var command = new SqlCommand(selectSectionSQL, connection);
                command.Parameters.AddWithValue("@SectionID", sectionId);

                try
                {
                    // 3 open connection
                    connection.Open();

                    // 4 execute command, use ExecuteReader() for SELECT with multiple rows
                    using (var reader = command.ExecuteReader())
                    {
                        // 5 Loop reader
                        if (reader.Read())
                        {
                            io.PrintLineDarkYellow($"{"Section Id",15}: {sectionId,-20}");
                            io.PrintLineDarkYellow($"{"Course",15}: {reader["CourseName"],-20}");
                            io.PrintLineDarkYellow($"{"Start Date",15}: {reader["StartDate"],-20}");
                            io.PrintLineDarkYellow($"{"End Date",15}: {reader["EndDate"],-20}");
                            io.PrintLineDarkYellow($"{"Teacher",15}: {$"{reader["LastName"]}, {reader["FIrstName"]}",-20}");
                        }
                        else 
                        {
                            io.PrintLineRed($"Failed to find Section with Id {sectionId}.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                var selectStudentsSQL = "SELECT "
                    + "Student.StudentId AS 'Id', "
                    + "LastName, "
                    + "FirstName, "
                    + "CurrentGrade "
                    + "FROM Student "
                    + "INNER JOIN SectionRoster ON Student.StudentID = SectionRoster.StudentID "
                    + "WHERE SectionID = @SectionId;";

                // 2 instantiate command, give it SQL and the connection to use
                var commandTwo = new SqlCommand(selectStudentsSQL, connection);
                commandTwo.Parameters.AddWithValue("@SectionID", sectionId);

                try
                {
                    // 4 execute command, use ExecuteReader() for SELECT with multiple rows
                    io.PrintLineYellow($"{"Id",3} {"Name",-25} {"Grade",5}");
                    using (var reader = commandTwo.ExecuteReader())
                    {
                        // 5 Loop reader
                        while (reader.Read())
                        {
                            string grade = reader["CurrentGrade"] is DBNull ? "N/A" : $"{reader["CurrentGrade"]}";
                            io.PrintLineDarkYellow($"{reader["Id"],3} {$"   {reader["LastName"]}, {reader["FirstName"]}",-25} {grade,5}");
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
