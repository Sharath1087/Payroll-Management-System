using PayrollMS.Models;

namespace PayrollMS.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeById(int employeeId);
        Task AddEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);
        Task UpdateEmployee(int employeeId, Employee employee);
    }
}
