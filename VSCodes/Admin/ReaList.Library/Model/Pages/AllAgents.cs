using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaList.Library.Model.Pages
{
    public class AllAgents
    {
        public int AgentID { get; set; } = 0;

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
        public int AgentType { get; set; }
        public string MiddleName { get; set; } = null!;
        public string Suffix { get; set; } = null!;
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ProfilePicture { get; set; } = null!;
        public string AgentAbout { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string Education { get; set; } = null!;
        public string Organizations { get; set; } = null!;
        public string LicenseIdNumber { get; set; } = null!;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
    
}
