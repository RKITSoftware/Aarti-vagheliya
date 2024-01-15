-- Database name
use schoolmanagement ;

-- perform all subquery on student table

--  1) Subquery in WHERE clause - Find students older than the average age:
SELECT 
	d01f02 AS FirstName, d01f04 AS DOB
FROM 
	Std01
WHERE YEAR(CURDATE()) - YEAR(d01f04) > (SELECT 
											AVG(YEAR(CURDATE()) - YEAR(d01f04)) 
										FROM Std01
                                        );
                                        
                                        
-- 2) Subquery in SELECT clause - Display each student's age relative to the average:
SELECT 
	d01f02, 
	YEAR(CURDATE()) - YEAR(d01f04) AS Age,
	(SELECT 
		AVG(YEAR(CURDATE()) - YEAR(d01f04)) 
	FROM Std01) AS AvgAge
FROM 
	Std01;
    
    
-- 3) Subquery in FROM clause - Find the total number of students in each gender:
SELECT 
	Gender, 
	COUNT(*) AS TotalStudents
FROM 
	(SELECT 
		d01f05 AS Gender 
	FROM 
		Std01) AS GenderSubquery
GROUP BY 
	Gender;



