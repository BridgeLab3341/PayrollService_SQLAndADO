--Section-1(MSSQL-DB)
--UC1
Create DataBase PayRollService

--UC2
Create Table Employee_PayRoll(Id Int Primary key identity(1,1),
Name varchar(20),Salary BigInt,StartDate Datetime)

--UC3
Insert Into Employee_PayRoll(Name,Salary,StartDate) values('Somu',120000,2023-08-28)
Insert Into Employee_PayRoll(Name,Salary,StartDate) values('Anil',140000,2022-08-22)
Insert Into Employee_PayRoll(Name,Salary,StartDate) values('Sandy',100000,2020-04-23)
Insert Into Employee_PayRoll(Name,Salary,StartDate) values('Ganesh',150000,2021-02-14)
Insert Into Employee_PayRoll(Name,Salary,StartDate) values('Mani',160000,2023-04-03)
Insert Into Employee_PayRoll(Name,Salary,StartDate) values('Rani',110000,2019-03-03)
Insert Into Employee_PayRoll(Name,Salary,StartDate) values('Shekar',100000,2021-08-19)
Insert Into Employee_PayRoll(Name,Salary,StartDate) values('Kumar',150000,2020-06-08)

--UC4
Select * from Employee_PayRoll

--UC5
Select Salary from Employee_PayRoll Where Name='Rani'
Select * from Employee_PayRoll where StartDate Between cast('2021-01-01' as Date) and CURRENT_TIMESTAMP;