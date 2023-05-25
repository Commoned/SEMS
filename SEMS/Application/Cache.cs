using SEMS.Domain;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SEMS.Application
{
    public sealed class Cache : INotifyPropertyChanged
    {
        private readonly DataHandler database;

        public Cache(DataHandler dataHandler)
        {
            database = dataHandler;
        }
        
        public ObservableCollection<Employee> EmployeeCache {
            get 
            {
                return getPlaceholderEmployees();
            }
            private set { }
        }
        
        public ObservableCollection<Employee> getPlaceholderEmployees()
        {
            return database.getEmployeesByName("");
        }

        public ObservableCollection<Department> DeptCache { 
            get
            {
                
                return getPlaceholderDepartments();
            }
            private set { }
        }

        public ObservableCollection<Department> getPlaceholderDepartments()
        {
            return database.getDepartmentsByName("");
        }

        public ObservableCollection<Site> SiteCache {
            get
            { 
                return getPlaceholderSites();
            }
            private set { }
        }
        public ObservableCollection<Site> getPlaceholderSites()
        {
            return database.getSitesByName("");
        }

        public ObservableCollection<Role> RoleCache {
            get
            {
                return getPlaceholderRoles();
            }
            private set { }
        }

        public ObservableCollection<Role> getPlaceholderRoles()
        {
            return database.getRolesByName("");
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
