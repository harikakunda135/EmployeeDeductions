using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDeductions.Models
{
    public interface IEmployeeUnitOfWork : IDisposable
    {
        IDatabaseTransaction BeginTransaction();

        IEmployeeRepository EmployeeRepository { get; }

        ITypeDiscountRulesRepository TypeDiscountRulesRepository { get; }

        ITypePayrollDetailsRepository TypePayrollDetailsRepository { get; }

        void Save();

    }

    public class EmployeeUnitOfWork : IEmployeeUnitOfWork
    {
        private readonly EmployeeDetailsContext _context;
        private IEmployeeRepository _employeeRepository;
        private ITypeDiscountRulesRepository _typeDiscountRulesRepository;
        private ITypePayrollDetailsRepository _typePayrollDetailsRepository;
        public EmployeeUnitOfWork(EmployeeDetailsContext context)
        {
            _context = context;
        }
        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                return _employeeRepository = _employeeRepository ?? new EmployeeRepository(_context);
            }
        }
        public ITypeDiscountRulesRepository TypeDiscountRulesRepository
        {
            get
            {
                return _typeDiscountRulesRepository = _typeDiscountRulesRepository ?? new TypeDiscountRulesRepository(_context);
            }
        }
        public ITypePayrollDetailsRepository TypePayrollDetailsRepository
        {
            get
            {
                return _typePayrollDetailsRepository = _typePayrollDetailsRepository ?? new TypePayrollDetailsRepository(_context);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IDatabaseTransaction BeginTransaction()
        {
            return new EntityDatabaseTransaction(_context);
        }
    }
}
