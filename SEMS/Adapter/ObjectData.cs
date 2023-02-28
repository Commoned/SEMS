using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEMS.Domain;
using SEMS.Application;


namespace SEMS.Adapter
{
    public class ObjectData : DataHandler
    {
        List<Privilege> privileges = new List<Privilege>();
        List<Department> departments = new List<Department>();
        List<Employee> employees = new List<Employee>();
        List<Role> roles = new List<Role>();
        List<User> users = new List<User>();
        List<Site> sites = new List<Site>();

        public ObjectData()
        {
            
        }

        public Privilege getPrivilege(string name)
        {
            
            Privilege privilege = privileges.First(x => x.Name == name);
            if (privilege == null)
            {
                throw new Exception("No Privilege found!");
            }
            return privilege;
        }

        public Department getDepartment(string name)
        {

            Department department = departments.First(x => x.Name == name);
            if (department == null)
            {
                throw new Exception("No Department found!");
            }
            return department;
        }

        public Employee getEmployee(string name)
        {

            Employee employee = employees.First(x => x.Name == name);
            if (employee == null)
            {
                throw new Exception("No Employee found!");
            }
            return employee;
        }

        public Role getRole(string name)
        {

            Role role = roles.First(x => x.Name == name);
            if (role == null)
            {
                throw new Exception("No Role found!");
            }
            return role;
        }

        public User getUser(Employee employee)
        {
            
            User user = users.First(x => x.Employee == employee);
            if (user == null)
            {
                throw new Exception("No User found!");
            }
            return user;
        }

        public Site getSite(string name)
        {

            Site site = sites.First(x => x.Name == name);
            if (site == null)
            {
                throw new Exception("No Role found!");
            }
            return site;
        }

        public void addPrivilege(Privilege privilege)
        {
            privileges.Add(privilege);
        }
        public void addDepartment(Department department)
        {
            departments.Add(department);
        }
        public void addEmployee(Employee employee)
        {
            employees.Add(employee);
        }
        public void addUser(User user)
        {
            users.Add(user);
        }
        public void addRole(Role role)
        {
            roles.Add(role);
        }
        public void addSite(Site site)
        {
            sites.Add(site);
        }
        
    }
}
