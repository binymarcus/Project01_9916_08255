using BL;
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
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<BE.GuestRequest> guestList = new List<BE.GuestRequest>();
        public AddOrder()
        {
            InitializeComponent();
            guestList = bl.GetAllGuestRequest();

            scrollview1 = new ScrollViewer();

            foreach (BE.GuestRequest item in guestList)
            {
                GRUserControl gruc = new GRUserControl(item);
                b.Children.Add(gruc);
            }

            scrollview1.Content = b;
        }

        private void updatebyNameupdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (BE.GuestRequest item in guestList)
                {
                    bl.UpdateGuestRequest(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("update error");
            }
            Window GRMain = new GuestRequest();
            GRMain.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window GRMain = new GuestRequest();
            GRMain.Show();
            this.Close();
        }
    }
}
