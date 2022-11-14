using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Domain
{
    public class Address
    {
        public Address(Country country, string stateProvince, string zipcode, string city, string street, string number)
        {
            Country = country;
            StateProvince = stateProvince;
            Zipcode = zipcode;
            City = city;
            Street = street;
            Number = number;
        }

        public Country Country { get; set; }
        public string StateProvince { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

    }
}
