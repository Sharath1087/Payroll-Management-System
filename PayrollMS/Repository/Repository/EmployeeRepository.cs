using Microsoft.EntityFrameworkCore;
using PayrollMS.Data;
using PayrollMS.Models;
using PayrollMS.Repository.IRepository;

namespace PayrollMS.Repository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddEmployee(Employee employee)
        {
            try
            {
                await _context.Set<Employee>().AddAsync(employee);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteEmployee(int employeeId)
        {
            try
            {
                var empToDelete = await GetEmployeeById(employeeId);
                if(empToDelete != null)
                {
                    _context.Set<Employee>().Remove(empToDelete);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Employee with ID:{employeeId} does not exist");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            try
            {
                return await _context.Set<Employee>().ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            try
            {
                var employee = await _context.Set<Employee>().FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
                if (employee != null)
                    return employee;
                else
                {
                    throw new Exception($"Employee with ID: {employeeId} does not exist");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateEmployee(int employeeId, Employee employee)
        {
            try
            {
                var empToUpdate = await GetEmployeeById(employeeId);
                if(empToUpdate != null)
                {
                    empToUpdate.Name = employee.Name;
                    empToUpdate.Class = employee.Class;
                    empToUpdate.Designation = employee.Designation;
                    empToUpdate.BasicSalary = employee.BasicSalary;
                    empToUpdate.Username = employee.Username;
                }
                else
                {
                    throw new Exception($"Employee with ID: {employeeId} does not exist");
                }
            }
        }
    }
}
