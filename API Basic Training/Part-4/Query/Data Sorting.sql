ALTER TABLE std01
ADD d01f08 int;



    
 
SET SQL_SAFE_UPDATES = 0;
   
  -- Update the 'grade' column for existing students
update std01
set d01f08 = 80
where d01f01 = 4;


-- Sorting column by grade in ascending order
Select 
	* 
From 
	Std01
order by d01f08;

-- Sorting column by grade in descending order
Select 
	* 
From 
	Std01
order by d01f08 desc

  