using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDemo
{
    public class ConsoleIO
    {
        public static void PrintLineYellow(string message) 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void PrintLineDarkYellow(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static Employee PromptUserEmployee()
        {
            Employee employee = new Employee();
            employee.FirstName = PromptUser("Enter a first name: ");
            employee.LastName = PromptUser(" Enter a last name: ");
            employee.StartDate = PromptUserDate("  Enter start Date: ");
            employee.EndDate = PromptUserDate("  Enter start Date: ");
            return employee;
        }

        public static Customer PromptUserCustomer()
        {
            Customer customer = new Customer();
            customer.FirstName = PromptUser("    Enter a first name: ");
            customer.LastName = PromptUser("     Enter a last name: ");
            customer.EmailAddress = PromptUser("Enter an email address: ");
            customer.Phone = PromptUser("  Enter a phone number: ");
            customer.Address = PromptUser("      Enter an address: ");
            customer.City = PromptUser("          Enter a city: ");
            customer.Province = PromptUser("      Enter a province: ");
            customer.PostalCode = PromptUser("   Enter a postal code: ");
            customer.CustomerSince = PromptUserDate("      Enter start date: ");

            return customer;
        }

        public static DateTime PromptUserDate(string message)
        {
            DateTime result;
            while (!DateTime.TryParse(PromptUser(message), out result))
            {
                Console.WriteLine("Invalid date");
            }
            return result;
        }

        public static string PromptUser(string message)
        {
            Console.Write(message);
            Console.ForegroundColor = ConsoleColor.Cyan;
            string output = Console.ReadLine();
            Console.ResetColor();
            return output;
        }

        public static int PromptUserInt(string message)
        {
            int result;
            while (!int.TryParse(PromptUser(message), out result))
            {
                Console.WriteLine("Invalid date");
            }
            return result;
        }
    }
}
