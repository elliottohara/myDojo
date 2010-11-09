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
        public virtual String EmailAddress { get; set; }
        [Display(Name = "Biography")]
        public virtual String Biography { get; set; }
    }
    public class RegisterUserForm
    {
        [Display(Name="Email Address")]
        public virtual string EmailAddress { get; set; }
    }
}