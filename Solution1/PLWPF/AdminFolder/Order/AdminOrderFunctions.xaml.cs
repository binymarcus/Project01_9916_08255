using BL;
using PLWPF.AdminFolder.Order;
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
    /// Interaction logic for AdminOrderFunctions.xaml
    /// </summary>
    public partial class AdminOrderFunctions : Window
    {
        IBL bl = FactoryBL.getIBL();
        public AdminOrderFunctions()
        {
            InitializeComponent();
        }

        private void GetAllOrders_Click(object sender, RoutedEventArgs e)
        {
            Window or = new showAllOrders();
            or.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window adminMainWindow = new AdminMainWindow();
            adminMainWindow.Show();
            this.Close();
        }

        private void removerOldOrdersButton(object sender, RoutedEventArgs e)
        {
            Remove.Visibility = Visibility.Visible;
            textBox.Visibility = Visibility.Visible;
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.OlderOrders(int.Parse(textBox.Text));
                Remove.Visibility = Visibility.Hidden;
                textBox.Visibility = Visibility.Hidden;
                MessageBox.Show("orders removed");
            }
            catch(Exception c)
            {
                MessageBox.Show("there are no orders older than the date requested");
            }
            }

    }
}