-- CREATE DATABASE 
CREATE DATABASE inventory_management;

-- USE inventory_management DATABASE FOR OPERATION
USE inventory_management;



-- CREATE CAT01 (CATEGORY) TABLE
CREATE TABLE CAT01 (
    T01F01 INT PRIMARY KEY AUTO_INCREMENT COMMENT 'CategoryID',
    T01F02 VARCHAR(255) NOT NULL COMMENT 'CategoryName'
) COMMENT 'CAT_CATEGORY';



-- CREATE SUP01 (SUPPLIERS) TABLE
CREATE TABLE SUP01 (
    P01F01 INT PRIMARY KEY AUTO_INCREMENT COMMENT 'SupplierID',
    P01F02 VARCHAR(255) NOT NULL COMMENT 'SupplierName',
    P01F03 VARCHAR(30) COMMENT 'ContactNumber',
    P01F04 VARCHAR(50) COMMENT 'Email'
) COMMENT 'SUP_SUPPLIER';



-- CREATE PRD01 (PRODUCT) TABLE
CREATE TABLE PRD01 (
    D01F01 INT PRIMARY KEY AUTO_INCREMENT COMMENT 'ProductID',
    D01F02 VARCHAR(255) NOT NULL COMMENT 'ProductName',
    D01F03 INT COMMENT 'CategoryID',
    D01F04 DECIMAL(10, 2) COMMENT 'UnitPrice',
    D01F05 INT COMMENT 'SupplierID',
    D01F06 VARCHAR(100) COMMENT 'Description',
    D01F07 DATE COMMENT 'DateAdded',
    D01F08 VARCHAR(50) COMMENT 'Brand'
) COMMENT 'PRD_PRODUCTS' ;



-- CREATE TRA01 (TRANSACTION) TABLE
CREATE TABLE TRA01 (
    A01F01 INT PRIMARY KEY AUTO_INCREMENT COMMENT 'TransactionID',
    A01F02 INT COMMENT 'ProductID',
    A01F03 VARCHAR(20) COMMENT 'TransactionType', -- Assuming transaction type is a string (e.g., Purchase, Sale)
    A01F04 DATE COMMENT 'TransactionDate',
    A01F05 INT COMMENT 'Quantity',
    A01F06 DECIMAL(10, 2) COMMENT 'TotalAmount',
    CONSTRAINT FK_Product
    FOREIGN KEY (A01F02) 
    REFERENCES PRD01(D01F01)
) COMMENT 'TRA_TRANSACTION';




-- Add foreign key for CategoryID IN PRODUCT TABLE
ALTER TABLE PRD01
ADD CONSTRAINT FK_Category
FOREIGN KEY (D01F03) 
REFERENCES CAT01(T01F01);


-- Add foreign key for SupplierID IN PRODUCT TABLE
ALTER TABLE PRD01
ADD CONSTRAINT FK_Supplier
FOREIGN KEY (D01F05) 
REFERENCES SUP01(P01F01);



-- Insert data into CAT01 (Categories) table
INSERT INTO CAT01 (T01F01, T01F02)
VALUES
    (1, 'Electronics'),
    (2, 'Clothing'),
    (3, 'Home Appliances'),
    (4, 'Stationary' );
    
        
-- Select data from CAT01 (Categories) table
SELECT 
	T01F01 AS CategoryID, 
    T01F02 AS CategoryName
FROM 
	CAT01
  ORDER BY T01F02;  
    
    
    
    
-- Insert data into SUP01 (Suppliers) table
INSERT INTO SUP01 (P01F01, P01F02, P01F03, P01F04)
VALUES
    (1, 'ABC Electronics', '1234567890', 'john.doe@example.com'),
    (2, 'Fashion Emporium', '9876543210', 'alice.smith@example.com'),
    (3, 'Shree stationrs', '9876785210', 'alice.smith@gmail.com');
    
    
    
-- Select data from SUP01 (Suppliers) table
SELECT 
	P01F01 AS SupplierID, 
    P01F02 AS SupplierName, 
    P01F03 AS ContactNumber, 
    P01F04 AS Email
FROM 
	SUP01;
    
    
    
-- Insert data into PRD01 (Products) table
INSERT INTO PRD01 (D01F02, D01F03, D01F04, D01F05, D01F06, D01F07, D01F08)
VALUES
    ('Smartphone', 1, 499.99, 1, 'Latest model with advanced features', '2022-01-10', 'BrandX'),
    ('LED TV', 1, 799.99, 1, 'High-definition smart TV', '2022-01-11', 'BrandY'),
    ('files', 4, 799.99, 3, 'SpiraL Files', '2022-05-21', 'BrandZ');



-- Select data from PRD01 (Products) table
SELECT 
	PRD01.D01F01 AS ProductID, 
	PRD01.D01F02 AS ProductName, 
    PRD01.D01F03 AS CategoryID, 
    PRD01.D01F04 AS UnitPrice, 
    PRD01.D01F05 AS SupplierID, 
    PRD01.D01F06 AS Description, 
    PRD01.D01F07 AS DateAdded, 
    PRD01.D01F08 AS Brand
FROM 
	PRD01;
    
    
    
-- Insert data into TRA01 (Transactions) table
INSERT INTO TRA01 (A01F02, A01F03, A01F04, A01F05, A01F06)
VALUES
    (1, 'Purchase', '2022-01-15', 5, 2499.95),
    (2, 'Sale', '2022-01-16', 2, 1599.98);

    
    
-- Alter the TRA01 (Transactions) table to modify AUTO_INCREMENT starting value
ALTER TABLE TRA01 AUTO_INCREMENT = 1001;



-- Insert data into TRA01 (Transactions) table AFTER ALTER
INSERT INTO 
	TRA01 (A01F02, A01F03, A01F04, A01F05, A01F06)
VALUES    
	(3, 'Purchase', '2022-01-17', 50, 1245.95);
    
    
    
-- Select data from TRA01 (Transactions) table
SELECT 
	A01F01 AS TransactionID, 
    A01F02 AS ProductID, 
    A01F03 AS TransactionType, 
    A01F04 AS TransactionDate, 
    A01F05 AS Quantity, 
    A01F06 AS TotalAmount
FROM 
	TRA01;


-- START A NEW TRANSACTION
START TRANSACTION ;

-- UPADTE unitprice in product table
UPDATE PRD01
SET D01F04 = '50'
WHERE D01F01 = 3;

 -- commit this transaction
COMMIT;

-- start new transaction
START TRANSACTION;

-- delete one record from supplier
DELETE 
FROM
	SUP01
WHERE
	P01F01 = 2;
    
  -- rollback this transaction  so delete not perform on db permanentaly  
ROLLBACK;
	
    
 -- Agrregate functions    
-- Count the total number of transactions
SELECT 
	COUNT(*) AS TotalTransactions
FROM 
	TRA01;
    
    
-- Find the total amount of products PUECHASE per product
SELECT 
	A01F02 AS ProductID, 
	SUM(A01F05) AS TotalQuantityPurchase
FROM 
	TRA01
WHERE 
	A01F03 = 'Purchase'
GROUP BY 
	A01F02;
    
    
-- Find the product with the highest unit price
SELECT 
	MAX(D01F04) AS HighestUnitPriceProduct
FROM 
	PRD01;


-- Identify the lowest total amount in a single transaction
SELECT 
	MIN(A01F06) AS LowestTotalAmount
FROM 
	TRA01;


-- Find the average total amount of transactions
SELECT 
	AVG(A01F06) AS AverageTotalAmount
FROM 
	TRA01;



-- Calculate the total amount of transactions per transaction type
SELECT 
	A01F03 AS TransactionType, 
	COUNT(*) AS TotalTransactions
FROM 
	TRA01
GROUP BY 
	A01F03;
    
    


-- SUB QUERIES
-- Subquery on PRD01 to find products with stock quantity greater than the average:
SELECT 
	*
FROM 
	PRD01
WHERE 
	D01F05 > (SELECT AVG(D01F05) FROM PRD01);



-- Subquery on TRA01 to Find transactions with the highest total amount
SELECT
	*
FROM 
	TRA01
WHERE 
	A01F06 = (SELECT MAX(A01F06) FROM TRA01);



-- Subquery on PRD01 Find products in a specific category
SELECT 
	*
FROM 
	PRD01
WHERE 
	D01F03 IN (SELECT 
					T01F01 
				FROM 
					CAT01 
				WHERE 
					T01F02 = 'Electronics'
				);



-- JOINS 
-- Inner join to retrieve products with category information
SELECT 
	PRD01.*, 
    CAT01.T01F02 AS CategoryName
FROM 
	PRD01
INNER JOIN 
	CAT01 
ON 
	PRD01.D01F03 = CAT01.T01F01;


-- Left join to retrieve products with supplier information
SELECT 
	PRD01.*, 
	SUP01.P01F02 AS SupplierName
FROM 
	PRD01
LEFT JOIN 
	SUP01 
ON 
	PRD01.D01F05 = SUP01.P01F01;



-- Self join to find transactions with the same product but different transaction types
SELECT 
	A.A01F01 AS TransactionID, 
	A.A01F02 AS ProductID, 
    A.A01F03 AS TransactionTypeA, 
    B.A01F03 AS TransactionTypeB
FROM 
	TRA01 A
JOIN 
	TRA01 B 
ON 
	A.A01F02 = B.A01F02 
AND 
	A.A01F01 <> B.A01F01;





-- UNION
-- UNION to combine results from PRD01 and TRA01
SELECT 
	D01F01 AS ID, 
	D01F02 AS Name, 
    D01F03 AS Type
FROM 
	PRD01
UNION 
SELECT 
	A01F01 AS ID, 
    A01F02 AS Name, 
    A01F03 AS Type
FROM 
	TRA01;




-- Create a unique index on ProductID (D01F01) in the PRD01 table
CREATE UNIQUE INDEX idx_ProductID ON PRD01(D01F01);

-- Create a composite index on CategoryID (D01F03) and UnitPrice (D01F04) in the PRD01 table
CREATE INDEX idx_Category_UnitPrice ON PRD01(D01F03, D01F04);




-- Create a view that combines information from PRD01, CAT01, SUP01, and TRA01
CREATE OR REPLACE VIEW VWS_ProductTransactionView AS
SELECT
    P.D01F01 AS ProductID,
    P.D01F02 AS ProductName,
    C.T01F01 AS CategoryID,
    C.T01F02 AS CategoryName,
    S.P01F01 AS SupplierID,
    S.P01F02 AS SupplierName,
    T.A01F01 AS TransactionID,
    T.A01F02 AS TransactionProductID,
    T.A01F03 AS TransactionType,
    T.A01F04 AS TransactionDate,
    T.A01F05 AS TransactionQuantity,
    T.A01F06 AS TransactionAmount
FROM PRD01 P
JOIN CAT01 C ON P.D01F03 = C.T01F01
LEFT JOIN SUP01 S ON P.D01F05 = S.P01F01
LEFT JOIN TRA01 T ON P.D01F01 = T.A01F02;



-- Example query on the created view
SELECT 
	* 
FROM 
	VWS_ProductTransactionView 
WHERE 
	CategoryName = 'Electronics' 
LIMIT 2;



SELECT 
	* 
FROM 
	VWS_ProductTransactionView 
WHERE 
	CategoryName = 'Stationary';




-- Complex SELECT query involving sorting, limiting, using indexes, and WHERE clause
SELECT
    P.D01F01 AS ProductID,
    P.D01F02 AS ProductName,
    C.T01F02 AS CategoryName,
    S.P01F01 AS SupplierName,
    T.A01F01 AS TransactionID,
    T.A01F03 AS TransactionType,
    T.A01F04 AS TransactionDate,
    T.A01F05 AS TransactionQuantity,
    T.A01F06 AS TransactionAmount
FROM
    PRD01 P
JOIN CAT01 C ON P.D01F03 = C.T01F01
LEFT JOIN SUP01 S ON P.D01F05 = S.P01F01
LEFT JOIN TRA01 T ON P.D01F01 = T.A01F02
WHERE
    C.T01F02 IN ('Electronics', 'Clothing')
    AND S.P01F01 IS NOT NULL
    AND T.A01F04 >= '2022-01-01'
ORDER BY
    T.A01F04 DESC, P.D01F02 ASC
LIMIT 5;

