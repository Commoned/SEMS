using SEMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Application
{
    internal class RoleManagement
    {
        DataHandler dataHandler;
         public RoleManagement(DataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }

        public Role newRole()
        {
            UserEntry userEntry = new ConsoleEntry();
            IdentificationProvider identificationProvider = new Identification();
            Console.WriteLine("Name:");
            var name = userEntry.acceptEntry();
            Console.WriteLine("Description:");
            var description = userEntry.acceptEntry();
            var id = identificationProvider.provideId();

            return new Role(name, description, id);
        }
    }
}
