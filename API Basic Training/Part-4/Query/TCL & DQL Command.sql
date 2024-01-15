-- TCL Command

-- Database name
use schoolmanagement ;

-- Starting a transaction
START TRANSACTION ;

-- Inserting data within the transaction
INSERT INTO Bnk01 (k01f01, k01f02, k01f03, k01f04, k01f05)
VALUES (2, 'PQR Bank', 'PQR', 'City C', '555-123-4567');


-- select data from bank table
Select 
	*
from 
	Bnk01;
    
    
-- Updating data within the transaction
UPDATE Bnk01
SET k01f03 = 'BOB'
WHERE k01f01 = 3;


-- select data from bank table
Select 
	*
from 
	Bnk01;


-- Rollback the transaction
Rollback;


-- select data from bank table 
Select 
	*
from 
	Bnk01;

 
-- commit transaction  
commit;


-- DQL Command
-- select data from bank table 
Select 
	*
from 
	Bnk01
WHERE 
	k01f01 = 5;