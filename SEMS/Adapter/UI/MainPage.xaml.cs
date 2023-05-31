using SEMS.Adapter.UI;
using SEMS.Application;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

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
            Dictionary<string, Func<Window>> windowContentMap = new Dictionary<string, Func<Window>>()
            {
                { "employeeButton", () => new Window
                    {
                        Title = "SEMS - Employees",
                        Content = new EmployeePage(new EmployeeManagement(database), cache)
                    }
                },
                { "siteButton", () => new Window
                    {
                        Title = "SEMS - Sites",
                        Content = new SitePage(cache)
                    }
                },
                { "departmentButton", () => new Window
                    {
                        Title = "SEMS - Departments",
                        Content = new DepartmentPage(new DepartmentManagement(database), cache)
                    }
                },
                { "roleButton", () => new Window
                    {
                        Title = "SEMS - Roles",
                        Content = new RolePage(cache)
                    }
                },
                { "privilegeButton", () => new Window
                    {
                        Title = "SEMS - Privileges",
                        Content = new PrivilegePage()
                    }
                }
            };

            if (windowContentMap.ContainsKey(button.Name))
            {
                Window window = CreateWindow(windowContentMap[button.Name]);
                window.Show();
            }
        }

        private Window CreateWindow(Func<Window> createContent)
        {
            Window window = createContent.Invoke();
            return window;
        }


    }
}
