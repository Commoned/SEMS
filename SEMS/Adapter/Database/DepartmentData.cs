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
    public class DepartmentData : DepartmentHandler
    {
        private DatabaseFacade facade;
        private string dblocation;
        public DepartmentData(string dblocation, DatabaseFacade facade)
        {
            this.dblocation = dblocation;
            this.facade = facade;
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
                        Employee employee = new Employee(name: reader.GetString(1), surname: reader.GetString(2), title: reader.GetString(3), privilege: new Privilege(reader.GetString(4)), id: reader.GetInt32(0), country: reader.GetString(5), state: reader.GetString(6), zipcode: reader.GetString(7), city: reader.GetString(8), street: reader.GetString(9), streetnumber: reader.GetString(10), site: facade.getSiteById(reader.GetInt32(11)), department: facade.getDepartmentById(reader.GetInt32(12)), role: facade.getRoleById(reader.GetInt32(13)), salary: new Salary(baseSalary: reader.GetDecimal(14), bonuses: reader.GetDecimal(15), deductions: reader.GetDecimal(16), currency: reader.GetString(17)));
                        employees.Add(employee);
                    }
                }
            }
            return employees;
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
    }
}
