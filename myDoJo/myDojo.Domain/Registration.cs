using System;

namespace myDojo.Domain
{
    public struct Registration
    {
       
        public Guid StudentId { get; set; }
        public Guid DojoId { get; set; }
        public bool Active { get; set; }
    }
}