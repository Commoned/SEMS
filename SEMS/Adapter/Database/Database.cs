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
                SELECT employee_id, name, surname, title, privilege, state, province, zipcode, city, street, streetnumber, site_id, department_id, role_id, basesalary, bonus, deduction, currency
                FROM employees
                WHERE employee_id = $myprivilege
                ";

                command.Parameters.AddWithValue("$myprivilege", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee(name: reader.GetString(1), surname: reader.GetString(2), title: reader.GetString(3), privilege: new Privilege(reader.GetString(4)), id: reader.GetInt32(0), stateProvince: reader.GetString(5), zipcode: reader.GetString(7), city: reader.GetString(8), street: reader.GetString(9), streetnumber: reader.GetString(10), site: getSiteById(reader.GetInt32(11)), department: getDepartmentById(reader.GetInt32(12)), role: getRoleById(reader.GetInt32(13)), salary: new Salary(baseSalary: reader.GetDecimal(14), bonuses: reader.GetDecimal(15), deductions: reader.GetDecimal(16), currency: reader.GetString(17)));
                        //privilege.Name = reader.GetString(0);
                        Console.WriteLine(employee.Surname);
                        return employee;
                    }
                }
            }
            return null;
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
                SELECT name, description, accountingunit
                FROM departments
                WHERE department_id = $myid
                ";

                command.Parameters.AddWithValue("$myid", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Department department = new Department(name: reader.GetString(0), description: reader.GetString(1), accountingUnit: reader.GetString(2));
                        return department;
                    }
                }
            }
            return null;
        }

        public Site getSiteById(int id)
        {
            using (var connection = new SqliteConnection(dblocation))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                SELECT name, state, province, zipcode, city, street, streetnumber
                FROM sites
                WHERE site_id = $myid
                ";

                command.Parameters.AddWithValue("$myid", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Site site = new Site(name: reader.GetString(0), stateProvince: reader.GetString(1), zipcode: reader.GetString(3), city: reader.GetString(4), street: reader.GetString(5), streetnumber: reader.GetString(6));
                        return site;
                    }
                }
            }
            return null;
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

        public void addPrivilege(Privilege privilege)
        {
            return;
        }

        public void addDepartment(Department department)
        {
            return;
        }

        public void addEmployee(Employee employee)
        {
            return;
        }

        public void addUser(User user)
        {
            return;
        }

        public void addRole(Role role)
        {
            return;
        }

        public void addSite(Site site)
        {
            return;
        }
    }
}
