using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MyDojo.Query.ViewModels;

namespace myDojo.Web.Models.Users
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
        [HiddenInput(DisplayValue = false)]
        public virtual Guid Id { get; set; }
        [Display(Name = "Name",Order = 1)]
        public virtual String Name { get; set; }
        [Display(Name = "Email Address",Order = 2)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Not a valid email address")]
        public virtual String EmailAddress { get; set; }
        [Display(Name = "Biography")]
        [DataType(DataType.MultilineText)]
        public virtual String Biography { get; set; }
    }
}