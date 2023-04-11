using Microsoft.Data.Sqlite;
using SEMS.Application;
using SEMS.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Adapter.Database
{
    internal class RoleData : RoleHandler
    {
        private string dblocation;
        DatabaseFacade facade;
        public RoleData(string dblocation, DatabaseFacade facade)
        {
            this.dblocation = dblocation;
            this.facade = facade;
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
                        Employee employee = new Employee(name: reader.GetString(1), surname: reader.GetString(2), title: reader.GetString(3), privilege: new Privilege(reader.GetString(4)), id: reader.GetInt32(0), country: reader.GetString(5), state: reader.GetString(6), zipcode: reader.GetString(7), city: reader.GetString(8), street: reader.GetString(9), streetnumber: reader.GetString(10), site: facade.getSiteById(reader.GetInt32(11)), department: facade.getDepartmentById(reader.GetInt32(12)), role: getRoleById(reader.GetInt32(13)), salary: new Salary(baseSalary: reader.GetDecimal(14), bonuses: reader.GetDecimal(15), deductions: reader.GetDecimal(16), currency: reader.GetString(17)));
                        employees.Add(employee);
                    }
                }
            }
            return employees;
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
