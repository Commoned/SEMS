using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using SEMS.Adapter;
using SEMS.Domain;

namespace SEMS.Application
{
    public interface UserEntry
    {
        string acceptEntry();
    }

    public interface IdentificationProvider
    {
        int provideId();

        string provideNonNumericId();
    }

    public interface DataHandler
    {
        Privilege getPrivilegeByName(string name);
        Employee getEmployeeById(int id);
        ObservableCollection<Employee> getEmployeesByName(string name);
        ObservableCollection<Employee> getEmployeesBySurname(string surname);
        ObservableCollection<Employee> getEmployeesByFullname(string name, string surname);
        ObservableCollection<Employee> getEmployeesBySiteId(int siteId);
        ObservableCollection<Employee> getEmployeesByDepartmentId(int departmentId);
        ObservableCollection<Employee> getEmployeesByRoleId(int roleId);
        User getUser(Employee employee);
        Department getDepartmentById(int id);
        ObservableCollection<Department> getDepartmentsByName(string name);
        ObservableCollection<Department> getDepartmentsByAccountingUnit(string accountingunit);
        Domain.Site getSiteById(int id);
        ObservableCollection<Domain.Site> getSitesByName(string name);
        ObservableCollection<Domain.Site> getSitesByCountry(string country);
        ObservableCollection<Domain.Site> getSitesByState(string state);
        ObservableCollection<Domain.Site> getSitesByZipcode(string zipcode);
        Role getRoleById(int id);
        ObservableCollection<Role> getRolesByName(string name);

        bool addEmployee(Employee employee);
        bool addUser(User user);
        bool addDepartment(Department department);
        bool addSite(Domain.Site site);
        bool addRole(Role role);
    }
    internal static class EmployeeManagement
    {
        static DataHandler dataHandler = new Database();

        /*public EmployeeManagement(DataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        */
        public static Employee newEmployee()
        {
            //dataHandler.getEmployee("TEST");
            //Employee myemployee = dataHandler.getEmployeesByName("Tim").First();
            //Employee myemployee = dataHandler.getEmployeesBySurname("Frie").First();
            //Employee myemployee = dataHandler.getEmployeesByFullname("T","Fr").First();
            //Employee myemployee = dataHandler.getEmployeesBySiteId(1).First();
            //Employee myemployee = dataHandler.getEmployeesByDepartmentId(1).First();
            //Employee myemployee = dataHandler.getEmployeesByRoleId(1).First();
            //Console.WriteLine(myemployee.Salary.baseSalary);
            //dataHandler.getEmployeeById(1);
            //dataHandler.getDepartmentById(1);
            //dataHandler.getDepartmentsByName("Gebäude 10");
            //dataHandler.getDepartmentsByAccountingUnit("187");
            //dataHandler.getSiteById(1);
            //Domain.Site mysite = dataHandler.getSitesByName("Atruvia").First();
            //Domain.Site mysite = dataHandler.getSitesByCountry("GER").First();
            //Domain.Site mysite = dataHandler.getSitesByState("BaWü").First();
            //Domain.Site mysite = dataHandler.getSitesByZipcode("76").First();
            //Console.WriteLine(mysite.Address.Zipcode);
            //dataHandler.getRoleById(1);
            //Role myrole = dataHandler.getRolesByName("Dual").First();
            //Console.WriteLine(myrole.Description);
            //Domain.Role myrole = new Role("Student", "Absolut faul");
            //Console.WriteLine(dataHandler.addRole(myrole));
            //Domain.Site site = new Domain.Site(name: "Telekom", country: "GER", state: "Bayern", zipcode: "80331", city: "München", street: "Haupstraße", streetnumber: "1");
            //Console.WriteLine(dataHandler.addSite(site));

            /*
            Console.WriteLine("DIESE IST KAKA");
            UserEntry userEntry = new ConsoleEntry();
            IdentificationProvider identificationProvider = new Identification();
            Console.WriteLine("Name:");
            string name = userEntry.acceptEntry();
            Console.WriteLine("Surname:");
            string surname = userEntry.acceptEntry();
            Console.WriteLine("Title:");
            string title = userEntry.acceptEntry();
            int id = identificationProvider.provideId();


            Console.WriteLine("country:");
            string country = userEntry.acceptEntry();
            Console.WriteLine("state:");
            string state = userEntry.acceptEntry();
            Console.WriteLine("Zip:");
            string zipcode = userEntry.acceptEntry();
            Console.WriteLine("City:");
            string city = userEntry.acceptEntry();
            Console.WriteLine("Street:");
            string street = userEntry.acceptEntry();
            Console.WriteLine("Streetnumber:");
            string streetnumber = userEntry.acceptEntry();
            Console.WriteLine("Site:");
            Domain.Site site = dataHandler.getSite(userEntry.acceptEntry());
            Console.WriteLine("Department:");
            Department department = dataHandler.getDepartment(userEntry.acceptEntry());
            Console.WriteLine("Role:");
            Role role = dataHandler.getRole(userEntry.acceptEntry());
            Console.WriteLine("Salary in EUR/cent:");
            Salary salaryAmount = new Salary(decimal.Parse(userEntry.acceptEntry()), decimal.Parse(userEntry.acceptEntry()), decimal.Parse(userEntry.acceptEntry()), userEntry.acceptEntry());
            DateTime employedSince = DateTime.UtcNow;
            Console.WriteLine("Employment Until:");
            DateTime employedUntil = DateTime.Parse(userEntry.acceptEntry());
            */
            //return new Employee(name, surname, title, id, country, state, zipcode, city, street, streetnumber, site, department, role, salaryAmount, employedSince, employedUntil);
            return null;
        }



    }
}

