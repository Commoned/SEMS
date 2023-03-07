using SEMS.Adapter.UI;
using SEMS.Application;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            
            string type;
            switch (button.Name)
            {
                case "employeeButton":
                    type = "employeeGrid";
                    
                    var thread1 = new Thread(() => new Window
                    {
                        Title = "SEMS - Employees",
                        Content = new EmployeePage()
                    }.ShowDialog());
                    thread1.SetApartmentState(ApartmentState.STA);
                    thread1.Start();

                    break;
                case "siteButton":
                    type = "siteGrid";
                    var thread2 = new Thread(() => new Window
                    {
                        Title = "SEMS - Sites",
                        Content = new SitePage()
                    }.ShowDialog());
                    thread2.SetApartmentState(ApartmentState.STA);
                    thread2.Start();
                    //window.ShowDialog();
                    break;
                case "departmentButton":
                    type = "departmentGrid";
                    var thread3 = new Thread(() => new Window
                    {
                        Title = "SEMS - Departments",
                        Content = new DepartmentPage()
                    }.ShowDialog());
                    thread3.SetApartmentState(ApartmentState.STA);
                    thread3.Start();
                    //window.ShowDialog();
                    break;
                case "roleButton":
                    type = "roleGrid";
                    var thread4 = new Thread(() => new Window
                    {
                        Title = "SEMS - Roles",
                        Content = new RolePage()
                    }.ShowDialog());
                    thread4.SetApartmentState(ApartmentState.STA);
                    thread4.Start();
                    //window.ShowDialog
                    break;
                case "privilegeButton":
                    var thread5 = new Thread(() => new Window
                    {
                        Title = "SEMS - Roles",
                        Content = new PrivilegePage()
                    }.ShowDialog());
                    thread5.SetApartmentState(ApartmentState.STA);
                    thread5.Start();
                    break;
                default:
                    type = "";
                    break;
            }
            
        }

        
    }
}
