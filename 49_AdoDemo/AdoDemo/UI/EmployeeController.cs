using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDemo
{
    public class EmployeeController
    {
        private IEmployeeRepository _employeeRepository;
        private ICustomerRepository _customerRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, ICustomerRepository customerRepository)
        {
            _employeeRepository = employeeRepository;
            _customerRepository = customerRepository;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                ConsoleIO.PrintLineYellow("Gravel Family Data Manager");
                ConsoleIO.PrintLineYellow("==========================");
                ConsoleIO.PrintLineYellow("");
                ConsoleIO.PrintLineYellow("Main Menu");
                ConsoleIO.PrintLineYellow("=========");
                ConsoleIO.PrintLineDarkYellow("1. Display Employees");
                ConsoleIO.PrintLineDarkYellow("2. Add Employee");
                ConsoleIO.PrintLineDarkYellow("3. Edit Employee");
                ConsoleIO.PrintLineDarkYellow("4. Remove Employee");
                ConsoleIO.PrintLineDarkYellow("5. Display Customers");
                ConsoleIO.PrintLineDarkYellow("6. Add Customer");
                ConsoleIO.PrintLineDarkYellow("7. Edit Customer");
                ConsoleIO.PrintLineDarkYellow("8. Remove Customer");
                ConsoleIO.PrintLineDarkYellow("9. Exit");
                int choice = ConsoleIO.PromptUserInt("Enter Choice: ");
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        ConsoleIO.PrintLineYellow($"Employees");
                        ConsoleIO.PrintLineYellow($"=========");
                        foreach (var emp in _employeeRepository.ReadAll())
                        {
                            ConsoleIO.PrintLineDarkYellow($"{emp.EmployeeId,5} : {emp.FirstName}, {emp.LastName}");
                        }
                        break;
                    case 2:
                        Console.Clear();
                        ConsoleIO.PrintLineYellow($"Adding Employee");
                        ConsoleIO.PrintLineYellow($"===============");
                        Employee employee1 = ConsoleIO.PromptUserEmployee();
                        _employeeRepository.Create(employee1);
                        break;
                    case 3:
                        Console.Clear();
                        ConsoleIO.PrintLineYellow($"Updating Employee");
                        ConsoleIO.PrintLineYellow($"=================");
                        int Id1 = ConsoleIO.PromptUserInt("Enter Employee Id: ");
                        Employee employee2 = ConsoleIO.PromptUserEmployee();
                        employee2.EmployeeId = Id1;
                        _employeeRepository.Update(employee2);
                        break;
                    case 4:
                        Console.Clear();
                        ConsoleIO.PrintLineYellow($"Delete Employee");
                        ConsoleIO.PrintLineYellow($"===============");
                        int Id2 = ConsoleIO.PromptUserInt("Enter Employee Id: ");
                        _employeeRepository.Delete(Id2);
                        break;
                    case 5:
                        Console.Clear();
                        ConsoleIO.PrintLineYellow($"Customers");
                        ConsoleIO.PrintLineYellow($"=========");
                        foreach (var cust in _customerRepository.ReadAll())
                        {
                            ConsoleIO.PrintLineDarkYellow($"{cust.CustomerId,5} : {$"{cust.FirstName}, {cust.LastName}",25} : {cust.EmailAddress}");
                        }
                        break;
                    case 6:
                        Console.Clear();
                        ConsoleIO.PrintLineYellow($"Add Customer");
                        ConsoleIO.PrintLineYellow($"============");
                        Customer customer1 = ConsoleIO.PromptUserCustomer();
                        _customerRepository.Create(customer1);
                        break;
                    case 7:
                        Console.Clear();
                        ConsoleIO.PrintLineYellow($"Update Customer");
                        ConsoleIO.PrintLineYellow($"===============");
                        int Id3 = ConsoleIO.PromptUserInt("Enter Customer Id: ");
                        Customer customer2 = ConsoleIO.PromptUserCustomer();
                        customer2.CustomerId = Id3;
                        _customerRepository.Update(customer2);
                        break;
                    case 8:
                        Console.Clear();
                        ConsoleIO.PrintLineYellow($"Delete Customer");
                        ConsoleIO.PrintLineYellow($"===============");
                        int Id4 = ConsoleIO.PromptUserInt("Enter Customer Id: ");
                        _customerRepository.Delete(Id4);
                        break;
                    case 9:
                        return;

                }
                ConsoleIO.PromptUser("Press Enter To Continue...");
            }
        }
    }
}
