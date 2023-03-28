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
using System.Threading;

namespace SEMS.Adapter.UI
{
    /// <summary>
    /// Interaktionslogik für DepartmentPage.xaml
    /// </summary>
    public partial class DepartmentPage : UserControl
    {
        DepartmentManagement departmentManagement;
        Cache cache;
        public DepartmentPage(DepartmentManagement departmentManagement, Cache cache)
        {
            InitializeComponent();
            this.DataContext = cache;
            this.departmentManagement = departmentManagement;
            this.cache = cache;
        }


        private void searchData(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(cache.EmployeeCache);
        }
        private void deptList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Department selectedDept = (Department)deptList.SelectedItem;
            editWindow.DataContext = selectedDept;
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Department selectedDept = (Department)deptList.SelectedItem;
            selectedDept.Name = boxName.Text;
            selectedDept.Description = boxDescription.Text;
            selectedDept.AccountingUnit = boxAccountingUnit.Text;
            departmentManagement.updateDepartment(selectedDept);
            cache.Update();
            cache.NotifyPropertyChanged("DeptCache");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Department selectedDept = (Department)deptList.SelectedItem;
            try
            {
                departmentManagement.deleteDepartment(selectedDept);
            }
            catch (Exception except){
                MessageBox.Show(except.Message);
                
            }
            cache.Update();
            cache.NotifyPropertyChanged("DeptCache");
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            departmentManagement.newDepartment(boxName.Text,boxDescription.Text,boxAccountingUnit.Text);
            cache.Update();
            cache.NotifyPropertyChanged("DeptCache");
        }

    }
}
