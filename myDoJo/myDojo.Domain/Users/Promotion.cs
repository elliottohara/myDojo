using System;

namespace myDojo.Domain.Users
{
    public struct Promotion
    {
        public Instructor Instructor { get; set; }
        public DateTime AwardedOn { get; set; }
        public Rank Rank { get; set; }
    }
}