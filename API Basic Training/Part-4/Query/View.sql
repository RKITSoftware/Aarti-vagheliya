-- VIEW FOR DISPLAY STUDENT'S FULL NAME AND EMAIL
CREATE VIEW VWS_StudentNamesAndEmails AS
SELECT CONCAT(d01f02, ' ', d01f03) AS FullName, d01f06
FROM Std01;



-- Select all data from the VWS_StudentNamesAndEmails view
SELECT * FROM VWS_StudentNamesAndEmails;


-- UPDATE EXISTING VIEW TO DISPLAY FIRSTNAME, LASTNAME AND EMAIL
CREATE OR REPLACE VIEW VWS_StudentNamesAndEmails AS
SELECT d01f02, d01f03, d01f06
FROM Std01;

-- Select all data from the VWS_StudentNamesAndEmails view
SELECT * FROM VWS_StudentNamesAndEmails;