using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.Model.UserAccounts
{
    public class CustomerAccountModel
    {
        /*REGISTRATION*/
        public int CustomerID { get; set; } = 0;

        [Required]
        [Display(Name = "First Name")]
        public String FirstName { get; set; } = String.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public String LastName { get; set; } = String.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public String Email { get; set; } = String.Empty;

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        public string Password { get; set; } = null!;
        public byte isVerified { get; set; } = 0;
        public int AccountStatus { get; set; } = 1;
        public DateTime DateCreated { get; set; } = DateTime.Now;

        /*PROFILE*/
        public DateTime Birthdate { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? ProfilePicture { get; set; }
        public IFormFile? ProfilePictureImage { get; set; }
        public DateTime DateUpdated { get; set; } = DateTime.Now;

        /*NOT INCLUDED IN THE DATABASE*/
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password do not match.")]
        public string ConfirmPassword { get; set; } = null!;
        public Nullable<System.Guid> ActivationCode { get; set; }
        /*RATE AGENTS*/
        public int AgentRatingsID { get; set; } = 0;
        public int BookingID { get; set; }
        public int AgentID { get; set; }
        public int AgentRatings { get; set; }
        public string? Feedback { get; set; }
        public decimal? TotalAgentRatingsAve { get; set; }
        public Nullable<System.Guid> ResetPasswordCode { get; set; }
        public Nullable<bool> IsEmailVerified { get; set; }
        /* Contact Us */
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}