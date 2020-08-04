using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDeductions.Models
{
    public class TypeDiscountRulesRepository : Repository<TypeDiscountRules>, ITypeDiscountRulesRepository
    {
        public TypeDiscountRulesRepository(EmployeeDetailsContext context) : base(context)
        {
        }
    }
}
