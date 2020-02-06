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
using BE;
using BL;
using PLWPF.AdminFolder.Host;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AdminHostFunctions.xaml
    /// </summary>
    public partial class AdminHostFunctions : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<BE.GuestRequest> grList = new List<BE.GuestRequest>();
        public AdminHostFunctions()
        {
            InitializeComponent();
            if (hebEnglish.hebrew)
                hebChange();
        }
        private void hebChange()
        {
            Title = "אדמיןמארח";
            GetAllHostsButton.Content = "הבא כל המארחים";
            somthing.Content = "הבא מארחים על פי מספר יחידות";
            FindHostMost.Content = "הבא מארח עם הכי הרבה יחידות";
            BackButton.Content = "חזור";
        }
        private void GetAllHostsButton_Click(object sender, RoutedEventArgs e)
        {
            Window host = new ShowAllHosts();
            host.Show();
            this.Close();

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window adminMainWindow = new AdminMainWindow();
            adminMainWindow.Show();
            this.Close();
        }

        private void FindHostMost_Click(object sender, RoutedEventArgs e)
        {
            Host hosty = null;
            int max = -1;
            List<Host> L = new List<Host>();           
            L = bl.GetAllHosts();

            if (L.Count() != 0)
            {
                foreach (var host in L)
                {
                    if (host.NumOfHostinUnits1 >= max)
                    {
                        max = host.NumOfHostinUnits1;
                        hosty = host;
                    }
                }
                MessageBox.Show("the host with most hosting unit:" + hosty.HostKey1 + "/n" +
                    "num of hosting units:" + hosty.NumOfHostinUnits1);
            }
            else
                MessageBox.Show("there are no hosts in the system!");
        }

        private void somthing_Click(object sender, RoutedEventArgs e)
        {
            Window win = new numOfHUforEachHostForAdmin();
            win.Show();
            this.Close();
        }
    }
}
