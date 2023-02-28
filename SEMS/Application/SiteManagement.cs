using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using SEMS.Adapter;
using SEMS.Domain;

namespace SEMS.Application
{
    internal class SiteManagement
    {
        DataHandler dataHandler;

        public SiteManagement(DataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }

        public Domain.Site newSite()
        {
            UserEntry userEntry = new ConsoleEntry();
            Console.WriteLine("Name:");
            string name = userEntry.acceptEntry();
            Console.WriteLine("Country:");

            Console.WriteLine("stateProvince:");
            string stateProvince = userEntry.acceptEntry();
            Console.WriteLine("zipcode:");
            string zipcode = userEntry.acceptEntry();
            Console.WriteLine("City:");
            string city = userEntry.acceptEntry();
            Console.WriteLine("Street:");
            string street = userEntry.acceptEntry();
            Console.WriteLine("Streetnumber:");
            string streetnumber = userEntry.acceptEntry();

            return new Domain.Site(name, stateProvince, zipcode, city, street, streetnumber);
        }
    }
}
