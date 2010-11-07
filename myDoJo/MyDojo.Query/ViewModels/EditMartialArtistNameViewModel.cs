using System;

namespace MyDojo.Query.ViewModels
{
    public class EditMartialArtistNameViewModel
    {
        public EditMartialArtistNameViewModel(){}

        public EditMartialArtistNameViewModel(MartialArtistDetails readModel)
        {
            Id = readModel.Id;
        }

        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}