using NUnit.Framework;
using EmployeeDeductions;
using EmployeeDeductions.Models;
using Microsoft.Extensions.Logging;
using Moq;
using Microsoft.EntityFrameworkCore;
using System;
using EmployeeDeductions.Controllers;
using Microsoft.AspNetCore.Mvc;



namespace EmployeeDeductions.Tests
{
    [TestFixture]
    public  class TheEmployeeController
    {
        EmployeeController sut;
        EmployeeDetailsContext context;
        EmployeeUnitOfWork uow;
        Mock<ILogger<EmployeeController>> logger;
        Mock<IEmployeeUnitOfWork> mockUow;


        [SetUp]
        public virtual void SetUp()
        {
            var options = new DbContextOptionsBuilder<EmployeeDetailsContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            context = new EmployeeDetailsContext(options);
            uow = new EmployeeUnitOfWork(context);
            logger = new Mock<ILogger<EmployeeController>>();
            mockUow = new Mock<IEmployeeUnitOfWork>();
            mockUow.Setup(m => m.EmployeeRepository).Returns(uow.EmployeeRepository);
            mockUow.Setup(m => m.TypeDiscountRulesRepository).Returns(uow.TypeDiscountRulesRepository);
            mockUow.Setup(m => m.TypePayrollDetailsRepository).Returns(uow.TypePayrollDetailsRepository);
            sut = new EmployeeController(logger.Object,mockUow.Object);

            uow.TypeDiscountRulesRepository.Add(new TypeDiscountRules()
            {
                discount_type_id = 1,
                discount_rule = "A",
                discount=0.1M
            });
            uow.TypePayrollDetailsRepository.Add(new TypePayrollDetails()
            {
                payroll_type_id = 1,
                yearly_paychecks = 20,
                salary_per_paycheck = 1000,
                employee_yearly_deductions=500,
                dependent_yearly_deductions=200
            });
            uow.Save();
        }

        [TearDown]
        public void TearDown()
        {
            ((IDisposable)context).Dispose();
        }

        [TestFixture]
        public  class WhenSearchingForOrders : TheEmployeeController
        {
            [TestFixture]
            public class WhenOrderSearchiscalled : WhenSearchingForOrders
            {
                private EmployeeDetails employee;
                [SetUp]
                public override void SetUp()
                {
                    base.SetUp();
                    employee = new EmployeeDetails();
                }

                [Test]
                public void setupemployeesalary()
                {
                    employee.employee_name = "test";
                    var test = Create(employee);
                    var expectedSalary = 1000M;
                    Assert.AreEqual(test.paycheck_salary, expectedSalary);
                }

                [Test]
                public void checkDependentDeuctionwithoutNameStartingwithoutA()
                {
                    employee.employee_name = "test";
                    employee.dependent1_name = "BCD";
                    var test = Create(employee);
                    var expectedDeduction = 35M;
                    Assert.AreEqual(test.paycheck_deductions, expectedDeduction);
                }
                [Test]
                public void checkDependentDeductionwithoutNameStartingwithA()
                {
                    employee.employee_name = "test";
                    employee.dependent1_name = "ABC";
                    var test = Create(employee);
                    var expectedDeduction = 32.5M;
                    Assert.AreEqual(test.paycheck_deductions, expectedDeduction);
                }
            }
            private EmployeeDetails Create(EmployeeDetails employee)
            {
                var result = sut.Create(employee) as ViewResult;
                return (EmployeeDetails)result.Model;
            }

        }
    }
}
