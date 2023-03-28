using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEMS.Domain;
using SEMS.Adapter;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Collections.ObjectModel;

namespace SEMS.Application
{
    public class DepartmentManagement
    {
        DataHandler dataHandler;
        
        public DepartmentManagement(DataHandler dataInterface)
        {
            dataHandler = dataInterface;
        }

        public ObservableCollection<Department> GetDepartments(string name)
        {
            return dataHandler.getDepartmentsByName(name);
        }

        public bool newDepartment(string name, string descr, string accountingUnit)
        {
            Debug.Write("Creating Dept");
            Department newDept = new Department(name,descr,accountingUnit);
            dataHandler.addDepartment(newDept);
            return true;
        }
        public bool updateDepartment(Department updateDept)
        {
            dataHandler.updateDepartment(updateDept);

            return true;
        }
        public bool deleteDepartment(Department deleteDept)
        {
            
            if(dataHandler.getEmployeesByDepartmentId(deleteDept.Id).Count != 0)
            {
                throw new Exception("There are Employees tied to this Department");
            }
            return dataHandler.deleteDepartment(deleteDept);
        }
    }
}
