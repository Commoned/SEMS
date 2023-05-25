using System;
using SEMS.Domain;
using System.Diagnostics;
using SEMS.Adapter.Database;

namespace SEMS.Application
{
    internal static class RoleManagement
    {
        static RoleHandler dataHandler = new DatabaseFacade();
       

        public static bool newRole(string name, string descr)
        {
            Debug.Write("Creating Dept");
            Role newRole = new Role(name, descr);
            return dataHandler.addRole(newRole);
        }

        public static bool updateRole(Role updateRole)
        {
            return dataHandler.updateRole(updateRole);
        }

        public static bool deleteRole(Role deleteRole)
        {

            if (dataHandler.getEmployeesByRoleId(deleteRole.Id).Count != 0)
            {
                throw new Exception("There are Employees tied to this Role");
            }
            return dataHandler.deleteRole(deleteRole);
        }
    }
}
