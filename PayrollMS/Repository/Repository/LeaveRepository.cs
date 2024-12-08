using Microsoft.EntityFrameworkCore;
using PayrollMS.Data;
using PayrollMS.Models;
using PayrollMS.Repository.IRepository;

namespace PayrollMS.Repository.Repository
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly ApplicationDbContext _context;
        public LeaveRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LeaveRequest>> GetAllLeaveRequests()
        {
            try
            {
                return await _context.Set<LeaveRequest>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LeaveRequest> GetLeaveRequestById(int leaveRequestId)
        {
            try
            {
                var leaveRequest = await _context.Set<LeaveRequest>().FirstOrDefaultAsync(l => l.LeaveRequestId == leaveRequestId);
                if (leaveRequest != null)
                    return leaveRequest;
                else
                    throw new Exception($"Leave request with ID: {leaveRequestId} does not exist");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<LeaveRequest>> GetLeaveRequestsByEmployeeId(int employeeId)
        {
            try
            {
                var employeeLeaveRequest = await _context.Set<LeaveRequest>().Where(e => e.EmployeeId == employeeId).ToListAsync();
                if (employeeLeaveRequest != null)
                    return employeeLeaveRequest;
                else
                    throw new Exception($"Employee with ID: {employeeId} does not have any leave request");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddLeaveRequest(LeaveRequest leaveRequest)
        {
            try
            {
                await _context.Set<LeaveRequest>().AddAsync(leaveRequest);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateLeaveRequest(int leaveRequestId, LeaveRequest leaveRequest)
        {
            try
            {
                var requestToUpdate = await GetLeaveRequestById(leaveRequestId);
                if (requestToUpdate != null)
                {
                    requestToUpdate.StartDate = leaveRequest.StartDate;
                    requestToUpdate.EndDate = leaveRequest.EndDate;
                    requestToUpdate.Reason = leaveRequest.Reason;
                    requestToUpdate.Status = leaveRequest.Status;
                }
                else
                    throw new Exception($"Leave request with ID: {leaveRequestId} does not exist");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteLeaveRequest(int leaveRequestId)
        {
            try
            {
                var requestToDelete = await GetLeaveRequestById(leaveRequestId);
                if(requestToDelete != null)
                {
                    _context.Set<LeaveRequest>().Remove(requestToDelete);
                    await _context.SaveChangesAsync();
                }
                else
                    throw new Exception($"Leave request with ID: {leaveRequestId} does not exist");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
