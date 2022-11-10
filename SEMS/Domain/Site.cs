namespace SEMS.Domain
{
    internal class Site
    {
        public Site(string name,Address address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; set; }
        public Address Address { get; set; }
    }
}