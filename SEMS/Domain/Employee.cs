using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Domain
{
    internal class Employee
    {
        
        public Employee(string name, string surname, string title, int id, User user, Country country, string stateProvince, string zipcode, string city, string street, string streetnumber, Site site, Department? department, Role role, ulong salaryAmount, DateTime employedSince, DateTime employedUntil)
        {
            Name = name;
            Surname = surname;
            Title = title;
            Id = id;
            User = user;
            Address = new Address(country, stateProvince,zipcode,city,street,streetnumber);
            Site = site;
            Department = department;
            Role = role;
            SalaryAmount = salaryAmount;
            EmployedSince = employedSince;
            EmployedUntil = employedUntil;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get ; set; }
        public int Id { get; set; }
        public User User { get; set; }

        public Address Address { get; set; }
        public Site Site { get; set; }
        public Department? Department { get; set; }
        public Role Role { get; set; }
        public UInt64 SalaryAmount { get; set; } //Amount is calculated in Currency of current Residency and saved in the lowest form of Currency e.g. USD -> Cent

        public DateTime EmployedSince { get; set; }
        public DateTime EmployedUntil { get; set; }


    }
}
