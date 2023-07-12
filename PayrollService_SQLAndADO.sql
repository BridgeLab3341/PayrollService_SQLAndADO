--Section-1(MSSQL-DB)
--UC1
Create DataBase PayRollService
--UC2
Create Table Employee_PayRoll(Id Int Primary key identity(1,1),
Name varchar(20),Salary BigInt,StartDate Datetime)

Select * from Employee_PayRoll
