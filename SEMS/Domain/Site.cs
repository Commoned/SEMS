namespace SEMS.Domain
{
    public class Site
    {
        public Site(string name, string country, string state, string zipcode, string city, string street, string streetnumber)
        {
            Name = name;
            Address = new Address(country, state, zipcode, city, street, streetnumber);
        }
        public Site(int id, string name, string country, string state, string zipcode, string city, string street, string streetnumber)
        {
            Id = id;
            Name = name;
            Address = new Address(country, state, zipcode, city, street, streetnumber);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}