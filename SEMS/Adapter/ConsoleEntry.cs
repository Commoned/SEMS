using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Application
{
    internal class ConsoleEntry : UserEntry
    {
        

        public string acceptEntry()
        {
            return Console.ReadLine();
        }
    }
}
