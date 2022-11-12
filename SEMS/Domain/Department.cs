namespace SEMS.Domain
{
    internal class Department
    {
        public Department(string name, string lead, string description, string accountingUnit)
        {
            Name = name;
            Lead = lead;
            Description = description;
            AccountingUnit = accountingUnit;
        }

        public string Name { get; set; }
        public string Lead { get; set; }
        public string Description { get; set; }
        public string AccountingUnit { get; set; }


    }
}