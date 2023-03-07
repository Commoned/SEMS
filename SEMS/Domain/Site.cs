namespace SEMS.Domain
{
    public class Site
    {
        public Site(string name, string country, string state, string zipcode, string city, string street, string streetnumber)
        {
            Name = name;
            Address = new Address(country, state, zipcode, city, street, streetnumber);
        }
        override
        public string ToString()
        {
            return Name;
        }

        public string Name { get; set; }
        public Address Address { get; set; }
    }
}