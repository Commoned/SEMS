namespace SEMS.Domain
{
    public class Department
    {
        public Department(string name, string description, string accountingUnit)
        {
            Name = name;
            Description = description;
            AccountingUnit = accountingUnit;
        }

        public Department(int id, string name, string description, string accountingUnit)
        {
            Id = id;
            Name = name;
            Description = description;
            AccountingUnit = accountingUnit;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AccountingUnit { get; set; }


    }
}