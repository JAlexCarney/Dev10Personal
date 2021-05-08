use GravelFamily;

-- Solve each task by writing a query below the task description.
-- Each task describes the expected result.
-- Unfortunately, tasks must be verified manually. :(

-- Example: 
-- Select FirstName and LastName from Customer,
-- UserName from Login where rows from both tables are required.
-- Expected: 659 Rows
/*
select
    c.FirstName,
    c.LastName,
    l.UserName
from Customer c
    inner join Login l on c.CustomerId = l.CustomerId;
*/

-- Select FirstName and LastName from Customer,
-- UserName from Login where rows from both tables are required.
-- Sort by UserName descending.
-- Expected: 659 Rows
/*
SELECT
    Customer.FirstName,
    Customer.LastName,
    [Login].UserName
FROM Customer
INNER JOIN [Login] ON Customer.CustomerId = [Login].CustomerId
ORDER BY [Login].UserName;
*/

-- Select FirstName and LastName from Customer,
-- UserName from Login where rows from both tables are required.
-- Only customers whose last name starts with 'W'.
-- Sort by UserName descending.
-- Expected: 24 Rows
/*
SELECT
    Customer.FirstName,
    Customer.LastName,
    [Login].UserName
FROM Customer
INNER JOIN [Login] ON Customer.CustomerId = [Login].CustomerId
WHERE Customer.LastName LIKE 'W%';
*/

-- Join Item and Category. Select the item name and category name.
-- Expected: 19 Rows
/*
SELECT
    Item.Name,
    Category.Name
FROM Item
LEFT OUTER JOIN Category ON Item.CategoryId = Category.CategoryId;
*/

-- Join item and category. Select the item name and category name.
-- Create an alias for each column: ItemName and CategoryName
-- Sort by the CategoryName, then ItemName.
-- Expected: 19 Rows
/*
SELECT
    Item.Name as 'ItemName',
    Category.Name as 'CategoryName'
FROM Item
INNER JOIN Category on Item.CategoryId = Category.CategoryId
ORDER BY CategoryName ASC, ItemName ASC;
*/

-- Select Name and PricePerUnit from Item,
-- Name from Unit. Make rows from both tables required.
-- Add column aliases to avoid confusion from two `Name` columns.
-- Expected: 19 Rows
/*
SELECT
    Item.Name AS 'ItemName',
    Item.PricePerUnit,
    Unit.Name AS 'UnitName'
FROM Item
INNER JOIN Unit ON Unit.UnitId = Item.UnitId;
*/

-- Select all columns from Item, Category, and Unit.
-- Make all rows required.
-- Expected: 19 Rows
/*
SELECT *
FROM Item
INNER JOIN Category ON Item.CategoryId = Category.CategoryId
INNER JOIN Unit ON Item.UnitId = Unit.UnitId; 
*/

-- Select FirstName, LastName from Customer,
-- select Description from Project,
-- where the customer's LastName starts with 'B' or 'D'.
-- If a customer doesn't have a project, still include them.
-- (Hint: left outer join)
-- Expected: 228 Rows
/*
SELECT
    Customer.FirstName,
    Customer.LastName,
    Project.[Description]
FROM Customer
LEFT OUTER JOIN Project ON Customer.CustomerId = Project.CustomerId
WHERE Customer.LastName like 'B%'
    OR Customer.LastName like 'D%';
*/

-- Find all customers who do not have a project.
-- Expected: 195 Rows
/*
SELECT *
FROM Customer
LEFT OUTER JOIN Project ON Customer.CustomerId = Project.CustomerId
WHERE Project.ProjectId is null;
*/

-- Find all customers who do not have a login.
-- Expected: 341 Rows
/*
SELECT *
FROM Customer
LEFT OUTER JOIN [Login] ON Customer.CustomerId = [Login].CustomerId
WHERE [Login].CustomerId is null;
*/

-- Find all employees who are not assigned to a project.
-- Expected: 0 Rows
/*
SELECT *
FROM Employee
LEFT OUTER JOIN ProjectEmployee ON Employee.EmployeeId = ProjectEmployee.EmployeeId
WHERE ProjectEmployee.EmployeeId is null;
*/

-- Select EmployeeId, FirstName, and LastName from Employee,
-- ProjectId and Description from Project
-- where the employee LastName equals `Gravel`.
-- Expected: 958 Rows
/*
SELECT
    Employee.EmployeeId,
    Employee.FirstName,
    Employee.LastName,
    Project.ProjectId,
    Project.[Description] as 'ProjectDescription'
FROM Employee
INNER JOIN ProjectEmployee ON Employee.EmployeeId = ProjectEmployee.EmployeeId
INNER JOIN Project ON ProjectEmployee.ProjectId = Project.ProjectId
WHERE Employee.LastName = 'Gravel';
*/

-- Which employees worked on a project for the customer
-- with last_name equal to 'Rao'?
-- Expected: Itch Gravel, Alang Durt, Ynez Durt, Ddene Soyle,
-- Mychal Soyle, Hugo Durt
/*
SELECT 
    Employee.FirstName + ' ' +Employee.LastName as "EmployeeName"
FROM Employee
    LEFT OUTER JOIN ProjectEmployee ON Employee.EmployeeId = ProjectEmployee.EmployeeId
    INNER JOIN Project ON ProjectEmployee.ProjectId = Project.ProjectId
    INNER JOIN Customer ON Project.CustomerId = Customer.CustomerId
WHERE Customer.LastName = 'Rao';
*/

-- Find employees and projects for projects in 2017.
-- Select ProjectId from Project and names from Employee.
-- Expected: 410 Rows
/*
SELECT *
FROM Employee
    INNER JOIN ProjectEmployee ON Employee.EmployeeId = ProjectEmployee.EmployeeId
    INNER JOIN Project ON ProjectEmployee.ProjectId = Project.ProjectId
WHERE YEAR(Project.StartDate) = 2017;
*/

-- Create an "invoice" with line item totals (calculated field)
-- for items billed to projects for the customer with LastName 'Stelfox'.
-- Include the customer's names, ProjectId, item name, and calculated cost.
-- Expected:
-- Lanie Stelfox 481 Machine Labor     9720.000000
-- Lanie Stelfox 481 Standard Labor    3675.000000
-- Lanie Stelfox 481 Construction Sand 336.000000
-- Lanie Stelfox 481 Class 5 Gravel    624.000000
-- Lanie Stelfox 481 Wall Stone        3452.100000
/*
SELECT
    Customer.FirstName + ' ' + Customer.LastName AS 'CustomerName',
    Project.ProjectId,
    Item.Name AS 'ItemName',
    Item.PricePerUnit * ProjectItem.Quantity AS 'Cost'
FROM Customer
    INNER JOIN Project ON Project.CustomerId = Customer.CustomerId
    INNER JOIN ProjectItem ON ProjectItem.ProjectId = Project.ProjectId
    INNER JOIN Item ON ProjectItem.ItemId = Item.ItemId
WHERE Customer.LastName = 'Stelfox';
*/

-- Determine which customers employee Fleur Soyle worked for in
-- the 'M3H' postal_code. All customers in the postal_code should be included
-- regardless of if they have a project or Fleur worked on it.
-- Though something should indicate if Fleur was on a M3H project.
-- Expected: 48 Rows, 3 projects that Fleur worked on.
/*
SELECT
    *
FROM Customer
    LEFT OUTER JOIN Project ON Project.CustomerId = Customer.CustomerId
    LEFT JOIN ProjectEmployee ON Project.ProjectId = ProjectEmployee.ProjectId AND ProjectEmployee.EmployeeId = 32
    LEFT OUTER JOIN Employee ON Employee.EmployeeId = ProjectEmployee.EmployeeId
WHERE Customer.PostalCode = 'M3H';
*/

-- Find customers without logins using a `right outer` join.
-- Expected: 341 Rows
/*
SELECT *
FROM [Login]
    RIGHT OUTER JOIN Customer ON Customer.CustomerId = [Login].CustomerId
WHERE [Login].CustomerId IS NULL;
*/

-- List category with its parent category, but make the parent category
-- optional to include categories without a parent.
-- Expected: 8 Rows
/*
SELECT *
FROM Category c
    LEFT OUTER JOIN Category ON c.ParentCategoryId = Category.CategoryId;
*/

-- Write an "everything" query:
-- CustomerId and names from customer
-- Description from Project
-- Quantity from ProjectItem
-- Name from Item
-- Name from Category
-- Name from Unit
-- for customers in the 'L3K' postal_code.
-- Expected: 39 Rows
SELECT
    Customer.CustomerId,
    Project.[Description],
    ProjectItem.Quantity,
    Item.Name AS 'Item Name',
    Category.Name AS 'Category Name',
    Unit.Name AS 'Unit Name'
FROM Customer
    INNER JOIN Project ON Customer.CustomerId = Project.CustomerId
    INNER JOIN ProjectItem ON ProjectItem.ProjectId = Project.ProjectId
    INNER JOIN Item ON ProjectItem.ItemId = Item.ItemId
    INNER JOIN Unit ON Item.UnitId = Unit.UnitId
    INNER JOIN Category ON Item.CategoryId = Category.CategoryId
WHERE Customer.PostalCode = 'L3K';