using SEMS.Application;
using SEMS.Domain;
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

namespace SEMS.Adapter.UI
{
    /// <summary>
    /// Interaktionslogik für SitePage.xaml
    /// </summary>
    public partial class SitePage : UserControl
    {
        public SitePage()
        {
            InitializeComponent();
            this.DataContext = (object)Cache.Instance;
        }

        private void searchData(object sender, RoutedEventArgs e)
        {
            Cache cache = Cache.Instance;
            Debug.WriteLine(cache.EmployeeCache);
        }
        private void siteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Site test = (Site)siteList.SelectedItem;
            boxName.Text = test.Name;
            //boxStateProvince.Text = test.Address.StateProvince;
            boxZipcode.Text = test.Address.Zipcode;
            boxCity.Text = test.Address.City;
            boxStreet.Text = test.Address.Street;
            boxStreetNumber.Text = test.Address.Number;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void New_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
