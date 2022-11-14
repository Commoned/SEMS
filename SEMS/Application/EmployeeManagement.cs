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
        public Country getCountry(string name);
        public Employee getEmployee(string name);
        public User getUser(string name);
        public Department getDepartment(string name);


    }
    internal class EmployeeManagement
    {

        public List<Employee> employees = new List<Employee>();
        
        public EmployeeManagement()
        {

        }

        public Employee newEmployee()
        {
            UserEntry userEntry = new ConsoleEntry();
            IdentificationProvider identificationProvider = new Identification();
            string name = userEntry.acceptEntry();
            string surname = userEntry.acceptEntry();
            string title = userEntry.acceptEntry();
            int id = identificationProvider.provideId();
            User user = new User(name + "." + surname + id.ToString(),"PASSWORD");

            return new Employee(name, surname,title,id, user, );
        }

        

       
    }
}
