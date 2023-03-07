using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Application
{
    internal class Identification : IdentificationProvider
    {

        public Identification() 
        { 

        }
        public int provideId()
        {
            return 0;
        }

        public string provideNonNumericId()
        {
            // To Be Continued
            return "Test";
        }

        public bool Validate(string username, string password)
        {
            return true;
        }

    }
}
