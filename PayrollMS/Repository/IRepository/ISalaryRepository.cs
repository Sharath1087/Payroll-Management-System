using PayrollMS.Models;

namespace PayrollMS.Repository.IRepository
{
    public interface ISalaryRepository
    {
        Task<IEnumerable<Salary>> GetAllSalaries();
        Task<Salary> GetSalaryById(int salaryId);
        Task<IEnumerable<Salary>> GetSalariesByEmployeeId(int employeeId);
        Task AddSalary(Salary salary);
        Task UpdateSalary(int salaryId, Salary salary);
        Task DeleteSalary(int salaryId);
    }
}
