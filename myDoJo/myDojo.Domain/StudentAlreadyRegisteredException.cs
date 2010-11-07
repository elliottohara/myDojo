using System;
using myDojo.Domain.Users;

namespace myDojo.Domain
{
    public class StudentAlreadyRegisteredException : Exception
    {
        public Dojo Dojo { get; set; }
        public MartialArtist MartialArtist { get; set; }

        public StudentAlreadyRegisteredException(Dojo dojo, MartialArtist martialArtist)
        {
            Dojo = dojo;
            MartialArtist = martialArtist;
        }
        public override string Message
        {
            get { return String.Format("Student#{0} already registed at Dojo#{1}", MartialArtist.Id, Dojo.Id); }
        }
    }
}