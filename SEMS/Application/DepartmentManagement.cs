using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEMS.Domain;
using SEMS.Adapter;

namespace SEMS.Application
{
    internal class DepartmentManagement
    {
        DataHandler dataHandler;

        public DepartmentManagement(DataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }

        public Department newDepartment()
        {
            UserEntry userEntry = new ConsoleEntry();
            Console.WriteLine("Name:");
            var name = userEntry.acceptEntry();
            Console.WriteLine("Description:");
            var description = userEntry.acceptEntry();
            Console.WriteLine("Accounting Unit:");
            var accountingUnit = userEntry.acceptEntry();

            return new Department(name, description, accountingUnit);
        }
    }
}
