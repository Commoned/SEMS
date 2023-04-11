using SEMS.Domain;
using SEMS.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.IO;
using System.Collections.ObjectModel;

namespace SEMS.Adapter.Database
{
    public class DatabaseFacade : DataHandler
    {
        private string dblocation;
        private DepartmentHandler departmentHandler;
        private EmployeeHandler employeeHandler;
        private RoleHandler roleHandler;
        private SiteHandler siteHandler;
        public DatabaseFacade(string dblocation = "..\\..\\..\\Adapter\\Database\\sems.sqlite")
        {
            this.dblocation = "Data Source = " + dblocation;
            this.employeeHandler = new EmployeeData(this.dblocation,this);
            this.departmentHandler = new DepartmentData(this.dblocation,this);
            this.roleHandler = new RoleData(this.dblocation, this);
            this.siteHandler = new SiteData(this.dblocation, this);
        }
        #region Facades
        public bool addDepartment(Department department)
        {
            return departmentHandler.addDepartment(department);
        }

        public bool addEmployee(Employee employee)
        {
            return employeeHandler.addEmployee(employee);
        }

        public bool addRole(Role role)
        {
            return roleHandler.addRole(role);
        }

        public bool addSite(Site site)
        {
            return siteHandler.addSite(site);
        }

        public bool addUser(User user)
        {
            return employeeHandler.addUser(user);
        }

        public bool deleteDepartment(Department department)
        {
            return departmentHandler.deleteDepartment(department);
        }

        public bool deleteEmployee(Employee employee)
        {
           return employeeHandler.deleteEmployee(employee);
        }

        public bool deleteRole(Role role)
        {
            return roleHandler.deleteRole(role);    
        }

        public bool deleteSite(Site site)
        {
            return siteHandler.deleteSite(site);
        }

        public bool deleteUser(User user)
        {
            return employeeHandler.deleteUser(user);
        }

        public Department getDepartmentById(int id)
        {
           return departmentHandler.getDepartmentById(id);
        }

        public ObservableCollection<Department> getDepartmentsByAccountingUnit(string accountingunit)
        {
            return departmentHandler.getDepartmentsByAccountingUnit(accountingunit);
        }

        public ObservableCollection<Department> getDepartmentsByName(string name)
        {
            return departmentHandler.getDepartmentsByName(name);
        }

        public Employee getEmployeeById(int id)
        {
            return employeeHandler.getEmployeeById(id);
        }

        public ObservableCollection<Employee> getEmployeesByDepartmentId(int departmentId)
        {
            return employeeHandler.getEmployeesByDepartmentId(departmentId);
        }

        public ObservableCollection<Employee> getEmployeesByFullname(string name, string surname)
        {
            return employeeHandler.getEmployeesByFullname(name, surname);
        }

        public ObservableCollection<Employee> getEmployeesByName(string name)
        {
            return employeeHandler.getEmployeesByName(name);
        }

        public ObservableCollection<Employee> getEmployeesByRoleId(int roleId)
        {
            return employeeHandler.getEmployeesByRoleId(roleId);
        }

        public ObservableCollection<Employee> getEmployeesBySiteId(int siteId)
        {
            return employeeHandler.getEmployeesBySiteId((int)siteId);
        }

        public ObservableCollection<Employee> getEmployeesBySurname(string surname)
        {
            return employeeHandler.getEmployeesBySurname(surname);
        }

        public Privilege getPrivilegeByName(string name)
        {
            return employeeHandler.getPrivilegeByName(name);
        }

        public Role getRoleById(int id)
        {
           return roleHandler.getRoleById(id);  
        }

        public ObservableCollection<Role> getRolesByName(string name)
        {
            return roleHandler.getRolesByName(name);    
        }

        public Site getSiteById(int id)
        {
            return siteHandler.getSiteById(id); 
        }

        public ObservableCollection<Site> getSitesByCountry(string country)
        {
           return siteHandler.getSitesByCountry(country);
        }

        public ObservableCollection<Site> getSitesByName(string name)
        {
            return siteHandler.getSitesByName(name);
        }

        public ObservableCollection<Site> getSitesByState(string state)
        {
            return siteHandler.getSitesByState(state);
        }

        public ObservableCollection<Site> getSitesByZipcode(string zipcode)
        {
            return siteHandler.getSitesByZipcode(zipcode);
        }

        public User getUser(Employee employee)
        {
            return employeeHandler.getUser(employee);
        }

        public bool updateDepartment(Department department)
        {
            return departmentHandler.updateDepartment(department);
        }

        public bool updateEmployee(Employee employee)
        {
            return employeeHandler.updateEmployee(employee);
        }

        public bool updateRole(Role role)
        {
            return roleHandler.updateRole(role);
        }

        public bool updateSite(Site site)
        {
            return siteHandler.updateSite(site);
        }

        public bool updateUser(User user)
        {
            return employeeHandler.updateUser(user);
        }
        #endregion

        private SqliteConnection GetSqliteConnection()
        {
            var connection = new SqliteConnection(dblocation);
            connection.Open();
            return connection;
        }
    }
}
