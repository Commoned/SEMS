﻿using System;
using System.Collections.Generic;
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

    public interface DataHandler
    {
        Privilege getPrivilegeByName(string name);
        Employee getEmployeeById(int id);
        User getUser(Employee employee);
        Department getDepartmentById(int id);
        Domain.Site getSiteById(int id);
        Role getRoleById(int id);

        void addPrivilege(Privilege privilege);

        void addDepartment(Department department);

        void addEmployee(Employee employee);

        void addUser(User user);

        void addRole(Role role);

        void addSite(Domain.Site site);


    }
    internal static class EmployeeManagement
    {
        static DataHandler dataHandler = new Database();

        /*public EmployeeManagement(DataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        */
        public static Employee newEmployee()
        {
            //dataHandler.getEmployee("TEST");
            dataHandler.getEmployeeById(1);
            //dataHandler.getDepartmentById(1);
            //dataHandler.getSiteById(1);
            //dataHandler.getRoleById(1);

            /*
            Console.WriteLine("DIESE IST KAKA");
            UserEntry userEntry = new ConsoleEntry();
            IdentificationProvider identificationProvider = new Identification();
            Console.WriteLine("Name:");
            string name = userEntry.acceptEntry();
            Console.WriteLine("Surname:");
            string surname = userEntry.acceptEntry();
            Console.WriteLine("Title:");
            string title = userEntry.acceptEntry();
            int id = identificationProvider.provideId();


            Console.WriteLine("country:");
            string country = userEntry.acceptEntry();
            Console.WriteLine("state:");
            string state = userEntry.acceptEntry();
            Console.WriteLine("Zip:");
            string zipcode = userEntry.acceptEntry();
            Console.WriteLine("City:");
            string city = userEntry.acceptEntry();
            Console.WriteLine("Street:");
            string street = userEntry.acceptEntry();
            Console.WriteLine("Streetnumber:");
            string streetnumber = userEntry.acceptEntry();
            Console.WriteLine("Site:");
            Domain.Site site = dataHandler.getSite(userEntry.acceptEntry());
            Console.WriteLine("Department:");
            Department department = dataHandler.getDepartment(userEntry.acceptEntry());
            Console.WriteLine("Role:");
            Role role = dataHandler.getRole(userEntry.acceptEntry());
            Console.WriteLine("Salary in EUR/cent:");
            Salary salaryAmount = new Salary(decimal.Parse(userEntry.acceptEntry()), decimal.Parse(userEntry.acceptEntry()), decimal.Parse(userEntry.acceptEntry()), userEntry.acceptEntry());
            DateTime employedSince = DateTime.UtcNow;
            Console.WriteLine("Employment Until:");
            DateTime employedUntil = DateTime.Parse(userEntry.acceptEntry());
            */
            //return new Employee(name, surname, title, id, country, state, zipcode, city, street, streetnumber, site, department, role, salaryAmount, employedSince, employedUntil);
            return null;
        }



    }
}

