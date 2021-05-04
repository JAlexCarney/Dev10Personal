use GravelFamily;

-- Solve each task by writing a query below the task description.
-- Each task describes the expected result.
-- Unfortunately, tasks must be verified manually. :(

-- Example: Select all columns from the Employee table.
-- Expected: 33 Rows
/*
select * from Employee;
*/

-- Select the EmployeeId, FirstName, and LastName from Employee.
-- Expected: 33 Rows, 3 columns
/*
SELECT
    EmployeeId,
    FirstName,
    LastName
from Employee;
*/

-- Select the EmployeeId, FirstName, and StartDate from Employee
-- where the LastName equals 'Gravel'.
-- Expected: 7 Rows, 3 columns
/*
SELECT 
    EmployeeId,
    FirstName,
    StartDate
FROM Employee
WHERE LastName = 'Gravel';
*/

-- Select FirstName, LastName, and City from Customer
-- where the City equals 'Ajax'.
-- Expected: 13 Rows, 3 columns
/*
SELECT 
    FirstName,
    LastName,
    City
FROM Customer
WHERE City = 'Ajax';
*/

-- Select LastName, EmailAddress, and CustomerSince from Customer
-- for all customers with a CustomerSince value in the year 2019.
-- Expected: 100 Rows, 3 columns
/*
SELECT 
    LastName,
    EmailAddress,
    CustomerSince
FROM Customer
WHERE YEAR(CustomerSince) = 2019;
*/
-- If you solved the previous task without `between`, use `between`.
-- If you used `between`, solve it with `and`.
-- Expected: 100 Rows, 3 columns
/*
SELECT 
    LastName,
    EmailAddress,
    CustomerSince
FROM Customer
WHERE CustomerSince BETWEEN '2019-1-1' AND '2019-12-31';
*/

-- Find 2019 customers a third time, but this time sort them by CustomerSince descending.
-- Expected: 100 Rows, 3 columns
/*
SELECT 
    LastName,
    EmailAddress,
    CustomerSince
FROM Customer
WHERE CustomerSince BETWEEN '2019-1-1' AND '2019-12-31'
ORDER BY CustomerSince ASC;
*/

-- Select FirstName, LastName, Phone, and [Address] from Customer.
-- Sort by LastName descending and FirstName ascending.
-- Expected: 1000 Rows, 4 columns
/*
SELECT 
    FirstName,
    LastName,
    Phone,
    [Address]
FROM Customer
ORDER BY LastName DESC, FirstName ASC;
*/
-- Which Customer City comes last in the alphabet?
-- Expected: Woodstock
/*
SELECT 
    City
FROM Customer
ORDER BY City DESC;
*/

-- Select LastName, [Address], and City from Customer
-- where cities are 'Toronto', 'Brampton', or 'Mississauga'.
-- Expected: 34 Rows, 3 columns
/*
SELECT
    LastName,
    [Address],
    City
FROM Customer
WHERE City in ('Toronto', 'Brampton', 'Mississauga');
*/

-- If you solved the previous task without `in`, use `in`.
-- If you used `in`, solve it with `or` conditions.
-- Expected: 34 Rows, 3 columns
/*
SELECT
    LastName,
    [Address],
    City
FROM Customer
WHERE City = 'Toronto'
    OR City = 'Brampton'
    OR City = 'Mississauga';
*/

-- Find customers who don't live in PostalCode: M3H, K7R, L2V, K7S, or J6A
-- Expected: 874 Rows
/*
SELECT *
FROM Customer
WHERE PostalCode not in ('M3H', 'K7R', 'L2V', 'K7S', 'J6A');
*/

-- Find customer whose last name starts with 'M'.
-- Expected: 76 Rows
/*
SELECT *
FROM Customer
WHERE LastName like 'M%';
*/

-- Find customers with a `(952)` phone area code.
-- Expected: 5 Rows.
/*
SELECT *
FROM Customer
WHERE Phone like '%(952)%';
*/

-- Find customers with a '.com' EmailAddress
-- Expected: 599 Rows.
/*
SELECT *
FROM Customer
WHERE EmailAddress like '%.com';
*/

-- Which customers don't have a phone number?
-- Expected: 68 Rows.
/*
SELECT *
FROM Customer
WHERE ISNULL(Phone, '') = '';
*/

-- Which employees don't have an EndDate?
-- In other words, EndDate has the null value.
-- Expected: 31 Rows.
/*
SELECT *
FROM Employee
WHERE ISNULL(EndDate, '') = '';
*/

-- Find all projects with `Gabion` in the description.
-- Expected: 179 Rows.
/*
SELECT *
FROM Project
WHERE [Description] like '%Gabion%';
*/

-- Select all columns from ProjectItem and sort them
-- by quantity desc. What is the largest quantity? 
-- What is the largest quantity's ProjectId and ItemId?
-- Expected: ProjectId 59, ItemId 2, Quantity 132.00
/*
SELECT *
FROM ProjectItem
ORDER BY Quantity DESC
*/

-- Select a calculated field, FullName, from customer by
-- concatenating the customer's FirstName and LastName
-- where the city equals 'Rayside-Balfour'.
-- Expected 9 Rows, 1 column.
/*
SELECT
    FirstName + ' ' + LastName as 'FullName'
FROM Customer
WHERE City = 'Rayside-Balfour';
*/

-- Select ItemId, [Name], and PricePerUnit from items 
-- that are measured by cubic yards (UnitId = 2)
-- and have a PricePerUnit greater than $50.
-- Expected: 8 Rows, 3 columns
/*
SELECT
    ItemId,
    [Name],
    PricePerUnit
FROM Item
WHERE UnitId = 2
    AND PricePerUnit > 50;
*/

-- The next two tasks require multiple queries to solve.
-- Use the results of one query to write the next query.
-- ==================================================

-- Decide if the customer Mina Ellett has a login record.
-- Step 1: select the CustomerId from Customer for Mina Ellett.
-- Expected: 1 Row
/*
SELECT 
    CustomerId
FROM Customer
Where FirstName = 'Mina'
    AND LastName = 'Ellett';
*/

-- Step 2: use the CustomerId to find a record in the login table.
-- Expected: 0 Rows (no login)
/*
SELECT *
FROM [Login]
WHERE CustomerId = 518;
*/

-- Which employees work on projects for customer Tadeo Divine?
-- Step 1: find Tadeo Divine's CustomerId
-- Expected: 1 Row
SELECT 
    CustomerId
FROM Customer
Where FirstName = 'Tadeo'
    AND LastName = 'Divine';

-- Step 2: use their CustomerId to find their records in the Project table.
-- Expected: 1 Row
SELECT *
FROM Project
WHERE CustomerId = 854;

-- Step 3: use the ProjectId from project to find records in ProjectEmployee
-- Expected: 4 Rows
SELECT *
FROM ProjectEmployee
WHERE ProjectId = 182;

-- Step 4: use the EmployeeIds from ProjectEmployee to find records in Employee
-- Expected: 4 Rows
-- 14	Nevile	Durt	2013-12-12
-- 18	Mercie	Gravel	2013-06-14
-- 23	Urbano	Durt	2011-01-07
-- 32	Fleur	Soyle	2017-03-06
SELECT *
FROM Employee
WHERE EmployeeId in (9, 15, 22, 23);
