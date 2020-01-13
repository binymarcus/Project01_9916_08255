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
using System.Windows.Shapes;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UpdateGuestRequest.xaml
    /// </summary>
    public partial class UpdateGuestRequest : Window
    {
        BE.GuestRequest guest;
       // BL.IBL bl;
       IBL bl = FactoryBL.getIBL(); //is this what we need?

      public UpdateGuestRequest(string pname, string fname)
        {
            InitializeComponent();
            try
            {
                guest = bl.GetGuestRequestByName(pname, fname);
            }
            catch (Exception)
            {
                throw;                
            }
                this.UpdateGuestRequestDetailsGrid.DataContext = guest;
        }
        public UpdateGuestRequest(long key)
        {
            InitializeComponent();
            try
            {
                guest = bl.GetGuestRequestByKey(key);
            }
            catch (Exception)
            {
                throw;
            }
            this.UpdateGuestRequestDetailsGrid.DataContext = guest;
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            bl.UpdateGuestRequest(guest);
            MessageBox.Show("Guest Request updated, Key: " + guest.GuestRequestKey1);
            Window GuestRequestWindow = new GuestRequest();
            GuestRequestWindow.Show();
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource guestRequestViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("guestRequestViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // guestRequestViewSource.Source = [generic data source]
        }
        
    }
}
