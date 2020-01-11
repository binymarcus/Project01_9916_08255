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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UpdateGuestRequest.xaml
    /// </summary>
    public partial class UpdateGuestRequest : Window
    {
        BE.GuestRequest guest;
        BL.IBL bl;

        public UpdateGuestRequest(string pname, string fname)
        {
            InitializeComponent();    
                guest = bl.GetGuestRequestByName(pname, fname);
                this.updateRequestDetailsGrid.DataContext = guest;
            this.Close();
        }
        public UpdateGuestRequest(long key)
        {
                InitializeComponent();
                guest = bl.GetGuestRequestByKey(key);
                this.updateRequestDetailsGrid.DataContext = guest;
                this.Close();


        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            bl.UpdateGuestRequest(guest);
            MessageBox.Show("Guest Request updated, Key: " + guest.GuestRequestKey1);
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
