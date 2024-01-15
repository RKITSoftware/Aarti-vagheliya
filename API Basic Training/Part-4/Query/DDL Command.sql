-- DDL Command

-- Database name
use schoolmanagement ;

-- create bank table
Create table Bnk01 -- 'Bank Table'
(
	k01f01 int Primary key comment 'BankID',
    k01f02 varchar(50) comment 'BankName', 
    k01f03 varchar(30) comment 'BankShortName',
    k01f04 varchar(30) comment 'City'
); 


-- Drop Table
drop table Bnk01;

-- crete table with add comment 
Create table Bnk01 
(
	k01f01 int Primary key comment 'BankID',
    k01f02 varchar(50) comment 'BankName', 
    k01f03 varchar(30) comment 'BankShortName',
    k01f04 varchar(30) comment 'City'
) comment 'Bank table'; 

-- Alter table for add new column  
Alter table Bnk01
add k01f05 varchar(20) comment 'ServiceNumber';

-- select data from bank table
Select 
	Bnk01.k01f01,
    Bnk01.k01f02,
    Bnk01.k01f03,
    Bnk01.k01f04,
    Bnk01.k01f05
from 
	Bnk01;
    