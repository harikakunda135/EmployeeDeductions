using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDeductions.Models
{

    public class EmployeeRepository : Repository<EmployeeDetails>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDetailsContext context) : base(context)
        {
        }

        public IQueryable<EmployeeDetails> GetAllIncludingchild(params Expression<Func<EmployeeDetails, object>>[] includeProperties)
        {

            IQueryable<EmployeeDetails> queryable = GetAll();

            return queryable;
        }

    }
}
