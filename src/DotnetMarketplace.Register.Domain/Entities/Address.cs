namespace DotnetMarketplace.Domain
{
    public class Address
    {
        public int AddressId { get; set; }
        public int UserId { get; set; }
        public int StateId { get; set; }
        public string Street { get; set; }
        public string CEP { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string Complement { get; set; }
    }
}