namespace PayrollSerivce_SQLAndADO
{
    class Program
    {
        public static void Main(string[] args)
        {
            PayRollOperation pay = new PayRollOperation();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Choose Option To Perform the Operation\n1.Create DataBase\n2.Retrieve All Records\n3.Update Record(Salary)\n4.Update Record(Salary)\n5.Get Records In Particualr Range\n6.Find Operations\n7.Add New Employee\n8.Exit");
                int option=Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        PayRollOperation.CreateDatabase();
                        break;
                        case 2:
                        PayRollOperation.RetrieveAllEmployeePayRollRecords();
                        break;
                        case 3:
                        PayRollOperation.UpdateTheSalary();
                        break;
                        case 4:                        
                        pay.UpdateSalaryByConnectingString(15,3000000);
                        break;
                        case 5:
                        Console.WriteLine("Enter start date");
                        DateTime fromDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter End date");
                        DateTime ToDate = DateTime.Parse(Console.ReadLine());
                        pay.GetDataInParticularRange(fromDate, ToDate);
                        break;
                        case 6:
                        pay.AbilityToFindOperation();
                        break;
                        case 7:
                        EmployeeData employe1 = new EmployeeData()
                        {
                            Name = "Dhanu",
                            Salary = 122000,
                            StartDate = DateTime.Now,
                            Gender = 'M',
                            Phone = "9093938839",
                            Address = "Banglore",
                            Department = "Sales",
                            BasicPay = 95000,
                            Deductions = 20000,
                            TaxablePay = 10000,
                            IncomeTax = 18000,
                            NetPay = 100
                        };
                        pay.AddEmployee(employe1);
                        break;
                        case 8:
                        flag = false;
                        break;
                }
            }
        }
    }
}
