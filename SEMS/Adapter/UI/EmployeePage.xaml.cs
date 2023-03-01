using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Collections.ObjectModel;
using System.Diagnostics;
using SEMS.Domain;
using System.Runtime.CompilerServices;
using SEMS.Application;
using System.Security.Cryptography;

namespace SEMS.Adapter.UI
{
    /// <summary>
    /// Interaktionslogik für EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : UserControl
    {
        

        public EmployeePage(string type)
        {
            InitializeComponent();
            Grid contentGrid = (Grid)this.FindName(type);
            contentGrid.Visibility = Visibility.Visible;

            Cache.Instance.EmployeeCache.Add(new Address("BaWü","76227","Karlsruhe","Max-Beckmannstr","43"));
            Cache.Instance.EmployeeCache.Add(new Address("BaWü", "76227", "Karlsruhe", "Max-Beckmannstr", "43"));
            Cache.Instance.EmployeeCache.Add(new Address("BaWü", "76227", "Karlsruhe", "Max-Beckmannstr", "43"));
            Cache.Instance.EmployeeCache.Add(new Address("BaWü", "76227", "Karlsruhe", "Max-Beckmannstr", "43"));
            Cache.Instance.EmployeeCache.Add(new Address("BaWü", "76227", "Karlsruhe", "Max-Beckmannstr", "43"));

            this.DataContext = (object)Cache.Instance;
            
        }
       
        
        private void searchData(object sender, RoutedEventArgs e)
        {
            Cache cache = Cache.Instance;
            Debug.WriteLine(cache.EmployeeCache);
        }
        

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            Thread.CurrentThread.Abort();
        }
       


        private void employeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Address test = (Address)employeeList.SelectedItem;
            boxStateProvince.Text = test.StateProvince;
            boxZipcode.Text = test.Zipcode;
            boxCity.Text = test.City;
            boxStreet.Text = test.Street;
            boxStreetnumber.Text = test.Number;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Address selectedEmployee = (Address)employeeList.SelectedItem;
            selectedEmployee.StateProvince = boxStateProvince.Text;
            selectedEmployee.City = boxCity.Text;
            selectedEmployee.Street = boxStreet.Text;
            selectedEmployee.Zipcode = boxZipcode.Text;
            selectedEmployee.Number = boxStreetnumber.Text;
            // TODO Updateing view
        }
    }
}
