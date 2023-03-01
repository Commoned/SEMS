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
        

        public EmployeePage()
        {
            InitializeComponent();
            string test = "test";
            this.DataContext = (object)Cache.Instance;
        }
       
        
        private void searchData(object sender, RoutedEventArgs e)
        {
            Cache cache = Cache.Instance;
            Debug.WriteLine(cache.EmployeeCache);
        }
        
       


        private void employeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Employee test = (Employee)employeeList.SelectedItem;
            boxName.Text = test.Name;
            //boxStateProvince.Text = test.Address.StateProvince;
            boxZipcode.Text = test.Address.Zipcode;
            boxCity.Text = test.Address.City;
            boxStreet.Text = test.Address.Street;
            boxSurname.Text = test.Surname;
            boxStreetNumber.Text = test.Address.Number;
            boxRole.Text = test.Role.Name;
            boxDepartment.Text = test.Department.Name;
            boxSalBonus.Text = "0";
            boxCurrency.Text = test.Salary.currency;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = (Employee)employeeList.SelectedItem;
            //selectedEmployee.Address.StateProvince = boxStateProvince.Text;
            selectedEmployee.Address.City = boxCity.Text;
            selectedEmployee.Address.Street = boxStreet.Text;
            selectedEmployee.Address.Zipcode = boxZipcode.Text;
            selectedEmployee.Address.Number = boxStreetNumber.Text;
            // TODO Updateing view
        }
    }
}
