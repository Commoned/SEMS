using System.Data;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Xml.Linq;
namespace SEMS.Domain
{
    public class User : Employee
    {
        public User(string name, string surname, string title, Privilege privilege, string country, string state, string zipcode, string city, string street, string streetnumber, Site site, Department department, Role role, Salary salary,string loginEmail, string password) 
            : base(name,  surname,  title,  privilege,  country,  state,  zipcode,  city,  street,  streetnumber,  site,  department,  role,  salary)
        {
            LoginEmail = loginEmail;
            Password = password;
        }
        public string LoginEmail { get; set; }
        public string Password { get; set; }
    }
}