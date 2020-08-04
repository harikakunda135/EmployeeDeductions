using System;
using System.Linq;
using EmployeeDeductions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeDeductions.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private IEmployeeUnitOfWork UnitOfWork;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeUnitOfWork uow)
        {
            _logger = logger;
            UnitOfWork = uow;
        }
        public IActionResult Index()
        {
            var employees = UnitOfWork.EmployeeRepository.GetAllIncludingchild().ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDetails employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CalculateDeductions(employee);
                    UnitOfWork.EmployeeRepository.Add(employee);
                    UnitOfWork.Save();
                    this.TempData["Result"] = "Success";
                    ModelState.Clear();
                }
                catch
                {
                    ModelState.AddModelError("", "Error in inserting data");
                }
            }
            return View(employee);
        }

        private void CalculateDeductions(EmployeeDetails employee)
        {
            var discounts = UnitOfWork.TypeDiscountRulesRepository.Find(x => x.discount_type_id == 1);
            var payroll = UnitOfWork.TypePayrollDetailsRepository.Find(x => x.payroll_type_id == 1);
            var employeededuction = payroll.employee_yearly_deductions;
            var dependentdeduction = payroll.dependent_yearly_deductions;
            decimal total = 0;
            if (!string.IsNullOrWhiteSpace(employee.employee_name))
            {
                if (employee.employee_name.StartsWith(discounts.discount_rule, StringComparison.OrdinalIgnoreCase))
                {
                    var discountAmount = employeededuction * discounts.discount;
                    total = employeededuction - discountAmount;
                }
                else
                {
                    total = employeededuction;
                }
            }
            if (!string.IsNullOrWhiteSpace(employee.dependent1_name))
            {
                if (employee.dependent1_name.StartsWith(discounts.discount_rule, StringComparison.OrdinalIgnoreCase))
                {
                    var discountAmount = employeededuction * discounts.discount;
                    total += (dependentdeduction - Convert.ToInt32(discountAmount));
                }
                else
                {
                    total += (dependentdeduction);
                }
            }
            if (!string.IsNullOrWhiteSpace(employee.dependent2_name))
            {
                if (employee.dependent2_name.StartsWith(discounts.discount_rule, StringComparison.OrdinalIgnoreCase))
                {
                    var discountAmount = employeededuction * discounts.discount;
                    total += (dependentdeduction - Convert.ToInt32(discountAmount));
                }
                else
                {
                    total += (dependentdeduction);
                }
            }
            if (!string.IsNullOrWhiteSpace(employee.dependent3_name))
            {
                if (employee.dependent3_name.StartsWith(discounts.discount_rule, StringComparison.OrdinalIgnoreCase))
                {
                    var discountAmount = employeededuction * discounts.discount;
                    total += (dependentdeduction - Convert.ToInt32(discountAmount));
                }
                else
                {
                    total += (dependentdeduction);
                }
            }
            if (!string.IsNullOrWhiteSpace(employee.dependent4_name))
            {
                if (employee.dependent4_name.StartsWith(discounts.discount_rule, StringComparison.OrdinalIgnoreCase))
                {
                    var discountAmount = employeededuction * discounts.discount;
                    total += (dependentdeduction - Convert.ToInt32(discountAmount));
                }
                else
                {
                    total += (dependentdeduction);
                }
            }
            if (!string.IsNullOrWhiteSpace(employee.dependent5_name))
            {
                if (employee.dependent5_name.StartsWith(discounts.discount_rule, StringComparison.OrdinalIgnoreCase))
                {
                    var discountAmount = employeededuction * discounts.discount;
                    total += (dependentdeduction - Convert.ToInt32(discountAmount));
                }
                else
                {
                    total += (dependentdeduction);
                }
            }
            employee.paycheck_salary = payroll.salary_per_paycheck;
            employee.paycheck_deductions = (total / payroll.yearly_paychecks);
        }

        public IActionResult Detail(int? id)
        {
            var employee = UnitOfWork.EmployeeRepository.Find(e => e.employee_number == id);
            return View(employee);
        }

        public ActionResult Delete(int id)
        {
            EmployeeDetails Details = new EmployeeDetails { employee_number=id };

            UnitOfWork.EmployeeRepository.Delete(Details);
            UnitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}