using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Domain
{
    public class Salary
    {
         public Salary(decimal baseSalary, decimal bonuses, decimal deductions, string currency)
        {
            this.baseSalary = baseSalary;
            this.bonuses = bonuses;
            this.deductions = deductions;
            this.currency = currency;
        }

        public decimal baseSalary { get; set; }
        public decimal bonuses { get; set; }
        public decimal deductions { get; set; }
        public string currency { get; set; }

        public decimal NetSalary => CalculateNetSalary();

        public decimal CalculateNetSalary()
        {
            return baseSalary + bonuses - deductions;
        }

        public decimal CalculateAnnualSalary(decimal months)
        {
            return baseSalary * months;
        }

        public decimal CalculateAnnualNetSalary(decimal months)
        {
            return NetSalary * months;
        }

        public decimal CalculateHourlySalary(decimal days, decimal hours)
        {
            return baseSalary / (days * hours);
        }

        public decimal CalculateHourlyNetSalary(decimal days, decimal hours)
        {
            return NetSalary / (days * hours);
        }
    }
}
