-- BRANCH TABLE
CREATE TABLE Brn01 (
    n01f01 INT PRIMARY KEY COMMENT 'BranchID',
    n01f02 VARCHAR(50) COMMENT 'BranchName',
    n01f03 VARCHAR(30) COMMENT 'IFSCCode',
	n01f04 INT COMMENT 'BankID',
    CONSTRAINT FK_Branch_Bank
    FOREIGN KEY (n01f04)
    REFERENCES Bnk01 (k01f01)
) comment 'Branch table';

-- Insert data into Brn01 (Branch table)
INSERT INTO 
	Brn01 
    (n01f01, n01f02, n01f03, n01f04)
 VALUES	
	(101, 'Branch1', 'IFSC001', 1),  
	(102, 'Branch2', 'IFSC002', 2),  
	(103, 'Branch3', 'IFSC003', 3),
	(104, 'Branch4', 'IFSC004', 5);
        
select * from Brn01