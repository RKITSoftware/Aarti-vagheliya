-- crate table 
Create table Std01 -- 'Student Table'
(
	d01f01 int  comment 'StudentID',
    d01f02 varchar(50) comment 'FirstName', 
    d01f03 varchar(50) comment 'LastName',
    d01f04 date comment 'DateOfBirth',
    d01f05 varchar(10) comment 'Gender',
    d01f06 varchar(30) comment 'Email' ,
    d01f07 varchar(30) comment 'ContactNumber'
);

-- insert query
Insert into Std01 value(1, 'Arti', 'Vagheliya', '2002-09-25', 'Female', 'arti@gmail.com', '+91 1234567891');
Insert into Std01 value(2, 'Ishika', 'Jethwa', '2002-09-15', 'Female', 'ishika@gmail.com', '+91 1234564491');
Insert into Std01 value(3, 'Dimple', 'Mithiya', '2002-08-25', 'Female', 'dimple@gmail.com', '+91 1234789891');
Insert into Std01 value(4, 'Krinsi', 'Kayada', '2001-09-25', 'Female', 'krinsi@gmail.com', '+91 9834567891');


-- upade synatax
update std01
set d01f01 = 2
where d01f02 = 'Ishika';


SET SQL_SAFE_UPDATES = 0;


-- delete asynatax
delete from 
	std01
where 
	d01f02 = 'Krinsi';


-- select syntax
Select 
	* 
From 
	Std01
