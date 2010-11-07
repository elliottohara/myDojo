using System;
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
        public virtual String Name { get; set; }
        public virtual String EmailAddress { get; set; }
        public virtual String Biography { get; set; }
    }
}