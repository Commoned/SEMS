using SEMS.Application;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using SEMS.Domain;

namespace SEMS.Adapter.UI
{
    /// <summary>
    /// Interaktionslogik für DepartmentPage.xaml
    /// </summary>
    public partial class DepartmentPage : UserControl
    {
        public DepartmentPage()
        {
            InitializeComponent();
            this.DataContext = (object)Cache.Instance;
        }

        private void searchData(object sender, RoutedEventArgs e)
        {
            Cache cache = Cache.Instance;
            Debug.WriteLine(cache.EmployeeCache);
        }
        private void employeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Site selectedEmployee = (Site)employeeList.SelectedItem;
            // TODO Updateing view
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Site selectedEmployee = (Site)employeeList.SelectedItem;
            // TODO Updateing view
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            Site selectedEmployee = (Site)employeeList.SelectedItem;
            // TODO Updateing view
        }
    }
}
