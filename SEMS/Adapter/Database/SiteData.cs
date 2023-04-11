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
    internal class SiteData : SiteHandler
    {
        DatabaseFacade facade;
        private string dblocation;
        public SiteData(string dblocation, DatabaseFacade facade)
        {
            this.dblocation = dblocation;
            this.facade = facade;
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
                        Employee employee = new Employee(name: reader.GetString(1), surname: reader.GetString(2), title: reader.GetString(3), privilege: new Privilege(reader.GetString(4)), id: reader.GetInt32(0), country: reader.GetString(5), state: reader.GetString(6), zipcode: reader.GetString(7), city: reader.GetString(8), street: reader.GetString(9), streetnumber: reader.GetString(10), site: getSiteById(reader.GetInt32(11)), department: facade.getDepartmentById(reader.GetInt32(12)), role:   facade.getRoleById(reader.GetInt32(13)), salary: new Salary(baseSalary: reader.GetDecimal(14), bonuses: reader.GetDecimal(15), deductions: reader.GetDecimal(16), currency: reader.GetString(17)));
                        employees.Add(employee);
                    }
                }
            }
            return employees;
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

    }
}
