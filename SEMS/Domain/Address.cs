using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Domain
{
    public class Address
    {
        public Address( string stateProvince, string zipcode, string city, string street, string number)
        {
            StateProvince = stateProvince;
            Zipcode = zipcode;
            City = city;
            Street = street;
            Number = number;
        }

        public string StateProvince { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

    }
}
