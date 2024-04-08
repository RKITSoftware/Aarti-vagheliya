-- 
-- Create the grades table
CREATE TABLE IF NOT EXISTS grd01 (
    d01f01 INT,
    d01f02 INT
);

-- Insert some sample data into the grades table
INSERT INTO grd01 (d01f01, d01f02) VALUES
    (1, 85),
    (2, 90),
    (3, 75),
    (4, 65),
    (5, 99);

SET SQL_SAFE_UPDATES = 0;

-- Update the students table to set the grade based on the marks
UPDATE std01 AS s
        JOIN
    grd01 AS g ON s.d01f01 = g.d01f01 
SET 
    s.d01f08 = g.d01f02;
   
-- Select the updated data from the students table
SELECT * FROM std01;






EXPLAIN SELECT 
    A.*, B.*, C.*
FROM
    bnk01 A
        LEFT JOIN
    brn01 B ON A.k01f01 = B.n01f04
        INNER JOIN
    fac01 C ON B.n01f01 = C.c01f09;





SELECT P01F04, COUNT(*) AS EmployeeCount, AVG(P01F06) AS AvgSalary
FROM emp01
GROUP BY P01F04
HAVING AVG(P01F06) > 5000
ORDER BY EmployeeCount DESC
LIMIT 5;


-- Function in Mysql

DELIMITER //
CREATE FUNCTION get_number_of_distinctions(minmarks INT) RETURNS INT
DETERMINISTIC
BEGIN
    DECLARE count_distinctions INT DEFAULT 0;
    SELECT COUNT(d01f01) INTO count_distinctions FROM std01 WHERE d01f08 >= minmarks;
    RETURN count_distinctions;
END //
DELIMITER ;

-- Excecute function
SELECT get_number_of_distinctions(80) AS number_of_distinctions;


-- If statement 
SELECT 
    d01f01,
    d01f02,
    IF(d01f08 >= 60, 'Pass', 'Fail') AS result
FROM 
    std01;
    
    
 -- CASE - WHEN Syntax   
SELECT 
   d01f01,
    d01f02,
    CASE
        WHEN d01f08 >= 90 THEN 'A'
        WHEN d01f08 >= 80 THEN 'B'
        WHEN d01f08 >= 70 THEN 'C'
        ELSE 'D'
    END AS grade
FROM 
    std01;

