using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDeductions.Models
{
    public partial class EmployeeDetails
    { 
        public int employee_number { get; set; }
        [Required(ErrorMessage = "Please give a valid employee Name.")]
        public string employee_name { get; set; }
        public int? department_id { get; set; }
        public string dependent1_name { get; set; }
        public string dependent2_name { get; set; }
        public string dependent3_name { get; set; }
        public string dependent4_name { get; set; }
        public string dependent5_name { get; set; }
        public decimal paycheck_salary { get; set; }
        public decimal paycheck_deductions { get; set; }
        public string Comments { get; set; }
    }
}
