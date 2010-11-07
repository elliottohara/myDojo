using System;
using myDojo.Domain;

namespace MyDojo.Query.ViewModels
{
    public class PromotionViewModel
    {
        public string Rank { get; set; }
        public int Stripes { get; set; }
        public Guid InstructorId { get; set; }
        public string InstructorName { get; set; }
        public DateTime AwardedOn { get; set; }
    }
}