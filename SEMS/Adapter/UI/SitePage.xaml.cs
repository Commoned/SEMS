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
            Site selectedSite = (Site)siteList.SelectedItem;
            editWindow.DataContext = selectedSite;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Site selectedSite = (Site)siteList.SelectedItem;
            selectedSite.Name = boxName.Text;
            selectedSite.Address.Country = boxCountry.Text;
            selectedSite.Address.State = boxStateProvince.Text;
            selectedSite.Address.City = boxCity.Text;
            selectedSite.Address.Zipcode = boxZipcode.Text;
            selectedSite.Address.Street = boxStreet.Text;
            selectedSite.Address.Number = boxStreetNumber.Text;
            SiteManagement.updateSite(selectedSite);
            Cache cache = Cache.Instance;
            cache.update();
            cache.NotifyPropertyChanged("SiteCache");
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Site selectedSite = (Site)siteList.SelectedItem;
            try
            {
            SiteManagement.deleteSite(selectedSite);
            }
            catch (Exception except){
                MessageBox.Show(except.Message);
            }

            Cache cache = Cache.Instance;
            cache.update();
            cache.NotifyPropertyChanged("SiteCache");
        }
        private void New_Click(object sender, RoutedEventArgs e)
        {
            SiteManagement.newSite(boxName.Text,boxCountry.Text,boxStateProvince.Text,boxZipcode.Text,boxCity.Text,boxStreet.Text,boxStreetNumber.Text) ;
            Cache cache = Cache.Instance;
            cache.update();
            cache.NotifyPropertyChanged("SiteCache");
        }
    }
}
