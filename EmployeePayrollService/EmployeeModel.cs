using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollService
{
    class EmployeeModel
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public Decimal BasicPay {get; set; }
        public DateTime StartDate { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        public string Address { get; set; }
        public float Deduction { get; set; }
        public Decimal TaxablePay { get; set; }
        public Decimal IncomeTax { get; set; }
        public double NetPay { get; set; }


    }
}
