using Learn.Models;
using Learn.Services;
using Microsoft.AspNetCore.Mvc;

namespace Learn.Controllers;

public class EmployeeController : Controller
{
    public IEmployeeService EmployeeService { get; set; }

    public EmployeeController(IEmployeeService employeeController)
    {
        EmployeeService = employeeController;
    }

    public List<Employee> GetAllEmployees()
    {
        return EmployeeService.GetEmployees();
    }

    public void AddEmployee(Employee employee)
    {
        EmployeeService.AddEmployee(employee);
    }
}