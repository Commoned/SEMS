namespace SEMS.Domain
{
    public class Site
    {
        public Site(string name,Country country, string stateProvince, string zipcode, string city, string street, string streetnumber)
        {
            Name = name;
            Address = new Address(country, stateProvince, zipcode, city, street, streetnumber);
        }

        public string Name { get; set; }
        public Address Address { get; set; }
    }
}