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

namespace SEMS.Application
{
    internal static class DepartmentManagement
    {
        static DataHandler dataHandler = new Database();
        public static bool newDepartment(string name, string descr, string accountingUnit)
        {
            Debug.Write("Creating Dept");
            Department newDept = new Department(name,descr,accountingUnit);
            dataHandler.addDepartment(newDept);
            return true;
        }
        public static bool updateDepartment(Department updateDept)
        {
            dataHandler.updateDepartment(updateDept);

            return true;
        }
        public static bool deleteDepartment(Department deleteDept)
        {
            return dataHandler.deleteDepartment(deleteDept);
        }
    }
}
