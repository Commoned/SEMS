// See https://aka.ms/new-console-template for more information
using SEMS.Adapter;
using SEMS.Application;
using SEMS.Domain;

ObjectData data = new ObjectData();
UserEntry userEntry = new ConsoleEntry();

EmployeeManagement employeeHandler = new EmployeeManagement(data);
SiteManagement siteHandler = new SiteManagement(data);



    

data.addCountry(new Country("Germany","EUR","Europe"));
data.addSite(siteHandler.newSite());
data.addDepartment(new Department("KDSCDC", "IT-Security", "0641"));
data.addRole(new Role("Cyber Defense Engineer", "IT Engineer for Cyber Security", 10));


data.addEmployee(employeeHandler.newEmployee());
Console.WriteLine("DONE!");