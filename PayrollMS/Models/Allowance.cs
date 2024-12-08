using System.ComponentModel.DataAnnotations;

namespace PayrollMS.Models
{
    public class Allowance
    {
        [Key]
        public int AllowanceId { get; set; }

        [Required(ErrorMessage = "HRA is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "HRA must be a positive number.")]
        [DataType(DataType.Currency)]
        public decimal HRA { get; set; }

        [Required(ErrorMessage = "DA is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "DA must be a positive number.")]
        [DataType(DataType.Currency)]
        public decimal DA { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Travel Allowance must be a positive number.")]
        [DataType(DataType.Currency)]
        public decimal TravelAllowance { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Medical Allowance must be a positive number.")]
        [DataType(DataType.Currency)]
        public decimal MedicalAllowance { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Washing Allowance must be a positive number.")]
        [DataType(DataType.Currency)]
        public decimal WashingAllowance { get; set; }
    }
}
