using System.ComponentModel.DataAnnotations;

namespace Haver_Niagara.Models
{
    public class EmployeeMetaData 
    {
        [Display(Name = "Employee")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You cannot leave the first name blank.")]
        [StringLength(50, ErrorMessage = "First name cannot be more than 50 characters long.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You cannot leave the last name blank.")]
        [StringLength(50, ErrorMessage = "Last name cannot be more than 50 characters long.")]
        public string LastName { get; set; }

        [Display(Name = "Employee Role")]
        public EmployeeRole EmployeeRole { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
