using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Domain
{
    public class Employee
    {
        
        public Employee(string name, string surname, string title, Privilege privilege, int id, string country, string state, string zipcode, string city, string street, string streetnumber, Site site, Department department, Role role, Salary salary)
        {
            Name = name;
            Surname = surname;
            Title = title;
            Id = id;
            Privilege = privilege;
            Address = new Address(country,state,zipcode,city,street,streetnumber);
            Site = site;
            Department = department;
            Role = role;
            Salary = salary;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get ; set; }
        public int Id { get; set; }
        public Privilege Privilege { get; set; }
        public Address Address { get; set; }
        public Site Site { get; set; }
        public Department Department { get; set; }
        public Role Role { get; set; }
        public Salary Salary { get; set; } 

    }
}
