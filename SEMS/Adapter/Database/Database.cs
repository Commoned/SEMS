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
    public class DatabaseFacade : DataHandler
    {
        private string dblocation = "Data Source = ..\\..\\..\\Adapter\\Database\\sems.sqlite";
        public DatabaseFacade()
        {
            dblocation = "Data Source = " + dblocation;
        }


    }
}
