﻿using System;
using SEMS.Adapter.Database;
using SEMS.Domain;

namespace SEMS.Application
{
    internal static class SiteManagement
    {
        static SiteHandler dataHandler = new DatabaseFacade();


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
