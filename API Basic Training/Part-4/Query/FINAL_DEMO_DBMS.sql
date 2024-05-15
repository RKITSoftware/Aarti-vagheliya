-- CREATE DATABASE 
CREATE DATABASE inventory_management;

-- USE inventory_management DATABASE FOR OPERATION
USE inventory_management;



-- CREATE CAT01 (CATEGORY) TABLE
CREATE TABLE CAT01 (
    T01F01 INT PRIMARY KEY AUTO_INCREMENT ,
    T01F02 VARCHAR(255) NOT NULL
);



-- CREATE SUP01 (SUPPLIERS) TABLE
CREATE TABLE SUP01 (
    P01F01 INT PRIMARY KEY AUTO_INCREMENT,
    P01F02 VARCHAR(255) NOT NULL,
    P01F03 VARCHAR(30),
    P01F04 VARCHAR(50)
);



-- CREATE PRD01 (PRODUCT) TABLE
CREATE TABLE PRD01 (
    D01F01 INT PRIMARY KEY AUTO_INCREMENT,
    D01F02 VARCHAR(255) NOT NULL,
    D01F03 INT,
    D01F04 DECIMAL(10 , 2 ),
    D01F05 INT,
    D01F06 VARCHAR(100),
    D01F07 DATE,
    D01F08 VARCHAR(50)
);



-- CREATE TRA01 (TRANSACTION) TABLE
CREATE TABLE TRA01 (
    A01F01 INT PRIMARY KEY AUTO_INCREMENT ,
    A01F02 INT ,
    A01F03 VARCHAR(20) , 
    A01F04 DATE ,
    A01F05 INT ,
    A01F06 DECIMAL(10, 2) ,
    CONSTRAINT FK_Product
    FOREIGN KEY (A01F02) 
    REFERENCES PRD01(D01F01)
) ;




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
    A01F05 AS TransactionType, 
    A01F04 AS TransactionDate, 
    A01F07 AS Quantity, 
    A01F08 AS TotalAmount
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
	A01F05 = 'P'
GROUP BY 
	A01F02;
    
    
-- Find the product with the highest unit price
SELECT 
	MAX(D01F06) AS HighestUnitPriceProduct
FROM 
	PRD01;


-- Identify the lowest total amount in a single transaction
SELECT 
	MIN(A01F08) AS LowestTotalAmount
FROM 
	TRA01;


-- Find the average total amount of transactions
SELECT 
	AVG(A01F08) AS AverageTotalAmount
FROM 
	TRA01;



-- Calculate the total amount of transactions per transaction type
SELECT 
	A01F05 AS TransactionType, 
	COUNT(*) AS TotalTransactions
FROM 
	TRA01
GROUP BY 
	A01F05;
    
    


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
	A01F08 = (SELECT MAX(A01F08) FROM TRA01);



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
    A.A01F05 AS TransactionTypeA, 
    B.A01F05 AS TransactionTypeB
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
    A01F05 AS Type
FROM 
	TRA01;




-- Create a unique index on ProductID (D01F01) in the PRD01 table
CREATE UNIQUE INDEX idx_D01F01 ON PRD01(D01F01);

-- Create a composite index on CategoryID (D01F03) and UnitPrice (D01F04) in the PRD01 table
CREATE INDEX idx_D01F03_D01F04 ON PRD01(D01F03, D01F04);


-- Create a unique index on StockId (K01F01) in the STK01 table
CREATE UNIQUE INDEX idx_K01F01 ON STK01(K01F01);




CREATE OR REPLACE VIEW vws_d01n01a01 AS
SELECT Distinct
	n01.N01F02 AS SupplierName,
	d01.D01F02 As Product_name
FROM
    tra01 a01
JOIN
    con01 AS n01 ON a01.A01F06 = n01.N01F01
JOIN
    prd01 AS d01 ON a01.A01F02 = d01.D01F01
WHERE
    n01.N01F06 = 'Sp';





SELECT 
	* 
FROM 
	vws_d01n01a01 ;
    
    
    
CREATE OR REPLACE VIEW vws_d01k01 AS
    SELECT 
        d01.D01F01 AS Product_Id,
        d01.D01F02 AS Product_Name,
        k01.K01F03 AS Stock
    FROM
        prd01 d01
            JOIN
        stk01 k01 ON d01.D01F01 = k01.K01F02;
      
      
      -- Custom order by 
SELECT 
    *
FROM
    vws_d01k01
 ORDER BY field(Product_Id, 2,3,5,4,1)   
 
# ORDER BY 
	# Stock DESC;
    
    
    
    
    
    
-- Complex SELECT query involving sorting, limiting, using indexes, and WHERE clause
-- tables  & View => tra01, cat01, prd01, con01, vws_d01k01
 SELECT 
	a01.A01F01 AS SRNo,
    vw.Product_Name AS ProductName,
    vw.Stock AS Stock,
    t01.T01F02 AS CategoryName,
    a01.A01F04 AS TransactionDate,
    a01.A01F05 AS TransactionType,
    a01.A01F07 AS Quantity,
    d01.D01F06 AS Unit_Price,
    a01.A01F08 AS Net_Price,
    n01.N01F02 AS SupplierName
FROM
    vws_d01k01 vw
JOIN
    tra01 a01 ON vw.Product_Id = a01.A01F02
JOIN
	prd01 d01 ON d01.D01F01 = vw.Product_Id
JOIN
    CAT01 t01 ON t01.T01F01 = d01.D01F03
JOIN
	con01 n01 ON n01.N01F01 = a01.A01F06
-- WHERE
--     t01.T01F02 IN ('Electronics' , 'Clothing', 'Food')
--         AND a01.A01F04 >= '2022-01-01'
ORDER BY a01.A01F04 DESC , vw.Product_Name ASC
LIMIT 10;