using PayrollMS.Models;

namespace PayrollMS.Repository.IRepository
{
    public interface ILeaveRepository
    {
        Task<IEnumerable<LeaveRequest>> GetAllLeaveRequests();
        Task<LeaveRequest> GetLeaveRequestById(int leaveRequestId);
        Task<IEnumerable<LeaveRequest>> GetLeaveRequestsByEmployeeId(int employeeId);
        Task AddLeaveRequest(LeaveRequest leaveRequest);
        Task UpdateLeaveRequest(int leaveRequestId, LeaveRequest leaveRequest);
        Task DeleteLeaveRequest(int leaveRequestId);
    }
}
