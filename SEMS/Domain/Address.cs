

namespace SEMS.Domain
{
    public class Address
    {
        public Address( string country, string state, string zipcode, string city, string street, string number)
        {
            Country = country;
            State = state;
            Zipcode = zipcode;
            City = city;
            Street = street;
            Number = number;
        }

        public string Country { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

    }
}
