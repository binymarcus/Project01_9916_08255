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
    /// Interaction logic for AdminHUfunctions.xaml
    /// </summary>
    public partial class AdminHUfunctions : Window
    {
        public AdminHUfunctions()
        {
            InitializeComponent();
        }

        private void GetAllHU_Click(object sender, RoutedEventArgs e)
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
