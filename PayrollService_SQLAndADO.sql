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

--UC6
Alter Table Employee_PayRoll Add Gender char;
Update Employee_PayRoll Set Gender='M' where Name='Somu'
Update Employee_PayRoll Set Gender='M' where Name='Anil'
Update Employee_PayRoll Set Gender='M' where Name='Sandy'
Update Employee_PayRoll Set Gender='M' where Name='Ganesh'
Update Employee_PayRoll Set Gender='M' where Name='Mani'
Update Employee_PayRoll Set Gender='F' where Name='Rani'
Update Employee_PayRoll Set Gender='M' where Name='Shekar'
Update Employee_PayRoll Set Gender='M' where Name='Kumar'

--UC7
Insert into Employee_PayRoll values('Moni',130000,2020-09-23,'F')
Insert into Employee_PayRoll values('Radha',140000,2019-04-13,'F')
Insert into Employee_PayRoll values('Sandhya',110000,2021-07-03,'F')
Insert into Employee_PayRoll values('Sahana',150000,2022-06-23,'F')

Select Sum(Salary) as TotalSalary_Male from Employee_PayRoll where Gender='M' group by Gender;
Select Sum(Salary) as TotalSalary_Female from Employee_PayRoll where Gender='F' group by Gender;
Select AVG(Salary) as AverageSalary_Male from Employee_PayRoll Where Gender='M' group by Gender;
Select AVG(Salary) as AverageSalary_Female from Employee_PayRoll Where Gender='F' group by Gender;
Select Min(Salary) as MinimumSalary_Male from Employee_PayRoll Where Gender='M' group by Gender;
Select Min(Salary) as MinimumSalary_Female from Employee_PayRoll Where Gender='F' group by Gender;
Select Max(Salary) as MaximumSalary_Male from Employee_PayRoll Where Gender='M' group by Gender;
Select Max(Salary) as MaximumSalary_Female from Employee_PayRoll Where Gender='F' group by Gender;
Select Count(Salary) as Total_Males from Employee_PayRoll Where Gender='M' group by Gender;
Select Count(Salary) as Total_Females from Employee_PayRoll Where Gender='F' group by Gender;

--Section 2: ER Diagram
--UC8
Alter Table Employee_PayRoll Add Phone varchar(10),Address varchar(100) Not Null Default 'abc',
Department varchar(30) Not Null Default 'xyz'

--UC9
Alter Table Employee_PayRoll Add BasicPay Bigint, Deductions Bigint,TaxablePay Bigint,
IncomeTax Bigint,NetPay Bigint;
Update Employee_PayRoll set Phone='9856756755',Address='Banglore',Department='R & D',BasicPay=50000,Deductions=5000,TaxablePay=12000,IncomeTax=2500,NetPay=1400;
Update Employee_PayRoll set Phone='8766755645',Address='Chennai',Department='Production',BasicPay=55000,Deductions=5200,TaxablePay=12000,IncomeTax=2500,NetPay=1400;
Update Employee_PayRoll set Phone='9675767546',Address='Delhi',Department='Maintance',BasicPay=52000,Deductions=5400,TaxablePay=12000,IncomeTax=2500,NetPay=1400;
Update Employee_PayRoll set Phone='7856567567',Address='Banglore',Department='Testing',BasicPay=50000,Deductions=5900,TaxablePay=12000,IncomeTax=2500,NetPay=1400;
Update Employee_PayRoll set Phone='7756746778',Address='Hyderabad',Department='Design',BasicPay=53000,Deductions=5700,TaxablePay=12000,IncomeTax=2500,NetPay=1400;
Update Employee_PayRoll set Phone='7897678687',Address='Mumbai',Department='Production',BasicPay=54000,Deductions=5600,TaxablePay=12000,IncomeTax=2500,NetPay=1400;
Update Employee_PayRoll set Phone='8967867876',Address='Chennai',Department='R & D',BasicPay=51000,Deductions=5800,TaxablePay=12000,IncomeTax=2500,NetPay=1400;
Update Employee_PayRoll set Phone='8978878675',Address='Banglore',Department='Maintance',BasicPay=53000,Deductions=5700,TaxablePay=12000,IncomeTax=2500,NetPay=1400;
Update Employee_PayRoll set Phone='6875878678',Address='Hyderabad',Department='Production',BasicPay=52000,Deductions=5400,TaxablePay=12000,IncomeTax=2500,NetPay=1400;
Update Employee_PayRoll set Phone='9808767886',Address='Delhi',Department='Design',BasicPay=54000,Deductions=5600,TaxablePay=12000,IncomeTax=2500,NetPay=1400;
Update Employee_PayRoll set Phone='8977978989',Address='Banglore',Department='Production',BasicPay=55000,Deductions=5000,TaxablePay=12000,IncomeTax=2500,NetPay=1400;
Update Employee_PayRoll set Phone='8979676787',Address='Mumbai',Department='Testing',BasicPay=52000,Deductions=5500,TaxablePay=12000,IncomeTax=2500,NetPay=1400;

--UC10
Insert into Employee_PayRoll(Name,Salary,StartDate,Gender,Phone,Address,Department,BasicPay,Deductions,TaxablePay,IncomeTax,NetPay)
values('Terissa',150000,'2020-05-15','F','8767867887','Banglore','Sales',52000,5500,12000,2500,1400);
Insert into Employee_PayRoll(Name,Salary,StartDate,Gender,Phone,Address,Department,BasicPay,Deductions,TaxablePay,IncomeTax,NetPay)
values('Terissa',120000,'2021-07-25','F','9800988978','Banglore','Marketing',50000,5100,12000,2500,1400);

--UC11(Creating Table)
Create Table DEPARTMENT(DepartmentId Int Primary Key,
DeptName Varchar(30),CountryId Int Foreign Key	References dbo.Employee_PayRoll(Id));

--UC12
Select * from Employee_PayRoll
