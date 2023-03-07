using SEMS.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEMS.Adapter;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SEMS.Application
{
    public sealed class Cache : INotifyPropertyChanged
    {
        private static readonly Lazy<Cache> lazy =
            new Lazy<Cache>(() => new Cache());

        

        public static Cache Instance { get { return lazy.Value; } }
        private static DataHandler database = new Database();



        private Cache()
        {
            EmployeeCache = database.getEmployeesByName("");
            DeptCache = database.getDepartmentsByName("");
            RoleCache = database.getRolesByName("");
            SiteCache = database.getSitesByName("");
        }

        public ObservableCollection<Employee> EmployeeCache { get; private set; }
        public ObservableCollection<Department> DeptCache { get; private set; }
        public ObservableCollection<Site> SiteCache { get; private set; }
        public ObservableCollection<Role> RoleCache { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void update()
        {
            EmployeeCache = database.getEmployeesByName("");
            DeptCache = database.getDepartmentsByName("");
            RoleCache = database.getRolesByName("");
            SiteCache = database.getSitesByName("");
        }
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }


    }
}
