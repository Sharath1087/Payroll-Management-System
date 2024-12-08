using System.ComponentModel.DataAnnotations;

namespace PayrollMS.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Class is required.")]
        [StringLength(50, ErrorMessage = "Class cannot exceed 50 characters.")]
        public string Class { get; set; }

        [Required(ErrorMessage = "Designation is required.")]
        [StringLength(50, ErrorMessage = "Designation cannot exceed 50 characters.")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Basic Salary is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        [DataType(DataType.Currency)]
        public decimal BasicSalary { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password cannot exceed 100 characters.")]
        public string Password { get; set; }
    }
}
