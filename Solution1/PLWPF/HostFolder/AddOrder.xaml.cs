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
        string username;
        public AddOrder(long hostkey,string user)
        {
            InitializeComponent();
            hostingList = bl.GetAllHostingUnitsByHostKey(hostkey);
            username = user;
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
            Window hostwin = new HostWindow(username);
            hostwin.Show();
            this.Close();
        }
    }
}
