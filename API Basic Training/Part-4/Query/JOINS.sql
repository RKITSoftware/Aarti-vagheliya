-- Database name
USE schoolmanagement ;

-- INNER JOIN
SELECT 
	n01f01,
    n01f02,
    n01f03,
    n01f04
FROM 
	Brn01
INNER JOIN 
	Bnk01 
ON 
	Brn01.n01f04 = Bnk01.k01f01;
    
    
-- LEFT JOIN OR LEFT OUTER JOIN
SELECT 
	n01f01,
    n01f02,
    n01f03,
    n01f04
FROM 
	Brn01
LEFT JOIN 
	Bnk01 
ON 
	Brn01.n01f04 = Bnk01.k01f01;    
    
    
-- RIGHT JOIN OR RIGHT OUTER JOIN
SELECT 
	n01f01,
    n01f02,
    n01f03,
    n01f04
FROM 
	Brn01
RIGHT JOIN 
	Bnk01 
ON 
	Brn01.n01f04 = Bnk01.k01f01;
    
    
-- FULL JOIN OR FULL OUTER JOIN not perform in mysql
SELECT 
	Brn01.n01f01,
	Brn01.n01f02,
	Brn01.n01f03,
	Brn01.n01f04
FROM 
	Brn01
FULL  JOIN 
	Bnk01 
ON 
	Brn01.n01f04 = Bnk01.k01f01;


-- CROSS JOIN 
SELECT 
	*
FROM 
	Brn01
CROSS JOIN 
	Bnk01;


-- SELF JOIN
SELECT 
	b1.*, b2.*
FROM 
	Brn01 b1
INNER JOIN 
	Brn01 b2 
ON 
	b1.n01f01 = b2.n01f01;

