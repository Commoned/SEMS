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
                sites.Add(new Site(name, new Address(countries.Find(x=> x.Name == country),state,zipcode,city,street,streetnum)));
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
        }

        public bool createDepartment(string name, string lead,string desc, string accountingUnit)
        {
            try
            {
                departments.Add(new Department(name, lead, desc, accountingUnit));
                return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
        }

        public bool createUser()
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

        public bool createEmployee()
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
    }
}
