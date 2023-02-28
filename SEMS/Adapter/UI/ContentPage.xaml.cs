using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Threading;
using System.Collections.ObjectModel;
using System.Diagnostics;
using SEMS.Domain;
using System.Runtime.CompilerServices;

namespace SEMS.Adapter.UI
{
    /// <summary>
    /// Interaktionslogik für ContentPage.xaml
    /// </summary>
    public partial class ContentPage : UserControl
    {
        public ObservableCollection<Address> tempList = new ObservableCollection<Address>();

        public ContentPage(string type)
        {
            InitializeComponent();
            Grid contentGrid = (Grid)this.FindName(type);
            contentGrid.Visibility = Visibility.Visible;
            tempList.Add(new Address("BaWü","76227","Karlsruhe","Max-Beckmannstr","43"));
            tempList.Add(new Address("BaWü", "76227", "Karlsruhe", "Max-Beckmannstr", "43"));
            tempList.Add(new Address("BaWü", "76227", "Karlsruhe", "Max-Beckmannstr", "43"));
            tempList.Add(new Address("BaWü", "76227", "Karlsruhe", "Max-Beckmannstr", "43"));
            tempList.Add(new Address("BaWü", "76227", "Karlsruhe", "Max-Beckmannstr", "43"));
            Debug.WriteLine(tempList);
            this.DataContext = this;
            
        }
        public ObservableCollection<Address> TempList
        {
            get
            {
                return tempList;
            }
            set
            {
                this.tempList = value;
            }
            
        }

        private void searchData(object sender, RoutedEventArgs e)
        {
           
        }
        

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            Thread.CurrentThread.Abort();
        }
       


        private void employeeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Address test = (Address)employeeList.SelectedItem;
            boxStateProvince.Text = test.StateProvince;
            boxZipcode.Text = test.Zipcode;
            boxCity.Text = test.City;
            boxStreet.Text = test.Street;
            boxStreetnumber.Text = test.Number;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Address selectedEmployee = (Address)employeeList.SelectedItem;
            selectedEmployee.StateProvince = boxStateProvince.Text;
            selectedEmployee.City = boxCity.Text;
            selectedEmployee.Street = boxStreet.Text;
            selectedEmployee.Zipcode = boxZipcode.Text;
            selectedEmployee.Number = boxStreetnumber.Text;
            // TODO Updateing view
        }
    }
}
