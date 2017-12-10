using System;
using System.ComponentModel.DataAnnotations;

namespace MyClassLibrary
{
    [Serializable]
    public class Submission
    {

        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your surname")]
        [Display(Name = "Surname")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Please write a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please write an 8 digit phone number")]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [Range(00000000, 99999999)]
        public string PhoneNumb { get; set; }

        [Required(ErrorMessage = "Please type in your date of birth")]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter a valid serial number")]
        [Display(Name = "Serial number")]
        [StringLength(16)]
        public string SerialNumb { get; set; } 

    }
}
