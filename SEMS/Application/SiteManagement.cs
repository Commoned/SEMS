using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEMS.Adapter;
using SEMS.Domain;
using SQLitePCL;

namespace SEMS.Application
{
    internal static class SiteManagement
    {
        static DataHandler dataHandler = new Database();


        public static bool newSite(string name, string country, string state,string zipcode,string city, string street, string streetnumber)
        {
            return dataHandler.addSite(new Site(name, country, state, zipcode, city, street, streetnumber));
        }

        public static bool updateSite(Site updateSite)
        {
            return dataHandler.updateSite(updateSite);
        }

        public static bool deleteSite(Site deleteSite)
        {
            if (dataHandler.getEmployeesBySiteId(deleteSite.Id).Count != 0)
            {
                throw new Exception("There are Employees tied to this Site");
            }
            return dataHandler.deleteSite(deleteSite);
        }
    }
}
