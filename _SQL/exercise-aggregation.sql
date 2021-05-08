use GravelFamily;

-- Solve each task by writing a query below the task description.
-- Each task describes the expected result.
-- Unfortunately, tasks must be verified manually. :(

-- Example: 
-- Count the number of customers in Toronto
-- Expected: 14
select count(*)
from Customer
where City = 'Toronto';

-- How many employees have the LastName 'Soyle'?
-- Expected: 12
SELECT count(*)
FROM Employee
WHERE Employee.LastName = 'Soyle';

-- How many projects are there in the database?
-- Expected: 1121
SELECT COUNT(*)
FROM Project;

-- What's the earliest project StartDate?
-- Expected: 2017-09-23
SELECT MIN(Project.StartDate)
FROM Project;

-- What's the latest employee StartDate?
-- Expected: 2020-08-25
SELECT MAX(Employee.StartDate)
FROM Employee;

-- Count customers per city.
-- Expected: 88 Rows
SELECT
    c.City,
    COUNT(*) AS 'Customer Count'
FROM Customer c
GROUP BY c.City;

-- Count customers per PostalCode.
-- Expected: 84 Rows
SELECT
    COUNT(*)
FROM Customer
GROUP BY Customer.PostalCode;

-- Count employees per LastName.
-- Expected: 3 Rows
SELECT
    COUNT(*)
FROM Employee
GROUP BY Employee.LastName;

-- Count the number of projects per city.
-- (Hint: requires a join.)
-- Expected: 88 Rows
SELECT 
    COUNT(*)
FROM Customer c
JOIN Project ON Project.CustomerId = c.CustomerId
GROUP BY c.City;

-- Count the number of projects per city.
-- Sort by the count descending and select the top 10 rows.
-- Expected: 10 Rows
SELECT TOP(10)
    COUNT(*)
FROM Customer c
JOIN Project ON Project.CustomerId = c.CustomerId
GROUP BY c.City
ORDER BY COUNT(*) DESC;

-- Which PostalCode has the most projects?
-- Expected: M3H and K7R
SELECT TOP(2)
    c.PostalCode,
    COUNT(*)
FROM Customer c
JOIN Project ON Project.CustomerId = c.CustomerId
GROUP BY c.PostalCode
ORDER BY COUNT(*) DESC;

-- Count the number of projects per StartDate year.
-- Expected: 4 Rows
SELECT COUNT(*)
FROM Project
GROUP BY YEAR(Project.StartDate);

-- Count the number of employees per project in the M3H PostalCode.
-- Group by ProjectId, sort by count descending.
-- Expected: 39 Rows
SELECT COUNT(*)
FROM ProjectEmployee
INNER JOIN Project ON ProjectEmployee.ProjectId = Project.ProjectId
INNER JOIN Employee ON Employee.EmployeeId = ProjectEmployee.EmployeeId
INNER JOIN Customer ON Customer.CustomerId = Project.CustomerId
WHERE Customer.PostalCode = 'M3H'
GROUP BY ProjectEmployee.ProjectId;

-- Calculate the total cost per project in the 'M3H' PostalCode.
-- (Hint: sum a calculation)
-- Expected: 39 Rows


-- What's the most expensive project in the 'M3H' PostalCode?
-- Expected: 18828.00

-- How many projects did each employee work on?
-- Expected: 33 Rows

-- How many employees worked on more than 140 projects?
-- Expected: 10 Rows

-- How many projects cost more than $20,000?
-- Expected: 55 Rows

-- Across all projects, what are the total costs per item?
-- Select the item name and sum.
-- Sort by the sum desc;
-- Expected: 18 Rows

-- Across all projects, what are the total costs per item category?
-- Select the category name and sum.
-- Sort by the sum desc;
-- Expected: 7 Rows

-- What's the average 'Standard Labor' cost per city?
-- Expected: 88 Rows

-- Challenge: Which customer has the first project of 2019?
-- (Requires a subquery.)
-- Expected: Starkie 2019-01-01