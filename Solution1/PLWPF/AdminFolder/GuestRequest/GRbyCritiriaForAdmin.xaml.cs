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

namespace PLWPF.AdminFolder.GuestRequest
{
    /// <summary>
    /// Interaction logic for GRbyCritiriaForAdmin.xaml
    /// </summary>
    public partial class GRbyCritiriaForAdmin : Window
    {
        public GRbyCritiriaForAdmin()
        {
            InitializeComponent();
        }

        private void BackB_Click(object sender, RoutedEventArgs e)
        {
            Window win = new AdminGRfunctions();
            win.Show();
            this.Close();
        }

        private void childrenGR_Click(object sender, RoutedEventArgs e)
        {

        }

        private void gardenGR_Click(object sender, RoutedEventArgs e)
        {

        }

        private void jaccuzziGR_Click(object sender, RoutedEventArgs e)
        {

        }

        private void poolGR_Click(object sender, RoutedEventArgs e)
        {

        }

        private void southGR_Click(object sender, RoutedEventArgs e)
        {

        }

        private void northGR_Click(object sender, RoutedEventArgs e)
        {

        }

        private void centerGR_Click(object sender, RoutedEventArgs e)
        {

        }

        private void jemGR_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
