using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDeductions.Models
{
    public class TypePayrollDetailsRepository : Repository<TypePayrollDetails>, ITypePayrollDetailsRepository
    {
        public TypePayrollDetailsRepository(EmployeeDetailsContext context) : base(context)
        {
        }
    }
}
