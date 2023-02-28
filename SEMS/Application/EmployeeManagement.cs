using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEMS.Domain;

namespace SEMS.Application
{
    public interface UserEntry
    {
        public string acceptEntry();
    }

    public interface IdentificationProvider
    {
        public int provideId();
        public string provideNonNumericId();
    }

    public interface DataHandler
    {
        public Privilege getPrivilege(string name);
        public Employee getEmployee(string name);
        public User getUser(Employee employee);
        public Department getDepartment(string name);
        public Site getSite(string name);
        public Role getRole(string name);

        public void addPrivilege(Privilege privilege);
       
        public void addDepartment(Department department);

        public void addEmployee(Employee employee);

        public void addUser(User user);

        public void addRole(Role role);

        public void addSite(Site site);


    }
    internal class EmployeeManagement
    {
        DataHandler dataHandler;

        public EmployeeManagement(DataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        public Employee newEmployee()
        {
            UserEntry userEntry = new ConsoleEntry();
            IdentificationProvider identificationProvider = new Identification();
            Console.WriteLine("Name:");
            string name = userEntry.acceptEntry();
            Console.WriteLine("Surname:");
            string surname = userEntry.acceptEntry();
            Console.WriteLine("Title:");
            string title = userEntry.acceptEntry();
            int id = identificationProvider.provideId();
           
      
            Console.WriteLine("stateProvince:");
            string stateProvince = userEntry.acceptEntry();
            Console.WriteLine("Zip:");
            string zipcode = userEntry.acceptEntry();
            Console.WriteLine("City:");
            string city = userEntry.acceptEntry();
            Console.WriteLine("Street:");
            string street = userEntry.acceptEntry();
            Console.WriteLine("Streetnumber:");
            string streetnumber = userEntry.acceptEntry();
            Console.WriteLine("Site:");
            Site site = dataHandler.getSite(userEntry.acceptEntry());
            Console.WriteLine("Department:");
            Department department = dataHandler.getDepartment(userEntry.acceptEntry());
            Console.WriteLine("Role:");
            Role role = dataHandler.getRole(userEntry.acceptEntry());
            Console.WriteLine("Salary in EUR/cent:");
            Salary salaryAmount = new Salary(decimal.Parse(userEntry.acceptEntry()), decimal.Parse(userEntry.acceptEntry()), decimal.Parse(userEntry.acceptEntry()),userEntry.acceptEntry());
            DateTime employedSince = DateTime.UtcNow;
            Console.WriteLine("Employment Until:");
            DateTime employedUntil = DateTime.Parse(userEntry.acceptEntry());
            
            return new Employee(name, surname,title,id,stateProvince,zipcode,city,street,streetnumber,site,department,role,salaryAmount,employedSince,employedUntil);
        }

        
       
    }
}
