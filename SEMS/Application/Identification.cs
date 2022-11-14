using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Application
{
    internal class Identification : IdentificationProvider
    {
        public int provideId()
        {
            return 0;
        }

        public string provideNonNumericId()
        {
            // To Be Continued
            return "Test";
        }

    }
}
