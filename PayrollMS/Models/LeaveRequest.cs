using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PayrollMS.Models
{
    public class LeaveRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveRequestId { get; set; }

        [Required(ErrorMessage = "Employee ID is required.")]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        [DataType(DataType.Date)]
        [Compare("StartDate", ErrorMessage = "End Date must be greater than or equal to Start Date.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Reason is required.")]
        [StringLength(250, ErrorMessage = "Reason cannot exceed 250 characters.")]
        public string Reason { get; set; }

        [RegularExpression("^(Approved|Rejected|Pending)$", ErrorMessage = "Status must be either Approved or Rejected or Pending.")]
        public string Status { get; set; }
    }
}
