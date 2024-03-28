-- DDL Command

-- Database name
USE schoolmanagement ;

-- create bank table
CREATE TABLE Bnk01 -- 'Bank Table'
(
	k01f01 INT PRIMARY KEY comment 'BankID',
    k01f02 VARCHAR(50) comment 'BankName', 
    k01f03 VARCHAR(30) comment 'BankShortName',
    k01f04 VARCHAR(30) comment 'City'
); 


-- Drop Table
DROP TABLE Bnk01;

-- crete table with add comment 
CREATE TABLE Bnk01 
(
	k01f01 INT PRIMARY KEY comment 'BankID',
    k01f02 VARCHAR(50) comment 'BankName', 
    k01f03 VARCHAR(30) comment 'BankShortName',
    k01f04 VARCHAR(30) comment 'City'
) comment 'Bank table'; 

-- Alter table for add new column  
ALTER TABLE Bnk01
ADD k01f05 VARCHAR(20) comment 'ServiceNumber';

-- select data from bank table
SELECT 
	Bnk01.k01f01,
    Bnk01.k01f02,
    Bnk01.k01f03,
    Bnk01.k01f04,
    Bnk01.k01f05
FROM 
	Bnk01;
    