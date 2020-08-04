using System;
using System.Collections.Generic;

namespace EmployeeDeductions.Models
{
    public partial class TypeDiscountRules
    {
        public int discount_type_id { get; set; }
        public string discount_rule { get; set; }
        public string discount_description { get; set; }
        public decimal discount { get; set; }
    }
}
