using System.ComponentModel.DataAnnotations;

namespace myDojo.Web.Models
{
    public class RegisterUserForm
    {
        [Display(Name="Email Address")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + 
         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Not a valid email address")]
        public virtual string EmailAddress { get; set; }
    }
}