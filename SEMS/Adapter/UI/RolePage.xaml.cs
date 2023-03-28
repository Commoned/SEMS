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
    /// Interaktionslogik für RolePage.xaml
    /// </summary>
    public partial class RolePage : UserControl
    {
        Cache cache;
        public RolePage(Cache cache)
        {
            InitializeComponent();
            this.DataContext = cache;
            this.cache = cache;
        }

        private void searchData(object sender, RoutedEventArgs e)
        {
            
            Debug.WriteLine(cache.EmployeeCache);
        }
        private void role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Role selectedRole = (Role)roleList.SelectedItem;
            editWindow.DataContext = selectedRole;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Role selectedRole = (Role)roleList.SelectedItem;
            selectedRole.Name = boxName.Text;
            selectedRole.Description = boxDescription.Text;
            RoleManagement.updateRole(selectedRole);
            
            cache.Update();
            cache.NotifyPropertyChanged("RoleCache");
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            try { 
            RoleManagement.deleteRole((Role)roleList.SelectedItem);
            }
            catch (Exception except){
                MessageBox.Show(except.Message);
                
            }

    
            cache.Update();
            cache.NotifyPropertyChanged("RoleCache");
        }
        private void New_Click(object sender, RoutedEventArgs e)
        {
            RoleManagement.newRole(boxName.Text, boxDescription.Text);
            
            cache.Update();
            cache.NotifyPropertyChanged("RoleCache");
        }
    }
}
