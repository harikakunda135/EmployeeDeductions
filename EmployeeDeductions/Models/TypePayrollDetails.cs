using System;
using System.Collections.Generic;

namespace EmployeeDeductions.Models
{
    public partial class TypePayrollDetails
    {
        public int payroll_type_id { get; set; }
        public string employee_category { get; set; }
        public int yearly_paychecks { get; set; }
        public decimal salary_per_paycheck { get; set; }
        public decimal employee_yearly_deductions { get; set; }
        public decimal dependent_yearly_deductions { get; set; }
    }
}
