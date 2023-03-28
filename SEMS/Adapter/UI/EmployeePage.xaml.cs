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
using System.Windows.Controls.Primitives;

namespace SEMS.Adapter.UI
{
    /// <summary>
    /// Interaktionslogik für EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : UserControl
    {
        DataHandler dataHandler = new Database();
        EmployeeManagement employeeManagement;

        public EmployeePage(EmployeeManagement employeeManagement)
        {
            InitializeComponent();
            this.DataContext = Cache.Instance;
            this.employeeManagement = employeeManagement;
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
            Cache cache = Cache.Instance;
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
            Cache cache = Cache.Instance;
            cache.Update();
            cache.NotifyPropertyChanged("EmployeeCache");
        }

        private void deleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee selectedEmployee = (Employee)employeeList.SelectedItem;
            employeeManagement.deleteEmployee(selectedEmployee);
            Cache cache = Cache.Instance;
            cache.Update();
            cache.NotifyPropertyChanged("EmployeeCache");
        }

        private void validateInput(object sender, KeyEventArgs e)
        {
            IValidationStrategy strategy;
            InputValidator validator ;
            TextBox textBox = (TextBox)sender;
            List<TextBox> textInputs = new List<TextBox> { boxCity, boxName, boxStateProvince, boxStreet, boxSurname};
            List<TextBox> threeUpper = new List<TextBox> { boxCurrency, boxCountry };
            if (textInputs.Contains(sender))
            {
                strategy = new NameValidator();
                validator = new InputValidator(strategy);
                bool isValid = validator.Validate(textBox.Text);
                if (!isValid) { textBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0)); }
                else { textBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0)); }
            }
            if (threeUpper.Contains(sender))
            {
                strategy = new ThreeUpperValidator();
                validator = new InputValidator(strategy);
                bool isValid = validator.Validate(textBox.Text);
                if (!isValid) { textBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0)); }
                else { textBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0)); }
            }
            if (sender == boxStreetNumber)
            {
                strategy = new StreetNumberValidator();
                validator = new InputValidator(strategy);
                bool isValid = validator.Validate(textBox.Text);
                if (!isValid) { textBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0)); }
                else { textBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0)); }
            }
            if (sender == boxZipcode)
            {
                strategy = new ZipcodeValidator();
                validator = new InputValidator(strategy);
                bool isValid = validator.Validate(textBox.Text);
                if (!isValid) { textBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0)); }
                else { textBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0)); }
            }
            if (sender == boxSalary)
            {
                strategy = new SalaryValidator();
                validator = new InputValidator(strategy);
                bool isValid = validator.Validate(textBox.Text);
                if (!isValid) { textBox.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0)); }
                else { textBox.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0)); }
            }

        }
    }
}
