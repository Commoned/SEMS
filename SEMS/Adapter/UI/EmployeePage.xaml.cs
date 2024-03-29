﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.ObjectModel;
using SEMS.Domain;
using SEMS.Application;
using SEMS.Adapter.Database;

namespace SEMS.Adapter.UI
{
    /// <summary>
    /// Interaktionslogik für EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : UserControl
    {
        DataHandler dataHandler = new DatabaseFacade();
        EmployeeManagement employeeManagement;
        Cache cache;

        public EmployeePage(EmployeeManagement employeeManagement, Cache cache)
        {
            InitializeComponent();
            this.DataContext = cache;
            this.employeeManagement = employeeManagement;
            this.cache = cache;
        }
       
        
        private void searchData(object sender, RoutedEventArgs e)
        { 
        }
        
        private void employeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Employee selectedEmp = (Employee)employeeList.SelectedItem;
            editWindow.DataContext = selectedEmp;
            

        }

        private void cmbSite_DropDownOpened(object sender, EventArgs e)
        {
            cmbSite.ItemsSource = dataHandler.getSitesByName("");
            
        }
        private void cmbDept_DropDownOpened(object sender, EventArgs e)
        {
            cmbDepartment.ItemsSource = dataHandler.getDepartmentsByName("");

        }

        private void cmbRole_DropDownOpened(object sender, EventArgs e)
        {
            cmbRole.ItemsSource = dataHandler.getRolesByName("");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
            

            Employee selectedEmployee = (Employee)employeeList.SelectedItem;
            selectedEmployee.Name = boxName.Text;
            selectedEmployee.Surname= boxSurname.Text;
            selectedEmployee.Title = boxTitle.Text;
            selectedEmployee.Privilege = dataHandler.getPrivilegeByName(boxPrivilege.Text);

            selectedEmployee.Address.Country = boxCountry.Text;
            selectedEmployee.Address.State = boxStateProvince.Text;
            selectedEmployee.Address.Zipcode = boxZipcode.Text;
            selectedEmployee.Address.City = boxCity.Text;
            selectedEmployee.Address.Street = boxStreet.Text;
            selectedEmployee.Address.Number = boxStreetNumber.Text;

            selectedEmployee.Site = dataHandler.getSitesByName(cmbSite.Text).ElementAt(0);
            selectedEmployee.Department = dataHandler.getDepartmentsByName(cmbDepartment.Text).ElementAt(0);
            selectedEmployee.Role = dataHandler.getRolesByName(cmbRole.Text).ElementAt(0);
            new Salary(decimal.Parse(boxSalary.Text), 0, 0, boxCurrency.Text);
            employeeManagement.updateEmployee(selectedEmployee);
            cache.Update();
            cache.NotifyPropertyChanged("EmployeeCache");
        }

        private void newEmployee_Click(object sender, RoutedEventArgs e)
        {
            Collection<object> pushColl = new Collection<object>();
            employeeManagement.newEmployee(
                boxName.Text,
                boxSurname.Text,
                boxTitle.Text,
                dataHandler.getPrivilegeByName(boxPrivilege.Text),

                boxCountry.Text,
                boxStateProvince.Text,
                boxZipcode.Text,
                boxCity.Text,
                boxStreet.Text,
                boxStreetNumber.Text,

                dataHandler.getSitesByName(cmbSite.Text).ElementAt(0),
                dataHandler.getDepartmentsByName(cmbDepartment.Text).ElementAt(0),
                dataHandler.getRolesByName(cmbRole.Text).ElementAt(0),
                new Salary(decimal.Parse(boxSalary.Text), 0, 0, boxCurrency.Text));
                
            cache.Update();
            cache.NotifyPropertyChanged("EmployeeCache");
        }

        private void deleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = (Employee)employeeList.SelectedItem;
            employeeManagement.deleteEmployee(selectedEmployee);
            cache.Update();
            cache.NotifyPropertyChanged("EmployeeCache");
        }

        private Dictionary<string, Func<string,bool>> validationStrategiesFunctions = new Dictionary<string, Func<string, bool>>()
        {
            { "boxCity", NameValidator.IsValid},
            { "boxName", NameValidator.IsValid},
            { "boxStateProvince", NameValidator.IsValid },
            { "boxStreet", NameValidator.IsValid },
            { "boxSurname", NameValidator.IsValid },
            { "boxCurrency",ThreeUpperValidator.IsValid },
            { "boxCountry",ThreeUpperValidator.IsValid },
            { "boxStreetNumber",StreetNumberValidator.IsValid  },
            { "boxZipcode", ZipcodeValidator.IsValid },
            { "boxSalary", SalaryValidator.IsValid }
        };


        private void validateInput(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            SolidColorBrush black = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            SolidColorBrush red = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            Func<string, bool> function;
            validationStrategiesFunctions.TryGetValue(textBox.Name, out function);
            if (function.Invoke(textBox.Text))
            {
                textBox.Foreground = black;
            }
            else
            {
                textBox.Foreground = red;
            }
        }
    }
}
