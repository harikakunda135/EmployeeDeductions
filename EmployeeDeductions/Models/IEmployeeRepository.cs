using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EmployeeDeductions.Models
{
    public interface IEmployeeRepository : IRepository<EmployeeDetails>
    {
        IQueryable<EmployeeDetails> GetAllIncludingchild(params Expression<Func<EmployeeDetails, object>>[] includeProperties);
    }
}
