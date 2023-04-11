using SEMS.Domain;
using SEMS.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.IO;
using System.Collections.ObjectModel;

namespace SEMS.Adapter.Database
{
    public class Database
    {
        protected string dblocation = "Data Source = ..\\..\\..\\Adapter\\Database\\sems.sqlite";
        public Database(string dblocation)
        {
            dblocation = "Data Source = " + dblocation;
        }


    }
}
