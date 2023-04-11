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
    public class RoleData : Database,RoleHandler
    {
        public RoleData(string dblocation) : base(dblocation) { }

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
