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
using BE;
using BL;

namespace PLWPF.HostFolder
{
    /// <summary>
    /// Interaction logic for hostShowAllOrders.xaml
    /// </summary>
    public partial class hostShowAllOrders : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<Order> L = new List<Order>();
        long hostkey;
        string username;
        public hostShowAllOrders()
        {
            InitializeComponent();
        }
        
        public hostShowAllOrders(long key1, string user)
        {
            InitializeComponent();
            username = user;
            try
            {
                L = bl.GetAllOrdersByHostKey(key1);
                orderDataGrid.DataContext = L;
                hostkey = key1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource orderViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("orderViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // orderViewSource.Source = [generic data source]
        }

        private void orderDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void backbutton_Click(object sender, RoutedEventArgs e)
        {
            Window hosty = new HostWindow(username);
            hosty.Show();
            this.Close();
        }
    }
}
