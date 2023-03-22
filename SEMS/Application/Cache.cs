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

        private static readonly DataHandler database = new Database();

        private Cache()
        {
        }
        
        public ObservableCollection<Employee> EmployeeCache {
            get 
            {
                ObservableCollection<Employee> placeholder = database.getEmployeesByName("");
                return placeholder;
            }
            private set { }
        }
        public ObservableCollection<Department> DeptCache { 
            get
            {
                ObservableCollection<Department> placeholder = database.getDepartmentsByName("");
                return placeholder;
            }
            private set { }
        }
        public ObservableCollection<Site> SiteCache {
            get
            {
                ObservableCollection<Site> placeholder = database.getSitesByName("");
                return placeholder;
            }
            private set { }
        }
        
        public ObservableCollection<Role> RoleCache {
            get
            {
                
                ObservableCollection<Role> placeholder = database.getRolesByName("");
                return placeholder;
            }
            private set { }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void Update()
        {
            NotifyPropertyChanged("EmployeeCache");
            NotifyPropertyChanged("DeptCache");
            NotifyPropertyChanged("RoleCache");
            NotifyPropertyChanged("SiteCache");
        }

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

    }
}
