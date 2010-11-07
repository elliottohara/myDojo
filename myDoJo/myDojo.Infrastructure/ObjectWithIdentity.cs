using System;

namespace myDojo.Infrastructure
{
    public interface IObjectWithIdentity
    {
        Guid Id { get; set; }
        int Version { get; set; }
    }

    public abstract class ObjectWithIdentity : IObjectWithIdentity
    {
        protected ObjectWithIdentity()
        {
            Id = ANew.Comb();
        }

        protected ObjectWithIdentity(Guid id)
        {
            Id = id;
        }
        public virtual Guid Id { get; set; }
        public virtual int Version { get; set; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (!(obj is ObjectWithIdentity)) return false;
            return Equals((ObjectWithIdentity) obj);
        }

        public bool Equals(ObjectWithIdentity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}