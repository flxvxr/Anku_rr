using Learn.Models;

namespace Learn.Services;

public interface IEmployeeService
{
    public List<Employee> GetEmployees();
    
    public void AddEmployee(Employee employee);
}