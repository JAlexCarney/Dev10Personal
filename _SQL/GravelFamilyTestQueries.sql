BEGIN TRANSACTION;

    DELETE [Login]
    WHERE CustomerId = 1;
    
    DELETE ProjectItem
    WHERE  ProjectItem.ProjectId = (SELECT ProjectId FROM Project WHERE Project.CustomerId = 1);

    DELETE ProjectEmployee
    WHERE ProjectEmployee.ProjectId = (SELECT ProjectId FROM Project WHERE Project.CustomerId = 1);

    DELETE Project
    WHERE CustomerId = 1;
    
    DELETE Customer
    WHERE CustomerId = 1;

    SELECT * FROM Customer; 
ROLLBACK;
