using SEMS.Application;
using SEMS.Domain;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace SEMS.Adapter.UI
{
    /// <summary>
    /// Interaktionslogik für SitePage.xaml
    /// </summary>
    public partial class SitePage : UserControl
    {
        Cache cache;
        public SitePage(Cache cache)
        {
            InitializeComponent();
            this.DataContext = cache;
            this.cache = cache;
        }

        private void searchData(object sender, RoutedEventArgs e)
        {
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
            cache.Update();
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

            cache.Update();
            cache.NotifyPropertyChanged("SiteCache");
        }
        private void New_Click(object sender, RoutedEventArgs e)
        {
            SiteManagement.newSite(boxName.Text,boxCountry.Text,boxStateProvince.Text,boxZipcode.Text,boxCity.Text,boxStreet.Text,boxStreetNumber.Text) ;
            
            cache.Update();
            cache.NotifyPropertyChanged("SiteCache");
        }
    }
}
