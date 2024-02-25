using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.Model.UserAccounts
{
    public class AdminAccountModel
    {
        public int AdminID { get; set; } = 0;

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
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password do not match.")]
        public string ConfirmPassword { get; set; } = null!;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public Nullable<System.Guid> ActivationCode { get; set; }
        public Nullable<bool> IsEmailVerified { get; set; }
        public Nullable<System.Guid> ResetPasswordCode { get; set; }
        public byte isVerified { get; set; } = 0;
        public int AccountStatus { get; set; } = 1;
       
    }
}
