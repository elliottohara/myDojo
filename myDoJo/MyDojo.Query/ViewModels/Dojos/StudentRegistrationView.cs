using System;
using myDojo.Infrastructure;

namespace MyDojo.Query.ViewModels.Dojos
{
    public class StudentRegistrationView : ObjectWithIdentity
    {
        public virtual string StudentName { get; set; }
        public virtual DateTime JoinedOn { get; set; }
        public virtual Guid StudentId { get; set; }
        public virtual Guid DojoId { get; set; }
        public virtual string DojoName { get; set; }
    }
}