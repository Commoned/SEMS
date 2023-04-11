using SEMS.Adapter.Database;
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
    public partial class MainPage : Window,GuiAdapter
    {
        DataHandler database;
        Cache cache;
        public MainPage(DataHandler dataHandler)
        {
            InitializeComponent();
            database = dataHandler;
            cache = new Cache(database);
        }

        public void invokeGUI()
        {
            Window window = new MainPage(database);
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
            string type;
            switch (button.Name)
            {
                case "employeeButton":
                    type = "employeeGrid";
                    
                    Window empWindow = new Window{
                        Title = "SEMS - Employees",
                        Content = new EmployeePage(new EmployeeManagement(database),cache)
                    };
                    empWindow.Show();

                    break;
                case "siteButton":
                    type = "siteGrid";
                    Window siteWindow = new Window
                    {
                        Title = "SEMS - Sites",
                        Content = new SitePage(cache)
                    };
                    siteWindow.Show();

                    break;
                case "departmentButton":
                    type = "departmentGrid";
                    Window depWindow = new Window
                    {
                        Title = "SEMS - Departments",
                        Content = new DepartmentPage(new DepartmentManagement(database), cache)
                    };
                    depWindow.Show();

                    break;
                case "roleButton":
                    type = "roleGrid";
                    Window roleWindow =  new Window
                    {
                        Title = "SEMS - Roles",
                        Content = new RolePage(cache)
                    };
                    roleWindow.Show();
                    break;
                case "privilegeButton":
                    Window privWindow = new Window
                    {
                        Title = "SEMS - Privileges",
                        Content = new PrivilegePage()
                    };
                    privWindow.Show();
                    break;
                default:
                    type = "";
                    break;
            }
            
        }

        
    }
}
