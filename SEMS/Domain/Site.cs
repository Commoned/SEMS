namespace SEMS.Domain
{
    public class Site
    {
        public Site(string name, string stateProvince, string zipcode, string city, string street, string streetnumber)
        {
            Name = name;
            Address = new Address(stateProvince, zipcode, city, street, streetnumber);
        }

        public string Name { get; set; }
        public Address Address { get; set; }
    }
}