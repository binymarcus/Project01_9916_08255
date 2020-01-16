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
    /// Interaction logic for AdminGRfunctions.xaml
    /// </summary>
    public partial class AdminGRfunctions : Window
    {
        public AdminGRfunctions()
        {
            InitializeComponent();
        }

        private void GetAllGR_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FindGRcriteria_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window adminMainWindow = new AdminMainWindow();
            adminMainWindow.Show();
            this.Close();
        }
    }
}
