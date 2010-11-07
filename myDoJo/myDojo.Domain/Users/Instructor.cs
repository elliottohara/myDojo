using System;

namespace myDojo.Domain.Users
{
    public class Instructor : MartialArtist
    {
        public Instructor(string emailAddress):base(emailAddress)
        {
            
        }
        public void Promote(MartialArtist student, Rank rank)
        {
            var promotion = new Promotion {AwardedOn = DateTime.Now, Instructor = this, Rank = rank};
            student.AcceptPromotion(promotion);
        }
    }
}