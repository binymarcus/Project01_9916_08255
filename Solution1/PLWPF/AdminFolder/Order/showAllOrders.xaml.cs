using BE;
using BL;
using PLWPF.HostFolder;
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

namespace PLWPF.AdminFolder.Order
{
    /// <summary>
    /// Interaction logic for showAllOrders.xaml
    /// </summary>
    public partial class showAllOrders : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<BE.Order> orderList = new List<BE.Order>();
        public showAllOrders()
        {
            InitializeComponent();
            scrollview1 = new ScrollViewer();

            try
            {
                orderList = bl.GetAllOrders();



                foreach (BE.Order item in orderList)
                {
                    OrderUC gruc = new OrderUC(item);
                    b.Children.Add(gruc);
                }

                scrollview1.Content = b;
            }
            catch (Exception)
            {
                textBlock.Visibility = Visibility.Visible;

            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window GRMain = new AdminOrderFunctions();
            GRMain.Show();
            this.Close();
        }
    }
}