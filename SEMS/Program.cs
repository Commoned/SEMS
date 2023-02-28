// See https://aka.ms/new-console-template for more information
using SEMS.Adapter;
using SEMS.Application;
using SEMS.Domain;

DataHandler data = new ObjectData();

EmployeeManagement employeeHandler = new EmployeeManagement(data);
SiteManagement siteHandler = new SiteManagement(data);
DepartmentManagement departmentHandler = new DepartmentManagement(data);
RoleManagement roleHandler = new RoleManagement(data);


    


data.addSite(siteHandler.newSite());
data.addDepartment(departmentHandler.newDepartment());
data.addRole(roleHandler.newRole());


data.addEmployee(employeeHandler.newEmployee());
Console.WriteLine("DONE!");