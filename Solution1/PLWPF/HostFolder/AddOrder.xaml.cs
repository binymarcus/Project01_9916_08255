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
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<BE.HostingUnit> hostingList = new List<BE.HostingUnit>();
        public AddOrder(long hostkey)
        {
            InitializeComponent();
            hostingList = bl.GetAllHostingUnitsByHostKey(hostkey);

            scrollview1 = new ScrollViewer();

            foreach (BE.HostingUnit item in hostingList)
            {
                HUuserCuntrol gruc = new HUuserCuntrol(item,hostkey);
                b.Children.Add(gruc);
            }

            scrollview1.Content = b;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Window hostwin = new HostWindow();
            hostwin.Show();
            this.Close();
        }
    }
}
