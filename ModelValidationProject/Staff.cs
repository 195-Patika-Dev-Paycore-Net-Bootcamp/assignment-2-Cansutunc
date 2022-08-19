using System;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationProject
{
    public class Staff
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(120, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 20)]
        public string Name { get; set; }

        [Required]
        [StringLength(120, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 20)]
        public string Lastname { get; set; }

        [Required]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email without specific characters except dot")]
        public string Email { get; set; }

        [Required]
        [Range(typeof(DateTime), "11/11/1945", "10/10/2002", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [RegularExpression(@"^(\+[0-9]{12})$", ErrorMessage = "Please enter correct phone number with country specific number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(2000, 9000, ErrorMessage = "Salary Must be between 2000 to 9000")]
        public int Salary { get; set; }

    }
}
