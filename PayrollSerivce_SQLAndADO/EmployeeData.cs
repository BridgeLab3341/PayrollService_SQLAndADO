using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSerivce_SQLAndADO
{
    public class EmployeeData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public char Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public double BasicPay { get; set; }
        public double Deductions { get; set; }
        public double TaxablePay { get; set; }
        public double IncomeTax { get; set; }
        public double NetPay { get; set; }
    }
}
