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
        DatabaseFacade facade;
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
