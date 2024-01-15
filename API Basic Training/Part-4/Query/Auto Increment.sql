-- crate faculty table 
Create table Fac01 -- 'Faculty Table'
(
	c01f01 int auto_increment primary key comment 'FacultyID',
    c01f02 varchar(50) comment 'FirstName', 
    c01f03 varchar(50) comment 'LastName',
    c01f04 date comment 'DateOfBirth',
    c01f05 varchar(10) comment 'Gender',
    c01f06 varchar(30) comment 'Email' ,
    c01f07 varchar(30) comment 'ContactNumber',
    c01f08 varchar(20) comment 'Department'
);

-- Inserting sample data
INSERT INTO Fac01 (c01f02, c01f03, c01f04, c01f05, c01f06, c01f07, c01f08)
VALUES
    ('John', 'Doe', '1995-07-25', 'Male', 'john.doe@example.com', '+91 7896541235', 'CE'),
    ('Alice', 'Smith', '1996-06-15', 'Male',  'alice.smith@example.com', '+91 7853641235', 'ME');

-- change auto increment value
ALTER TABLE Fac01 AUTO_INCREMENT=101;

-- insert new value after alter 
INSERT INTO Fac01 (c01f02, c01f03, c01f04, c01f05, c01f06, c01f07, c01f08)
VALUES
    ('ABC', 'Doe', '1985-07-18', 'FEmale', 'abc.doe@example.com', '+91 7896541235', 'CIVIL');


-- retrive data from faculty table
select 
	c01f01,
    c01f02,
    c01f03,
    c01f04,
    c01f05,
    c01f06,
    c01f07,
    c01f08
from
	Fac01;
