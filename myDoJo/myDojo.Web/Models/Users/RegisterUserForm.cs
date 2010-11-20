using System.ComponentModel.DataAnnotations;
using myDojo.Infrastructure.Web.Validation;

namespace myDojo.Web.Models
{
    [PropertiesMustMatch("Password","ConfirmPassword")]
    public class RegisterUserForm
    {
        [Display(Name="Email Address",Order = 1)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + 
         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Not a valid email address")]
        public virtual string EmailAddress { get; set; }
        [Display(Name = "Password",Order=2)]
        [DataType(DataType.Password)]
        public virtual string Password { get; set; }
        [Display(Name = "Password", Order = 3)]
        [DataType(DataType.Password)]
        public virtual string ConfirmPassword { get; set; }
    }
}