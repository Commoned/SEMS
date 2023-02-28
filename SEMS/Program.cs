using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SEMS.Adapter;
using SEMS.Application;
using SEMS.Domain;


namespace SEMS
{
   
    public class Program
    {

        [STAThread]
        static public void Main(String[] args)
        {
            GuiAdapter page = new MainPage();
            EmployeeManagement.newEmployee();
            page.invokeGUI();
           
            /*

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
            */
        }
    }
}
