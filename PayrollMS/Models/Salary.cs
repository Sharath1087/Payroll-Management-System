using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PayrollMS.Models
{
    public class Salary
    {
        [Key]
        public int SalaryId { get; set; }

        [Required(ErrorMessage = "Employee ID is required.")]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Required(ErrorMessage = "Basic Salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Basic Salary must be a positive number.")]
        [DataType(DataType.Currency)]
        public decimal BasicSalary { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "HRA must be a positive number.")]
        [DataType(DataType.Currency)]
        public decimal HRA { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "DA must be a positive number.")]
        [DataType(DataType.Currency)]
        public decimal DA { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Travel Allowance must be a positive number.")]
        [DataType(DataType.Currency)]
        public decimal TravelAllowance { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Medical Allowance must be a positive number.")]
        [DataType(DataType.Currency)]
        public decimal MedicalAllowance { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Deductions must be a positive number.")]
        [DataType(DataType.Currency)]
        public decimal Deductions { get; set; }

        [Required(ErrorMessage = "Net Salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Net Salary must be a positive number.")]
        [DataType(DataType.Currency)]
        public decimal NetSalary { get; set; }
    }
}
