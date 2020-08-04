using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDeductions.Models
{
   public interface IDatabaseTransaction
    {
        void Commit();

        void Rollback();
    }
}
