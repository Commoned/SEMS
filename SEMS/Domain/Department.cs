namespace SEMS.Domain
{
    internal class Department
    {
        public Department(string name, string description, string accountingUnit)
        {
            Name = name;
            Description = description;
            AccountingUnit = accountingUnit;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string AccountingUnit { get; set; }


    }
}