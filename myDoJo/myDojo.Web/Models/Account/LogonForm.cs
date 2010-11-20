using System.ComponentModel.DataAnnotations;

namespace myDojo.Web.Models.Account
{
    public class LogonForm
    {
        public string EmailAddress { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name="Remember Me?")]
        public bool RememberMe { get; set; }
    }
}