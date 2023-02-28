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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        }
        private void createEmployee(object sender, RoutedEventArgs e)
        {
            EmployeeManagement.newEmployee();
        }
        private void openSettings(object sender, RoutedEventArgs e)
        {
            ColorAnimation ca = new ColorAnimation(Colors.Blue, new Duration(TimeSpan.FromSeconds(4)));
            empBack.Background = new SolidColorBrush(Colors.Red);
            empBack.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
            Debug.WriteLine("Settings opened");
        }

        private void openEmployeePage(object sender, RoutedEventArgs e)
        {

        }

    }
}
