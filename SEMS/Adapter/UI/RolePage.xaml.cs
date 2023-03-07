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
        public RolePage()
        {
            InitializeComponent();
            this.DataContext = (object)Cache.Instance;
        }

        private void searchData(object sender, RoutedEventArgs e)
        {
            Cache cache = Cache.Instance;
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
            Cache cache = Cache.Instance;
            cache.update();
            cache.NotifyPropertyChanged("RoleCache");
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            RoleManagement.deleteRole((Role)roleList.SelectedItem);
            Cache cache = Cache.Instance;
            cache.update();
            cache.NotifyPropertyChanged("RoleCache");
        }
        private void New_Click(object sender, RoutedEventArgs e)
        {
            RoleManagement.newRole(boxName.Text, boxDescription.Text);
            Cache cache = Cache.Instance;
            cache.update();
            cache.NotifyPropertyChanged("RoleCache");
        }
    }
}
