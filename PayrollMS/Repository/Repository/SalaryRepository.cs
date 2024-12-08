using Microsoft.EntityFrameworkCore;
using PayrollMS.Data;
using PayrollMS.Models;
using PayrollMS.Repository.IRepository;

namespace PayrollMS.Repository.Repository
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly ApplicationDbContext _context;
        public SalaryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Salary>> GetAllSalaries()
        {
            try
            {
                return await _context.Set<Salary>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Salary> GetSalaryById(int salaryId)
        {
            try
            {
                var salary = await _context.Set<Salary>().FirstOrDefaultAsync(l => l.SalaryId == salaryId);
                if (salary != null)
                    return salary;
                else
                    throw new Exception($"Salary with ID: {salaryId} does not exist");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Salary>> GetSalariesByEmployeeId(int employeeId)
        {
            try
            {
                var employeeSalary = await _context.Set<Salary>().Where(e => e.EmployeeId == employeeId).ToListAsync();
                if (employeeSalary != null)
                    return employeeSalary;
                else
                    throw new Exception($"Employee with ID: {employeeId} does not have any salary");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddSalary(Salary salary)
        {
            try
            {
                await _context.Set<Salary>().AddAsync(salary);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateSalary(int salaryId, Salary salary)
        {
            try
            {
                var salaryToUpdate = await GetSalaryById(salaryId);
                if (salaryToUpdate != null)
                {
                    salaryToUpdate.BasicSalary = salary.BasicSalary;
                    salaryToUpdate.HRA = salary.HRA;
                    salaryToUpdate.DA = salary.DA;
                    salaryToUpdate.TravelAllowance = salary.TravelAllowance;
                    salaryToUpdate.MedicalAllowance = salary.MedicalAllowance;
                    salaryToUpdate.Deductions = salary.Deductions;
                    salaryToUpdate.NetSalary = salary.NetSalary;
                }
                else
                    throw new Exception($"Salary with ID: {salaryId} does not exist");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteSalary(int salaryId)
        {
            try
            {
                var salaryToDelete = await GetSalaryById(salaryId);
                if (salaryToDelete != null)
                {
                    _context.Set<Salary>().Remove(salaryToDelete);
                    await _context.SaveChangesAsync();
                }
                else
                    throw new Exception($"Salary with ID: {salaryId} does not exist");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
