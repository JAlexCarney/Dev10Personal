-- This is a comment

/* this is also a comment */

use AirbnbNewYork; -- Very important to make sure this is the correct database

select
    [Name],
    Neighborhood,
    HostName
from Listing
where [HostName] like '%J%';


