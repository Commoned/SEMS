// See https://aka.ms/new-console-template for more information
using SEMS.Application;
using SEMS.Domain;

EmployeeHandler handler = new EmployeeHandler();
handler.createCountry("Germany","EUR","Europe");
handler.createSite("Test","Germany","test","test","test","test","test");
handler.createRole("Test", "Test");
//handler.createDepartment("");

handler.createEmployee("Tim Daniel", "Friedrich", "", )