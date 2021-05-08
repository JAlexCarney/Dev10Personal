USE GravelFamily;

SELECT 
    Customer.CustomerId,
    Customer.FirstName,
    Customer.LastName,
    Employee.EmployeeId,
    Employee.FirstName,
    Employee.LastName
FROM Customer
INNER JOIN Employee ON Employee.FirstName = Customer.FirstName;