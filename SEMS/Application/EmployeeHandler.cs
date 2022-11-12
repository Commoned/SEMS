using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEMS.Domain;

namespace SEMS.Application
{
    internal class EmployeeHandler
    {
        public EmployeeHandler()
        {

        }

        public List<Employee> employees = new List<Employee>();
        public List<Role> roles = new List<Role>();
        public List<Site> sites = new List<Site>();
        public List<Country> countries = new List<Country>();
        public List<Department> departments = new List<Department>();
        public List<User> users = new List<User>();

        public bool createCountry(string name, string currency, string continent)
        {
            try
            {
                countries.Add(new Country(name, currency, continent));
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
        }
        public bool createRole(string name, string desc)
        {
            int id = 0;
            try
            {
                if(roles.Count >= 1)
                {
                    id = roles.Last().Id + 1;
                }
                
                roles.Add(new Role(name, desc, id));
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
        }

        public bool createSite(string name, string country, string state, string zipcode, string city, string street, string streetnum)
        {
            try
            {
                if (!countries.Exists(x => x.Name == country))
                {
                    throw new Exception("Country does not exist yet");
                }
                sites.Add(new Site(name, countries.Find(x=> x.Name == country),state,zipcode,city,street,streetnum));
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
        }

        public bool createDepartment(string name, Employee employee,string desc, string accountingUnit)
        {
            try
            {
                employees.Add(new Employee(name, employee, desc, accountingUnit));
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
        }

        public bool createEmployee(string name, string surname, string title, string country, string stateProvince, string zipcode, string city, string street, string streetnumber, string site, string department, string role, ulong salaryAmount)
        {
            int id = 0;
            try
            {
                if (employees.Count >= 1)
                {
                    id = employees.Last().Id + 1;
                }
                if (!countries.Exists(x => x.Name == country))
                {
                    throw new Exception("Country does not exist yet");
                }
                employees.Add(new Employee(name, surname, title, id, new User(id.ToString(),"PASSWORD" ),countries.Find(x=> x.Name == country),stateProvince,zipcode,city,street,streetnumber, sites.Find(x => x.Name == site), departments.Find(x => x.Name == department), roles.Find(x => x.Name == role), salaryAmount,DateTime.Now,DateTime.MaxValue));
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
        }

       
    }
}
