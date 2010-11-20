using System;
using System.Collections.Generic;
using myDojo.Infrastructure;

namespace MyDojo.Query.ViewModels
{
    public class MartialArtistDetails : ObjectWithIdentity
    {
        public MartialArtistDetails(Guid id):base(id){}
        public MartialArtistDetails(){}
        public string EmailAddress { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string Belt { get; set; }
        public int Stripes { get; set; }
        public List<PromotionViewModel> Promotions { get; set; }
    }
}