-- DML Command

-- Database name
use schoolmanagement ;

-- Insert data into bank table

INSERT INTO Bnk01 (k01f01, k01f02, k01f03, k01f04, k01f05)
VALUES 
    (1, 'State Bank Of India', 'SBI', 'Rajkot', '123-456-7890'),
    (2, 'Central Bank Of India', 'CBI', 'Morbi', '987-654-3210'),
    (3, 'Bank Of Baroda', 'BOB', 'Surat', '123-654-3210'),
    (4, 'Reserve Bank Of India', 'RBI', 'Delhi', '987-654-4562');


-- Updating data in Bnk01 table
UPDATE Bnk01
SET k01f04 = 'Jamangar'
WHERE k01f01 = 3;

-- Deleting a specific row from Bnk01 table
DELETE FROM Bnk01
WHERE k01f01 = 2;


-- select data from bank table
Select 
	Bnk01.k01f01,
    Bnk01.k01f02,
    Bnk01.k01f03,
    Bnk01.k01f04,
    Bnk01.k01f05
from 
	Bnk01;