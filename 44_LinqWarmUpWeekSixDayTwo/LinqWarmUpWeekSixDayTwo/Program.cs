using System.Linq;
using System.Collections.Generic;
using System.IO;
using System;

namespace LinqWarmUpWeekSixDayTwo
{
    class Program
    {
        private static ConsoleIO io = new ConsoleIO();
        private static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            io.PrintLineYellow("Welcome to the employee report system!");
            ReadInEmployees();
            io.PrintLineGreen($"{employees.Count} employees loaded");

            int choice = io.ReadInt("1. Top Earners By State\n2. Average Salary By State\n3. Number of Employees By State\nEnter Choice: ", 1, 3);
            switch (choice)
            {
                case 1:
                    DisplayTopEarnerByStateReport();
                    break;
                case 2:
                    DisplayAverageSalaryByStateReport();
                    break;
                case 3:
                default:
                    DisplayTotalNumberOfEmployeesByState();
                    break;
            }
        }

        public static void ReadInEmployees() 
        {
            string[] lines = null;
            try
            {
                lines = File.ReadAllLines("employees.csv");
            }
            catch (IOException ex)
            {
                io.PrintLineRed("Failed To Read!");
                throw new Exception("Failed To Read!", ex);
            }

            for (int i = 0; i < lines.Length; i++)
            {
                string[] fields = lines[i].Split(",", StringSplitOptions.TrimEntries);
                Employee employee = DeserializeEmployee(fields);
                if (employee != null)
                {

                    employees.Add(employee);
                }
            }
        }

        public static void DisplayTopEarnerByStateReport() 
        {
            var query = employees
                .GroupBy(g => g.State)
                .Select(g => new
                {
                    g.Key,
                    employee = g.OrderByDescending(g => g.Salary)
                                .FirstOrDefault()
                });
            foreach (var group in query) 
            {
                io.PrintLineDarkYellow($"State: {group.Key} => Top Earner: {SerializeEmployee(group.employee)}");
            }
        }

        public static void DisplayAverageSalaryByStateReport() 
        {
            var query = employees.GroupBy(g => g.State)
                .Select(g => new
                {
                    g.Key,
                    averageSalary = g.Average(g => g.Salary)
                });
            foreach (var group in query)
            {
                io.PrintLineDarkYellow($"State: {group.Key} => Average Salary: {group.averageSalary:C}");
            }
        }

        public static void DisplayTotalNumberOfEmployeesByState() 
        {
            var countByState = employees
                .GroupBy(e => e.State)
                .Select(e => new
                {
                    State = e.Key,
                    Count = e.Count()
                }).ToList();

            foreach (var group in countByState)
            {
                io.PrintLineDarkYellow($"State: {group.State} => Number of Employees: {group.Count}");
            }
        }

        public static string SerializeEmployee(Employee employee)
        {
            //1,Isidor,Turton,NY,$48869.02
            return $"ID: {employee.Id}, Name:{employee.FirstName} {employee.LastName}, Salary:{employee.Salary:C}";
        }

        public static Employee DeserializeEmployee(string[] fields) 
        {
            //1,Isidor,Turton,NY,$48869.02
            return new Employee
            {
                Id = int.Parse(fields[0]),
                LastName = fields[1],
                FirstName = fields[2],
                State = fields[3],
                Salary = decimal.Parse(fields[4].Substring(1))
            };
        }
    }
}