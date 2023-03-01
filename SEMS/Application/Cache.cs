using SEMS.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMS.Application
{
    public sealed class Cache
    {
        private static readonly Lazy<Cache> lazy =
            new Lazy<Cache>(() => new Cache());

        

        public static Cache Instance { get { return lazy.Value; } }

        private Cache()
        {
            EmployeeCache = new ObservableCollection<Employee>();
        }

        public ObservableCollection<Employee> EmployeeCache { get; private set; }
        


    }
}
