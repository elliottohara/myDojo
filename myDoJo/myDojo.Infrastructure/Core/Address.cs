namespace myDojo.Infrastructure.Core
{
    public struct Address
    {
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public override string ToString()
        {
            return string.Format("{0}\n{1}\n{2}, {3}\n{4}", StreetNumber, Street, City, State, PostalCode);
        }
    }
}