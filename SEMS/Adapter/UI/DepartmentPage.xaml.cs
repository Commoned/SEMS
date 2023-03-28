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
            DepartmentManagement.updateDepartment(selectedDept);
            Cache cache = Cache.Instance;
            cache.Update();
            cache.NotifyPropertyChanged("DeptCache");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Department selectedDept = (Department)deptList.SelectedItem;
            try
            {
                DepartmentManagement.deleteDepartment(selectedDept);
            }
            catch (Exception except){
                MessageBox.Show(except.Message);
                
            }
            Cache cache = Cache.Instance;
            cache.Update();
            cache.NotifyPropertyChanged("DeptCache");
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            DepartmentManagement.newDepartment(boxName.Text,boxDescription.Text,boxAccountingUnit.Text);
            Cache cache = Cache.Instance;
            cache.Update();
            cache.NotifyPropertyChanged("DeptCache");
        }

    }
}
