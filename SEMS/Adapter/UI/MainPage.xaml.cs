using SEMS.Application;
using System;
using System.Collections.Generic;
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
            Window window = new Window
            {
                Title = "SEMS",
                Content = new MainPage()
            };
            window.ShowDialog();
        }

        private void createEmployee(object sender, RoutedEventArgs e)
        {
            EmployeeManagement.newEmployee();
        }
    }
}
