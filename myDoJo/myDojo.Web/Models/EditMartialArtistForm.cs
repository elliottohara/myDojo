using System;
using System.ComponentModel.DataAnnotations;
using MyDojo.Query.ViewModels;

namespace myDojo.Web.Models
{
    public class EditMartialArtistForm
    {
        public EditMartialArtistForm(){}

        public EditMartialArtistForm(MartialArtistDetails martialArtistDetails)
        {
            Id = martialArtistDetails.Id;
            Name = martialArtistDetails.Name;
            EmailAddress = martialArtistDetails.EmailAddress;
            Biography = martialArtistDetails.Biography;
        }

        public virtual Guid Id { get; set; }
        [Display(Name = "Name")]
        public virtual String Name { get; set; }
        [Display(Name = "Email Address")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Not a valid email address")]
        public virtual String EmailAddress { get; set; }
        [Display(Name = "Biography")]
        public virtual String Biography { get; set; }
    }
}