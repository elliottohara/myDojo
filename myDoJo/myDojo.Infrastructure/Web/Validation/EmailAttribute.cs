using System.ComponentModel.DataAnnotations;

namespace myDojo.Infrastructure.Web.Validation
{
    public class EmailAttribute : RegularExpressionAttribute 
    {
        public EmailAttribute() : base(@"(([^<>()[\]\\.,;:\s@\""]+"
                        + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
                        + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
                        + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
                        + @"[a-zA-Z]{2,}))$"){}
       
    }
}