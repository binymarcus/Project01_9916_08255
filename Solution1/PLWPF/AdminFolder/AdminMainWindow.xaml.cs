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
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        public AdminMainWindow()
        {
            InitializeComponent();
        }

        private void GRfunctions_Click(object sender, RoutedEventArgs e)
        {
            Window adminGRfunctions = new AdminGRfunctions();
            adminGRfunctions.Show();
            this.Close();
        }

        private void HostFunctions_Click(object sender, RoutedEventArgs e)
        {
            Window hostFunctionWindow = new AdminHostFunctions();
            hostFunctionWindow.Show();
            this.Close();
        }

        private void HUFunctions_Click(object sender, RoutedEventArgs e)
        {
            Window hostinUnitsFunctionWindow = new AdminHUfunctions();
            hostinUnitsFunctionWindow.Show();
            this.Close();
        }

        private void OrderFunctions_Click(object sender, RoutedEventArgs e)
        {
            Window orderFunctionWindow = new AdminOrderFunctions();
            orderFunctionWindow.Show();
            this.Close();
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            SignInPage signInPage = new SignInPage();
            signInPage.Show();
            this.Close();
        }
    }
}
