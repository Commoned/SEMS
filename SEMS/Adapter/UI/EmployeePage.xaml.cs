﻿using System;
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
using System.Windows.Controls.Primitives;

namespace SEMS.Adapter.UI
{
    /// <summary>
    /// Interaktionslogik für EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : UserControl
    {
        DataHandler dataHandler = new Database();

        public EmployeePage()
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
            Employee selectedEmp = (Employee)employeeList.SelectedItem;
            editWindow.DataContext = selectedEmp;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
            Employee selectedEmployee = (Employee)employeeList.SelectedItem;
            
            if (selectedEmployee!=null)
            {
                var test = dataHandler.getSitesByName(cmbSite.Text).ElementAt(0);
                dataHandler.addEmployee(new Employee(
                    boxName.Text,
                    boxSurname.Text,
                    boxTitle.Text,
                    dataHandler.getPrivilegeByName(boxPrivilege.Text),
                    boxCountry.Text,
                    boxStateProvince.Text,
                    boxZipcode.Text,
                    boxCity.Text, boxStreet.Text, boxStreetNumber.Text,
                    dataHandler.getSitesByName(cmbSite.Text).ElementAt(0),
                    dataHandler.getDepartmentsByName(cmbDepartment.Text).ElementAt(0) ,
                    dataHandler.getRolesByName(cmbRole.Text).ElementAt(0),
                    new Salary(decimal.Parse(boxSalary.Text),0,0,boxCurrency.Text)
                    ));
            }
            Cache cache = Cache.Instance;
            cache.update();
            cache.NotifyPropertyChanged("EmployeeCache");
        }
        
        private void cmbSite_TextChanged(object sender, EventArgs e)
        {
            cmbSite.ItemsSource = dataHandler.getSitesByName("");
            
        }
        private void cmbDept_TextChanged(object sender, EventArgs e)
        {
            cmbDepartment.ItemsSource = dataHandler.getDepartmentsByName("");

        }

        private void cmbRole_TextChanged(object sender, EventArgs e)
        {
            cmbRole.ItemsSource = dataHandler.getRolesByName("");
        }

        private void newEmployee_Click(object sender, RoutedEventArgs e)
        {
            employeeList.SelectedItem = null;
            Save_Click(sender, e);
        }

        private void deleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}