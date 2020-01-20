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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for GRuserControlForAddOrder.xaml
    /// </summary>
    public partial class GRuserControlForAddOrder : UserControl
    {
        BE.Order order;
        long key2;
        IBL bl = FactoryBL.getIBL();
        public GRuserControlForAddOrder(BE.GuestRequest guesty, long key1)
        {
            InitializeComponent();
            key2 = key1;
            grid1.DataContext = guesty;
            order = new BE.Order();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        private void GSpick_Click(object sender, RoutedEventArgs e)
        {
            //we have the hosting unit key and the guestrequest key - need to make an order
            order.HostingUnitKey1 = key2;
            order.GuestRequestKey1 = Convert.ToInt64(guestRequestKey1Label.Content);
            bl.AddOrder(order);
            MessageBox.Show("order added, order key:" + order.OrderKey1);
        }
    }
}
