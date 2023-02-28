using SEMS.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Adapter
{
    internal class ConsoleEntry : UserEntry
    {
        public string acceptEntry()
        {

            return Console.ReadLine();
        }
    }
}
