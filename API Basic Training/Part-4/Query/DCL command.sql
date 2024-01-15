-- DCL Command

-- Database name
use schoolmanagement ;

-- create user
create user 
	'aarti.v';
    
-- Grant command
-- Granting privileges to the user
GRANT 
	SELECT, INSERT, DELETE
ON 
	schoolmanagement.Bnk01 
TO 
	'aarti.v';

-- Insert data successfully
INSERT INTO Bnk01 (k01f01, k01f02, k01f03, k01f04, k01f05)
VALUES 
    (5, 'Central Bank Of India', 'CBI', 'Morbi', '987-654-3210');

-- update not perform 
UPDATE Bnk01
SET k01f04 = 'Jamangar'
WHERE k01f01 = 3;
    
-- revoke command
-- Revoking privileges from the user
REVOKE 
	SELECT, INSERT, UPDATE, DELETE 
ON 
	schoolmanagement.Bnk01  
FROM 
	'aarti.v';
    
-- select data from bank table
Select 
	Bnk01.k01f01,
    Bnk01.k01f02,
    Bnk01.k01f03,
    Bnk01.k01f04,
    Bnk01.k01f05
from 
	Bnk01;

