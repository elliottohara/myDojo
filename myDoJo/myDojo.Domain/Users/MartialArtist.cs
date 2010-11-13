using System;
using System.Collections.Generic;
using myDojo.Domain.Events;
using myDojo.Domain.Events.MartialArtists;
using myDojo.Events.MartialArtists;
using myDojo.Infrastructure.CQRS;

namespace myDojo.Domain.Users
{
    public class MartialArtist : User
    {
        private List<Promotion> _promotions;

        public MartialArtist()
        {
            
        }
        public MartialArtist(string emailAddress) : base(emailAddress)
        {
            _promotions = new List<Promotion>();
        }
        protected internal virtual Rank Rank { get; set; }
        protected internal virtual IEnumerable<Promotion> Promotions { get { return _promotions; } set { _promotions = new List<Promotion>(value); } }
        protected internal virtual  MartialArtist AcceptPromotion(Promotion promotion)
        {
            _promotions.Add(promotion);
            Rank = promotion.Rank;
            DomainEvents.Raise(new StudentPromoted(promotion.Instructor.Id,this.Id,promotion.Rank.Belt,promotion.Rank.Stripes));
            return this;
        }
        public virtual MartialArtist ChangeNameTo(string name)
        {
            DomainEvents.Raise(new MartialArtistChangedName(Id,name));
            return this;
        }
        public virtual MartialArtist ChangeBioTo(string bio)
        {
            DomainEvents.Raise(new MartialArtistChangedBio(Id,bio));
            return this;
        }
        
    }

   
}