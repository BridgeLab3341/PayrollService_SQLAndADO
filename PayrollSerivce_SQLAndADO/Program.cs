namespace PayrollSerivce_SQLAndADO
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Choose Option To Perform the Operation\n1.Create DataBase\n2.Retrieve All Records\n3.Exit");
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
                        flag = false;
                        break;
                }
            }
        }
    }
}
