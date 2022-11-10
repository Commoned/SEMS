namespace SEMS.Domain
{
    public class Country
    {
        public Country(string name, string currency, string continent)
        {
            Name = name;
            Currency = currency;
            Continent = continent;
        }

        public string Name { get; set; }
        public string Currency { get; set; }
        public string Continent { get; set; }
    }
}