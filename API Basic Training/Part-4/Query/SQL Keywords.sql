-- Create the schoolmanagement database
CREATE DATABASE IF NOT EXISTS schoolmanagement;

USE schoolmanagement;

-- Create the DEP01 table
CREATE TABLE IF NOT EXISTS DEP01 (
    P01F01 INT AUTO_INCREMENT PRIMARY KEY COMMENT 'DepartmentID',
    P01F02 VARCHAR(50) COMMENT 'DepartmentName'
);


-- Create the EMP01 table
CREATE TABLE IF NOT EXISTS EMP01 (
    P01F01 INT AUTO_INCREMENT PRIMARY KEY COMMENT 'EmployeeID',
    P01F02 VARCHAR(50) COMMENT 'FirstName',
    P01F03 VARCHAR(50) COMMENT 'LastName',
    P01F04 INT COMMENT 'DepartmentID',
    P01F05 VARCHAR(50) COMMENT 'Position',
    P01F06 DECIMAL(10 , 2 ) COMMENT 'Salary',
    P01F07 DATE COMMENT 'HireDate',
    CONSTRAINT FK_DEP_EMP01 FOREIGN KEY (P01F04)
        REFERENCES DEP01 (P01F01)
);


-- Create the SLH01 table
CREATE TABLE IF NOT EXISTS SLH01 (
    H01F01 INT AUTO_INCREMENT PRIMARY KEY COMMENT 'SalaryHistoryID',
    H01F02 INT COMMENT 'EmployeeID',
    H01F03 DECIMAL(10 , 2 ) COMMENT 'OldSalary',
    H01F04 DECIMAL(10 , 2 ) COMMENT 'NewSalary',
    H01F05 DATE COMMENT 'ChangeDate',
    CONSTRAINT FK_EMP01_SLH01 FOREIGN KEY (H01F02)
        REFERENCES EMP01 (P01F01)
);

-- Create some sample data
INSERT INTO DEP01 (P01F02) VALUES ('Human Resources'), ('Finance'), ('IT');

INSERT INTO EMP01 (P01F02, P01F03, P01F04, P01F05, P01F06, P01F07) 
VALUES 
    ('ABC', 'abc', 1, 'HR Manager', 5000.00, '2023-01-15'),
    ('PQR', 'pqr', 2, 'Accountant', 4500.00, '2022-08-20'),
    ('XYZ', 'xyz', 3, 'IT Specialist', 5500.00, '2023-03-10');

-- Display the tables
SELECT 
    *
FROM
    EMP01;
    
    
SELECT 
    *
FROM
    DEP01;
    
    
SELECT 
    *
FROM
    SLH01;

-- ADD CONSTRAINT: Add a foreign key constraint
ALTER TABLE EMP01 ADD CONSTRAINT FK_DEP_EMP FOREIGN KEY (P01F04) REFERENCES DEP01(P01F01);

-- ALL: Selects employees using subQuery
SELECT 
    *
FROM
    EMP01
WHERE
    P01F04 >= ALL (SELECT 
            P01F01
        FROM
            DEP01);


-- ALTER COLUMN: Change the data type of the Position column
ALTER TABLE EMP01 MODIFY P01F05 VARCHAR(100);

-- AND: Select employees who work in the Finance department and have a salary greater than 4000
SELECT 
    *
FROM
    EMP01
WHERE
    P01F04 = 2 AND P01F06 > 4000;

-- AS: Rename the DepartmentName column as DeptName
SELECT 
    P01F02 AS DeptName
FROM
    DEP01;

-- ASC: Sort the employees by their hire date in ascending order
SELECT 
    *
FROM
    EMP01
ORDER BY P01F07 ASC;

-- BETWEEN: Select employees hired between two dates
SELECT 
    *
FROM
    EMP01
WHERE
    P01F07 BETWEEN '2022-01-01' AND '2023-01-01';

-- CASE: Create different outputs based on the Position
SELECT 
    P01F01,
    P01F02,
    P01F03,
    P01F05,
    CASE
        WHEN P01F05 = 'HR Manager' THEN 'Senior Management'
        WHEN P01F05 = 'Accountant' THEN 'Finance Department'
        ELSE 'Other'
    END AS DEPTYPE
FROM
    EMP01;

-- CONSTRAINT: Create a UNIQUE constraint on the DepartmentName column
ALTER TABLE DEP01 ADD CONSTRAINT UQ_DEPNF01 UNIQUE (P01F02);

-- CREATE INDEX: Create an index on the Position column
CREATE INDEX IDX_POSF01 ON EMP01(P01F05);

-- CREATE PROCEDURE: Create a stored procedure to calculate the average salary
DELIMITER //
CREATE PROCEDURE CALC_AVG_SAL()
BEGIN
    SELECT AVG(P01F06) AS AVG_SALARY FROM EMP01;
END //
DELIMITER ;

-- DELETE: Delete an employee record
DELETE FROM EMP01 
WHERE
    P01F01 = 4;


-- DESC: Sort the employees by their salary in descending order
SELECT 
    *
FROM
    EMP01
ORDER BY P01F06 DESC;

-- DISTINCT: Select distinct department names
SELECT DISTINCT
    P01F02
FROM
    DEP01;

-- DROP COLUMN: Drop the Position column from the Employee table
ALTER TABLE EMP01 DROP COLUMN P01F05;

-- DROP CONSTRAINT: Drop the foreign key constraint
ALTER TABLE EMP01 DROP FOREIGN KEY FK_DEP_EMP;


-- DROP INDEX: Drop the index on the Position column
DROP INDEX IDX_POSF01 ON EMP01;

-- DROP TABLE: Drop the SalaryHistory table
DROP TABLE IF EXISTS SLH01;

-- EXISTS: Check if any employee records exist
SELECT 
    CASE
        WHEN
            EXISTS( SELECT 
                    *
                FROM
                    EMP01)
        THEN
            'Records exist'
        ELSE 'No records'
    END;

-- FOREIGN KEY: Create a foreign key constraint on the SalaryHistory table
ALTER TABLE SLH01 ADD CONSTRAINT FK_EMP_SLH FOREIGN KEY (H01F02) REFERENCES EMP01(P01F01);

-- FROM: Select all employees from the Human Resources department
SELECT 
    *
FROM
    EMP01
WHERE
    P01F04 IN (SELECT 
            P01F01
        FROM
            DEP01
        WHERE
            P01F02 = 'Human Resources');

-- GROUP BY: Calculate the total salary for each department
SELECT 
    P01F04, SUM(P01F06) AS TOTAL_SALARY
FROM
    EMP01
GROUP BY P01F04;

-- HAVING: Select departments with a total salary greater than 5000
SELECT 
    P01F04, SUM(P01F06) AS TOTAL_SALARY
FROM
    EMP01
GROUP BY P01F04
HAVING SUM(P01F06) > 5000;

-- IN: Select employees from the Finance and IT departments
SELECT 
    *
FROM
    EMP01
WHERE
    P01F04 IN (2 , 3);

-- INDEX: Display the indexes on the Employee table
SHOW INDEX FROM EMP01;

-- INNER JOIN: Join the Employee and Department tables
SELECT 
    E.*, D.P01F02
FROM
    EMP01 E
        INNER JOIN
    DEP01 D ON E.P01F04 = D.P01F01;

-- INSERT INTO: Add a new employee record
INSERT INTO EMP01 (P01F02, P01F03, P01F04, P01F06, P01F07) 
VALUES ('MNO', 'mno', 1, 4800.00, '2023-06-15');

-- INSERT INTO SELECT: Copy department data into a new table
CREATE TABLE DEP_COPY AS SELECT * FROM
    DEP01;

SELECT 
    *
FROM
    DEP_COPY;


-- IS NULL: Select employees with no position alloted
SELECT 
    *
FROM
    EMP01
WHERE
    P01F05 IS NULL;

-- IS NOT NULL: Select employees with a salary
SELECT 
    *
FROM
    EMP01
WHERE
    P01F06 IS NOT NULL;

-- JOIN: Join the Employee and Department tables
SELECT 
    E.*, D.P01F02
FROM
    EMP01 E
        JOIN
    DEP01 D ON E.P01F04 = D.P01F01;

-- LEFT JOIN: Select all employees and their corresponding department names
SELECT 
    E.*, D.P01F02
FROM
    EMP01 E
        LEFT JOIN
    DEP01 D ON E.P01F04 = D.P01F01;

-- LIKE: Select employees with a last name starting with 'S'
SELECT 
    *
FROM
    EMP01
WHERE
    P01F03 LIKE 'P%';

-- LIMIT: Select the first 10 employees
SELECT 
    *
FROM
    EMP01
LIMIT 10;

-- NOT: Select employees not in the Finance department
SELECT 
    *
FROM
    EMP01
WHERE
    P01F04 != 2;

-- NOT NULL: Select employees with a non-null department ID
SELECT 
    *
FROM
    EMP01
WHERE
    P01F04 IS NOT NULL;

-- OR: Select employees in the Finance or IT departments
SELECT 
    *
FROM
    EMP01
WHERE
    P01F04 = 2 OR P01F04 = 3;


-- OUTER JOIN: Join all employees with their corresponding department names
SELECT 
    E.*, D.P01F02
FROM
    EMP01 E
        LEFT JOIN
    DEP01 D ON E.P01F04 = D.P01F01 
UNION SELECT 
    E.*, D.P01F02
FROM
    EMP01 E
        RIGHT JOIN
    DEP01 D ON E.P01F04 = D.P01F01;


-- PROCEDURE: Call the CalculateAverageSalary stored procedure
CALL CALC_AVG_SAL();

-- RIGHT JOIN: Select all departments and their corresponding employees
SELECT 
    D.*, E.P01F02, E.P01F02
FROM
    DEP01 D
        RIGHT JOIN
    EMP01 E ON D.P01F01 = E.P01F04;

-- SELECT DISTINCT: Select distinct department names
SELECT DISTINCT
    P01F02
FROM
    DEP01;

-- SELECT INTO: Copy department data into a new table
SELECT 
    *
INTO DEP_COPY FROM
    DEP01;

-- SET: Update the salary of all employees in the Human Resources department
UPDATE EMP01 
SET 
    P01F06 = P01F06 * 1.1
WHERE
    P01F04 = 1;

-- TABLE: Display the tables in the schoolmanagement database
SHOW TABLES;

-- TRUNCATE TABLE: Delete all records from the Employee table
TRUNCATE TABLE EMP01;


-- UNION ALL: Combine the results of two SELECT statements, including duplicates
SELECT 
    P01F02, P01F03
FROM
    EMP01 
UNION ALL SELECT 
    P01F02 AS FNAF01, '' AS LANF01
FROM
    DEP01;


-- UPDATE: Update the salary of an employee
UPDATE EMP01 
SET 
    P01F06 = 5200.00
WHERE
    P01F01 = 1;

-- VALUES: Insert a new department record
INSERT INTO DEP01 (P01F02) VALUES ('Marketing');

-- VIEW: Create a view to display employee details
CREATE VIEW EMP_VIEW AS
    SELECT 
        *
    FROM
        EMP01;

-- WHERE: Select employees with a salary greater than 5000
SELECT 
    *
FROM
    EMP01
WHERE
    P01F06 > 5000;

-- DROP DATABASE: Drop the schoolmanagement database
DROP DATABASE IF EXISTS schoolmanagement;

