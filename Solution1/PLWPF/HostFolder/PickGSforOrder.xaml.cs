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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for PickGSforOrder.xaml
    /// </summary>
    public partial class PickGSforOrder : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<BE.GuestRequest> guestList = new List<BE.GuestRequest>();
        long key1;

        public PickGSforOrder()
        {
            InitializeComponent();
        }
        
        public PickGSforOrder(long hoeunitkey)
        {
            InitializeComponent();
            key1 = hoeunitkey;
            HostingUnit hoeunit;
            hoeunit = bl.GetHostingUnitByKey(hoeunitkey);
            grid2.DataContext = hoeunit;
            //////////////////////////////////////////////////////////////
            guestList = bl.GetAllGuestRequest();
            scrollview1 = new ScrollViewer();

            foreach (BE.GuestRequest item in guestList)
            {
                GRuserControlForAddOrder gruc = new GRuserControlForAddOrder(item,key1);
                b.Children.Add(gruc);
            }

            scrollview1.Content = b;
            ////////////////////////////////////////////////////////////////
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
        }

        private void BackB_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
