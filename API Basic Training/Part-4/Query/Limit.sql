-- Database name
use schoolmanagement ;


-- limit clause
-- Retrieve the first 3 rows from the Bnk01 table
SELECT * FROM Bnk01
LIMIT 3;


-- Retrieve the first 3 rows order by bank name in descending order 
SELECT * FROM Bnk01
order by Bnk01.k01f02 desc
LIMIT 3;

