using PLWPF.AdminFolder;
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
using PLWPF.AdminFolder.GuestRequest;
using BL;
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AdminGRfunctions.xaml
    /// </summary>
    public partial class AdminGRfunctions : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<BE.GuestRequest> unitList = new List<BE.GuestRequest>();
        public AdminGRfunctions()
        {
            InitializeComponent();
        }

        private void GetAllGR_Click(object sender, RoutedEventArgs e)
        {
            Window get = new ShowAllGR();
            get.Show();
            this.Close();

        }

        private void FindGRcriteria_Click(object sender, RoutedEventArgs e)
        {
            Window win = new GRbyCritiriaForAdmin();
            win.Show();
            this.Close();

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window adminMainWindow = new AdminMainWindow();
            adminMainWindow.Show();
            this.Close();
        }

        private void calc_Click(object sender, RoutedEventArgs e)
        {
            List<BE.GuestRequest> L = new List<BE.GuestRequest>();
            int amount = 0;
            try
            {
                L = bl.GetAllGuestRequest();
                amount = L.Count();
                MessageBox.Show("number of guest requests in the system:" + amount);
            }
            catch
            {
                MessageBox.Show("error!");
            }
        }
    }
}
