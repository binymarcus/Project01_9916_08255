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

namespace PLWPF.AdminFolder
{
    /// <summary>
    /// Interaction logic for ShowAllGR.xaml
    /// </summary>
    public partial class ShowAllGR : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<BE.GuestRequest> guestList = new List<BE.GuestRequest>();
        public ShowAllGR()
        {
            InitializeComponent();
            scrollview1 = new ScrollViewer();

            try
            {
                guestList = bl.GetAllGuestRequest();



                foreach (BE.GuestRequest item in guestList)
                {
                    GRUserControl gruc = new GRUserControl(item);
                    b.Children.Add(gruc);
                }

                scrollview1.Content = b;
            }
            catch(Exception)
            {
                textBlock.Visibility = Visibility.Visible;

            }
        }

        
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window GRMain = new AdminGRfunctions();
            GRMain.Show();
            this.Close();
        }
    }
}
