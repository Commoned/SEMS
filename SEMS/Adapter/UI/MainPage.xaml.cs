using SEMS.Adapter.UI;
using SEMS.Application;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SEMS.Adapter
{
    public interface GuiAdapter
    {
        void invokeGUI();
    }
    /// <summary>
    /// Interaktionslogik für MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl,GuiAdapter
    {
        
        public MainPage()
        {
            InitializeComponent();
            
        }

        public void invokeGUI()
        {

            Window window = new Window {
                Title = "SEMS",
                Content = new MainPage()
            };
            window.ShowDialog();
            
        }
        
        private void openSettings(object sender, RoutedEventArgs e)
        {
            ColorAnimation ca = new ColorAnimation(Colors.Blue, new Duration(TimeSpan.FromSeconds(4)));
            empBack.Background = new SolidColorBrush(Colors.Red);
            empBack.Background.BeginAnimation(SolidColorBrush.ColorProperty, ca);
            Debug.WriteLine("Settings opened");
        }

        private void openNextPage(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Window window;
            string type;
            switch (button.Name)
            {
                
                case "employeeButton":
                    type = "employeeGrid";
                    window = new Window
                    {
                        Title = "SEMS - Employees",
                        Content = new EmployeePage()
                    };
                    window.ShowDialog();
                    break;
                case "siteButton":
                    type = "siteGrid";
                    window = new Window
                    {
                        Title = "SEMS - Employees",
                        Content = new SitePage()
                    };
                    window.ShowDialog();
                    break;
                case "departmentButton":
                    type = "departmentGrid";
                    window = new Window
                    {
                        Title = "SEMS - Employees",
                        Content = new DepartmentPage()
                    };
                    window.ShowDialog();
                    break;
                case "roleButton":
                    type = "roleGrid";
                    window = new Window
                    {
                        Title = "SEMS - Employees",
                        Content = new RolePage()
                    };
                    window.ShowDialog();
                    break;
                case "privilegeButton":
                    type = "privilegeGrid";
                    break;
                default:
                    type = "";
                    break;
            }
            
            
            GC.Collect();
        }

        public void newWindow(string type)
        {
            Window window = new Window
            {
                Title = "SEMS - Employees",
                Content = new EmployeePage()
            };
            window.ShowDialog();
        }

    }
}
