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

namespace SEMS.Adapter
{
    internal class Database : DataHandler
    {
        private string dblocation = "Data Source = ..\\..\\Adapter\\Database\\sems.sqlite";
        public Database()
        {
        }

        public Privilege getPrivilegeByName(string name)
        {
            Privilege privilege = new Privilege("");
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT privilege
                FROM employees
                WHERE privilege LIKE $myprivilege
                ";

                command.Parameters.AddWithValue("$myprivilege", $"{name}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        privilege.Name = reader.GetString(0);
                    }
                }
            }
            return privilege;
        }

        public Employee getEmployeeById(int id)
        {
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT employee_id, name, surname, title, privilege, country, state, zipcode, city, street, streetnumber, site_id, department_id, role_id, basesalary, bonus, deduction, currency
                FROM employees
                WHERE employee_id = $myprivilege
                ";

                command.Parameters.AddWithValue("$myprivilege", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee(name: reader.GetString(1), surname: reader.GetString(2), title: reader.GetString(3), privilege: new Privilege(reader.GetString(4)), id: reader.GetInt32(0), country: reader.GetString(5), state: reader.GetString(6), zipcode: reader.GetString(7), city: reader.GetString(8), street: reader.GetString(9), streetnumber: reader.GetString(10), site: getSiteById(reader.GetInt32(11)), department: getDepartmentById(reader.GetInt32(12)), role: getRoleById(reader.GetInt32(13)), salary: new Salary(baseSalary: reader.GetDecimal(14), bonuses: reader.GetDecimal(15), deductions: reader.GetDecimal(16), currency: reader.GetString(17)));
                        return employee;
                    }
                }
            }
            return null;
        }

        public ObservableCollection<Employee> getEmployeesByName(string name)
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT employee_id, name, surname, title, privilege, country, state, zipcode, city, street, streetnumber, site_id, department_id, role_id, basesalary, bonus, deduction, currency
                FROM employees
                WHERE name LIKE $myname
                ";

                command.Parameters.AddWithValue("$myname", $"{name}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee(name: reader.GetString(1), surname: reader.GetString(2), title: reader.GetString(3), privilege: new Privilege(reader.GetString(4)), id: reader.GetInt32(0), country: reader.GetString(5), state: reader.GetString(6), zipcode: reader.GetString(7), city: reader.GetString(8), street: reader.GetString(9), streetnumber: reader.GetString(10), site: getSiteById(reader.GetInt32(11)), department: getDepartmentById(reader.GetInt32(12)), role: getRoleById(reader.GetInt32(13)), salary: new Salary(baseSalary: reader.GetDecimal(14), bonuses: reader.GetDecimal(15), deductions: reader.GetDecimal(16), currency: reader.GetString(17)));
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        public ObservableCollection<Employee> getEmployeesBySurname(string surname)
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT employee_id, name, surname, title, privilege, country, state, zipcode, city, street, streetnumber, site_id, department_id, role_id, basesalary, bonus, deduction, currency
                FROM employees
                WHERE surname LIKE $mysurname
                ";

                command.Parameters.AddWithValue("$mysurname", $"{surname}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee(name: reader.GetString(1), surname: reader.GetString(2), title: reader.GetString(3), privilege: new Privilege(reader.GetString(4)), id: reader.GetInt32(0), country: reader.GetString(5), state: reader.GetString(6), zipcode: reader.GetString(7), city: reader.GetString(8), street: reader.GetString(9), streetnumber: reader.GetString(10), site: getSiteById(reader.GetInt32(11)), department: getDepartmentById(reader.GetInt32(12)), role: getRoleById(reader.GetInt32(13)), salary: new Salary(baseSalary: reader.GetDecimal(14), bonuses: reader.GetDecimal(15), deductions: reader.GetDecimal(16), currency: reader.GetString(17)));
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        public ObservableCollection<Employee> getEmployeesByFullname(string name, string surname)
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT employee_id, name, surname, title, privilege, country, state, zipcode, city, street, streetnumber, site_id, department_id, role_id, basesalary, bonus, deduction, currency
                FROM employees
                WHERE name LIKE $myname 
                AND surname LIKE $mysurname
                ";

                command.Parameters.AddWithValue("$myname", $"{name}%");
                command.Parameters.AddWithValue("$mysurname", $"{surname}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee(name: reader.GetString(1), surname: reader.GetString(2), title: reader.GetString(3), privilege: new Privilege(reader.GetString(4)), id: reader.GetInt32(0), country: reader.GetString(5), state: reader.GetString(6), zipcode: reader.GetString(7), city: reader.GetString(8), street: reader.GetString(9), streetnumber: reader.GetString(10), site: getSiteById(reader.GetInt32(11)), department: getDepartmentById(reader.GetInt32(12)), role: getRoleById(reader.GetInt32(13)), salary: new Salary(baseSalary: reader.GetDecimal(14), bonuses: reader.GetDecimal(15), deductions: reader.GetDecimal(16), currency: reader.GetString(17)));
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        public ObservableCollection<Employee> getEmployeesBySiteId(int siteId)
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT employee_id, name, surname, title, privilege, country, state, zipcode, city, street, streetnumber, site_id, department_id, role_id, basesalary, bonus, deduction, currency
                FROM employees
                WHERE site_id = $mysite_id
                ";

                command.Parameters.AddWithValue("$mysite_id", siteId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee(name: reader.GetString(1), surname: reader.GetString(2), title: reader.GetString(3), privilege: new Privilege(reader.GetString(4)), id: reader.GetInt32(0), country: reader.GetString(5), state: reader.GetString(6), zipcode: reader.GetString(7), city: reader.GetString(8), street: reader.GetString(9), streetnumber: reader.GetString(10), site: getSiteById(reader.GetInt32(11)), department: getDepartmentById(reader.GetInt32(12)), role: getRoleById(reader.GetInt32(13)), salary: new Salary(baseSalary: reader.GetDecimal(14), bonuses: reader.GetDecimal(15), deductions: reader.GetDecimal(16), currency: reader.GetString(17)));
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        public ObservableCollection<Employee> getEmployeesByDepartmentId(int departmentId)
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT employee_id, name, surname, title, privilege, country, state, zipcode, city, street, streetnumber, site_id, department_id, role_id, basesalary, bonus, deduction, currency
                FROM employees
                WHERE department_id = $mydepartment_id
                ";

                command.Parameters.AddWithValue("$mydepartment_id", departmentId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee(name: reader.GetString(1), surname: reader.GetString(2), title: reader.GetString(3), privilege: new Privilege(reader.GetString(4)), id: reader.GetInt32(0), country: reader.GetString(5), state: reader.GetString(6), zipcode: reader.GetString(7), city: reader.GetString(8), street: reader.GetString(9), streetnumber: reader.GetString(10), site: getSiteById(reader.GetInt32(11)), department: getDepartmentById(reader.GetInt32(12)), role: getRoleById(reader.GetInt32(13)), salary: new Salary(baseSalary: reader.GetDecimal(14), bonuses: reader.GetDecimal(15), deductions: reader.GetDecimal(16), currency: reader.GetString(17)));
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        public ObservableCollection<Employee> getEmployeesByRoleId(int roleId)
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT employee_id, name, surname, title, privilege, country, state, zipcode, city, street, streetnumber, site_id, department_id, role_id, basesalary, bonus, deduction, currency
                FROM employees
                WHERE role_id = $myrole_id
                ";

                command.Parameters.AddWithValue("$myrole_id", roleId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee(name: reader.GetString(1), surname: reader.GetString(2), title: reader.GetString(3), privilege: new Privilege(reader.GetString(4)), id: reader.GetInt32(0), country: reader.GetString(5), state: reader.GetString(6), zipcode: reader.GetString(7), city: reader.GetString(8), street: reader.GetString(9), streetnumber: reader.GetString(10), site: getSiteById(reader.GetInt32(11)), department: getDepartmentById(reader.GetInt32(12)), role: getRoleById(reader.GetInt32(13)), salary: new Salary(baseSalary: reader.GetDecimal(14), bonuses: reader.GetDecimal(15), deductions: reader.GetDecimal(16), currency: reader.GetString(17)));
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        public User getUser(Employee employee)
        {
            return null;
        }

        public Department getDepartmentById(int id)
        {
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT name, description, accountingunit, department_id
                FROM departments
                WHERE department_id = $myid
                ";

                command.Parameters.AddWithValue("$myid", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Department department = new Department(name: reader.GetString(0), description: reader.GetString(1), accountingUnit: reader.GetString(2), id: reader.GetInt32(3));
                        return department;
                    }
                }
            }
            return null;
        }

        public ObservableCollection<Department> getDepartmentsByName(string name)
        {
            ObservableCollection<Department> departments = new ObservableCollection<Department>();

            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT name, description, accountingunit, department_id
                FROM departments
                WHERE name LIKE $myname
                ";

                command.Parameters.AddWithValue("$myname", $"{name}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Department department = new Department(name: reader.GetString(0), description: reader.GetString(1), accountingUnit: reader.GetString(2), id: reader.GetInt32(3));
                        departments.Add(department);
                    }
                }
            }
            return departments;
        }

        public ObservableCollection<Department> getDepartmentsByAccountingUnit(string accountingunit)
        {
            ObservableCollection<Department> departments = new ObservableCollection<Department>();

            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT name, description, accountingunit, department_id
                FROM departments
                WHERE accountingunit LIKE $myaccountingunit
                ";

                command.Parameters.AddWithValue("$myaccountingunit", $"{accountingunit}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Department department = new Department(name: reader.GetString(0), description: reader.GetString(1), accountingUnit: reader.GetString(2), id: reader.GetInt32(3));
                        departments.Add(department);
                    }
                }
            }
            return departments;
        }

        public Site getSiteById(int id)
        {
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT name, country, state, zipcode, city, street, streetnumber, site_id
                FROM sites
                WHERE site_id = $myid
                ";

                command.Parameters.AddWithValue("$myid", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Site site = new Site(name: reader.GetString(0), country: reader.GetString(1), state: reader.GetString(2), zipcode: reader.GetString(3), city: reader.GetString(4), street: reader.GetString(5), streetnumber: reader.GetString(6), id: reader.GetInt32(7));
                        return site;
                    }
                }
            }
            return null;
        }

        public ObservableCollection<Site> getSitesByName(string name)
        {
            ObservableCollection<Site> sites = new ObservableCollection<Site>();

            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT name, country, state, zipcode, city, street, streetnumber, site_id
                FROM sites
                WHERE name LIKE $myname
                ";

                command.Parameters.AddWithValue("$myname", $"{name}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Site site = new Site(name: reader.GetString(0), country: reader.GetString(1), state: reader.GetString(2), zipcode: reader.GetString(3), city: reader.GetString(4), street: reader.GetString(5), streetnumber: reader.GetString(6), id: reader.GetInt32(7));
                        sites.Add(site);
                    }
                }
            }
            return sites;
        }

        public ObservableCollection<Site> getSitesByCountry(string country)
        {
            ObservableCollection<Site> sites = new ObservableCollection<Site>();

            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT name, country, state, zipcode, city, street, streetnumber, site_id
                FROM sites
                WHERE country LIKE $mycountry
                ";

                command.Parameters.AddWithValue("$mycountry", $"{country}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Site site = new Site(name: reader.GetString(0), country: reader.GetString(1), state: reader.GetString(2), zipcode: reader.GetString(3), city: reader.GetString(4), street: reader.GetString(5), streetnumber: reader.GetString(6), id: reader.GetInt32(7));
                        sites.Add(site);
                    }
                }
            }
            return sites;
        }

        public ObservableCollection<Site> getSitesByState(string state) 
        {
            ObservableCollection<Site> sites = new ObservableCollection<Site>();

            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT name, country, state, zipcode, city, street, streetnumber, site_id
                FROM sites
                WHERE state LIKE $mystate
                ";

                command.Parameters.AddWithValue("$mystate", $"{state}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Site site = new Site(name: reader.GetString(0), country: reader.GetString(1), state: reader.GetString(2), zipcode: reader.GetString(3), city: reader.GetString(4), street: reader.GetString(5), streetnumber: reader.GetString(6), id: reader.GetInt32(7));
                        sites.Add(site);
                    }
                }
            }
            return sites;
        }

        public ObservableCollection<Site> getSitesByZipcode(string zipcode)
        {
            ObservableCollection<Site> sites = new ObservableCollection<Site>();

            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT name, country, state, zipcode, city, street, streetnumber, site_id
                FROM sites
                WHERE zipcode LIKE $myzipcode
                ";

                command.Parameters.AddWithValue("$myzipcode", $"{zipcode}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Site site = new Site(name: reader.GetString(0), country: reader.GetString(1), state: reader.GetString(2), zipcode: reader.GetString(3), city: reader.GetString(4), street: reader.GetString(5), streetnumber: reader.GetString(6), id: reader.GetInt32(7));
                        sites.Add(site);
                    }
                }
            }
            return sites;
        }

        public Role getRoleById(int id)
        {
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT role_id, name, description
                FROM roles
                WHERE role_id = $myid
                ";

                command.Parameters.AddWithValue("$myid", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Role role = new Role(id: reader.GetInt32(0), name: reader.GetString(1), description: reader.GetString(2));
                        return role;
                    }
                }
            }
            return null;
        }

        public ObservableCollection<Role> getRolesByName(string name)
        {
            ObservableCollection<Role> roles = new ObservableCollection<Role>();
            
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT role_id, name, description
                FROM roles
                WHERE name LIKE $myname
                ";

                command.Parameters.AddWithValue("$myname", $"{name}%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Role role = new Role(id: reader.GetInt32(0), name: reader.GetString(1), description: reader.GetString(2));
                        roles.Add(role);
                    }
                }
            }
            return roles;
        }



        public bool addEmployee(Employee employee)
        {
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                INSERT INTO employees (name, surname, title, privilege, country, state, zipcode, city, street, streetnumber, site_id, department_id, role_id, basesalary, bonus, deduction, currency)
                VALUES ($myname, $mysurname, $mytitle, $myprivilege, $mycountry, $mystate, $myzipcode, $mycity, $mystreet, $mystreetnumber, $mysite_id, $mydepartment_id, $myrole_id, $mybasesalary, $mybonus, $mydeduction, $mycurrency)
                ";

                command.Parameters.AddWithValue("$myname", employee.Name);
                command.Parameters.AddWithValue("$mysurname", employee.Surname);
                command.Parameters.AddWithValue("$mytitle", employee.Title);
                command.Parameters.AddWithValue("$myprivilege", employee.Privilege.Name);
                command.Parameters.AddWithValue("$mycountry", employee.Address.Country);
                command.Parameters.AddWithValue("$mystate", employee.Address.State);
                command.Parameters.AddWithValue("$myzipcode", employee.Address.Zipcode);
                command.Parameters.AddWithValue("$mycity", employee.Address.City);
                command.Parameters.AddWithValue("$mystreet", employee.Address.Street);
                command.Parameters.AddWithValue("$mystreetnumber", employee.Address.Number);
                command.Parameters.AddWithValue("$mysite_id", employee.Site.Id);
                command.Parameters.AddWithValue("$mydepartment_id", employee.Department.Id);
                command.Parameters.AddWithValue("$myrole_id", employee.Role.Id);
                command.Parameters.AddWithValue("$mybasesalary", employee.Salary.baseSalary);
                command.Parameters.AddWithValue("$mybonus", employee.Salary.bonuses);
                command.Parameters.AddWithValue("$mydeduction", employee.Salary.deductions);
                command.Parameters.AddWithValue("$mycurrency", employee.Salary.currency);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public bool addUser(User user)
        {
            return false;
        }

        public bool addDepartment(Department department)
        {
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                INSERT INTO departments (name, description, accountingunit)
                VALUES ($myname, $mydescription, $myaccountingunit)
                ";

                command.Parameters.AddWithValue("$myname", department.Name);
                command.Parameters.AddWithValue("$mydescription", department.Description);
                command.Parameters.AddWithValue("$myaccountingunit", department.AccountingUnit);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public bool addSite(Site site)
        {
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                INSERT INTO sites (name, country, state, zipcode, city, street, streetnumber)
                VALUES ($myname, $mycountry, $mystate, $myzipcode, $mycity, $mystreet, $mystreetnumber)
                ";

                command.Parameters.AddWithValue("$myname", site.Name);
                command.Parameters.AddWithValue("$mycountry", site.Address.Country);
                command.Parameters.AddWithValue("$mystate", site.Address.State);
                command.Parameters.AddWithValue("$myzipcode", site.Address.Zipcode);
                command.Parameters.AddWithValue("$mycity", site.Address.City);
                command.Parameters.AddWithValue("$mystreet", site.Address.Street);
                command.Parameters.AddWithValue("$mystreetnumber", site.Address.Number);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public bool addRole(Role role)
        {
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                INSERT INTO roles (name, description)
                VALUES ($myname, $mydescription)
                ";

                command.Parameters.AddWithValue("$myname", role.Name);
                command.Parameters.AddWithValue("$mydescription", role.Description);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }



        public bool updateEmployee(Employee employee)
        {
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                UPDATE employees
                SET name = $myname,
                surname = $mysurname,
                title = $mytitle,
                privilege = $myprivilege,
                country = $mycountry,
                state = $mystate,
                zipcode = $myzipcode,
                city = $mycity,
                street = $mystreet,
                streetnumber = $mystreetnumber,
                site_id = $mysite_id,
                department_id = $mydepartment_id,
                role_id = $myrole_id,
                basesalary = $mybasesalary,
                bonus = $mybonus,
                deduction = $mydeduction,
                currency = $mycurrency
                WHERE employee_id = $myemployee_id
                ";

                command.Parameters.AddWithValue("$myname", employee.Name);
                command.Parameters.AddWithValue("$mysurname", employee.Surname);
                command.Parameters.AddWithValue("$mytitle", employee.Title);
                command.Parameters.AddWithValue("$myprivilege", employee.Privilege.Name);
                command.Parameters.AddWithValue("$mycountry", employee.Address.Country);
                command.Parameters.AddWithValue("$mystate", employee.Address.State);
                command.Parameters.AddWithValue("$myzipcode", employee.Address.Zipcode);
                command.Parameters.AddWithValue("$mycity", employee.Address.City);
                command.Parameters.AddWithValue("$mystreet", employee.Address.Street);
                command.Parameters.AddWithValue("$mystreetnumber", employee.Address.Number);
                command.Parameters.AddWithValue("$mysite_id", employee.Site.Id);
                command.Parameters.AddWithValue("$mydepartment_id", employee.Department.Id);
                command.Parameters.AddWithValue("$myrole_id", employee.Role.Id);
                command.Parameters.AddWithValue("$mybasesalary", employee.Salary.baseSalary);
                command.Parameters.AddWithValue("$mybonus", employee.Salary.bonuses);
                command.Parameters.AddWithValue("$mydeduction", employee.Salary.deductions);
                command.Parameters.AddWithValue("$mycurrency", employee.Salary.currency);
                command.Parameters.AddWithValue("$myemployee_id", employee.Id);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public bool updateUser(User user) 
        { 
            return false; 
        }

        public bool updateDepartment(Department department)
        {
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                UPDATE departments
                SET name = $myname,
                description = $mydescription,
                accountingunit = $myaccountingunit
                WHERE department_id = $mydepartment_id
                ";

                command.Parameters.AddWithValue("$myname", department.Name);
                command.Parameters.AddWithValue("$mydescription", department.Description);
                command.Parameters.AddWithValue("$myaccountingunit", department.AccountingUnit);
                command.Parameters.AddWithValue("$mydepartment_id", department.Id);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public bool updateSite(Site site)
        {
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                UPDATE sites
                SET name = $myname,
                country = $mycountry,
                state  = $mystate,
                zipcode = $myzipcode,
                city = $mycity,
                street = $mystreet,
                streetnumber = $mystreetnumber
                WHERE site_id = $mysite_id
                ";

                command.Parameters.AddWithValue("$myname", site.Name);
                command.Parameters.AddWithValue("$mycountry", site.Address.Country);
                command.Parameters.AddWithValue("$mystate", site.Address.State);
                command.Parameters.AddWithValue("$myzipcode", site.Address.Zipcode);
                command.Parameters.AddWithValue("$mycity", site.Address.City);
                command.Parameters.AddWithValue("$mystreet", site.Address.Street);
                command.Parameters.AddWithValue("$mystreetnumber", site.Address.Number);
                command.Parameters.AddWithValue("$mysite_id", site.Id);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public bool updateRole(Role role)
        {
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                UPDATE roles
                SET name = $myname,
                description = $mydescription
                WHERE role_id = $myrole_id
                ";

                command.Parameters.AddWithValue("$myname", role.Name);
                command.Parameters.AddWithValue("$mydescription", role.Description);
                command.Parameters.AddWithValue("$myrole_id", role.Id);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        

        public bool deleteEmployee(Employee employee)
        {
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                DELETE FROM employees
                WHERE employee_id = $myemployee_id
                ";
                command.Parameters.AddWithValue("$myemployee_id", employee.Id);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public bool deleteUser(User user)
        {
            return false;
        }

        public bool deleteDepartment(Department department)
        {
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                DELETE FROM departments
                WHERE department_id = $mydepartment_id
                ";
                command.Parameters.AddWithValue("$mydepartment_id", department.Id);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public bool deleteSite(Site site)
        {
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                DELETE FROM sites
                WHERE site_id = $mysite_id
                ";
                command.Parameters.AddWithValue("$mysite_id", site.Id);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }

        public bool deleteRole(Role role)
        {
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                DELETE FROM roles
                WHERE role_id = $myrole_id
                ";

                command.Parameters.AddWithValue("$myrole_id", role.Id);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
                return true;
            }
        }
    }
}
