using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

    public interface DataHandler : EmployeeHandler, DepartmentHandler, SiteHandler, RoleHandler
    {

    }

    public interface EmployeeHandler
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
        bool deleteEmployee(Employee employee);
        bool deleteUser(User user);
        bool updateEmployee(Employee employee);
        bool updateUser(User user);

        bool addEmployee(Employee employee);
        bool addUser(User user);
    }

    public interface DepartmentHandler
    {
        Department getDepartmentById(int id);
        ObservableCollection<Department> getDepartmentsByName(string name);
        ObservableCollection<Department> getDepartmentsByAccountingUnit(string accountingunit);
        ObservableCollection<Employee> getEmployeesByDepartmentId(int departmentId);
        bool deleteDepartment(Department department);
        bool updateDepartment(Department department);
        bool addDepartment(Department department);
    }

    public interface SiteHandler
    {
        Domain.Site getSiteById(int id);
        ObservableCollection<Domain.Site> getSitesByName(string name);
        ObservableCollection<Domain.Site> getSitesByCountry(string country);
        ObservableCollection<Domain.Site> getSitesByState(string state);
        ObservableCollection<Domain.Site> getSitesByZipcode(string zipcode);
        ObservableCollection<Employee> getEmployeesBySiteId(int siteId);
        bool deleteSite(Domain.Site site);
        bool updateSite(Domain.Site site);
        bool addSite(Domain.Site site);
    }

    public interface RoleHandler
    {
        Role getRoleById(int id);
        ObservableCollection<Role> getRolesByName(string name);
        ObservableCollection<Employee> getEmployeesByRoleId(int roleId);
        bool addRole(Role role);
        bool updateRole(Role role);
        bool deleteRole(Role role);
    }



    public class EmployeeManagement
    {
        EmployeeHandler dataHandler;

        public EmployeeManagement(DataHandler dataInterface)
        {
            this.dataHandler = dataInterface;
        }

        public bool newEmployee(string name, string surname, string title, Privilege privilege, string country, string state, string zipcode, string city, string street, string streetnumber, Domain.Site site, Department department, Role role, Salary salary)
        {

            Debug.WriteLine("Creating Employee");
            Employee newEmp = new Employee(name,surname,title,privilege,country,state,zipcode,city,street,streetnumber,site,department,role,salary);
            return dataHandler.addEmployee(newEmp);

        }

        public ObservableCollection<Employee> GetAllEmployees()
        {
            return dataHandler.getEmployeesByName("");
        }

        public bool updateEmployee(Employee updateEmp)
        {
            Debug.WriteLine("Updating Employee");
            dataHandler.updateEmployee(updateEmp);
            return true;
        }
        public bool deleteEmployee(Employee employee)
        {
            Debug.WriteLine($"Deleting Employee id={employee.Id}");
            return dataHandler.deleteEmployee(employee);
        }

    }
}

