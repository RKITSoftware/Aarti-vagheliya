-- Database name
use schoolmanagement ;

-- COUNT() - Count the number of students:
SELECT COUNT(*) AS TotalStudents
FROM Std01;

-- SUM() - Calculate the total Marks:
SELECT SUM(d01f08) AS TotalMarks
FROM Std01;


-- AVG() - Calculate the average age (assuming DateOfBirth is in years):
SELECT AVG(YEAR(CURDATE()) - YEAR(d01f04)) AS AverageAge
FROM Std01;


-- MIN() - Find the earliest DateOfBirth:
SELECT MIN(d01f04) AS EarliestDOB
FROM Std01;


-- MAX() - Find the latest DateOfBirth:
SELECT MAX(d01f04) AS LatestDOB
FROM Std01;


-- GROUP BY - Count the number of students by gender:
SELECT d01f05 AS Gender, COUNT(*) AS TotalStudents
FROM Std01
GROUP BY d01f05;
