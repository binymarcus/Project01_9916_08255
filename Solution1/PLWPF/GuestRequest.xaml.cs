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
    /// Interaction logic for AddGuestRequest.xaml
    /// </summary>
    public partial class GuestRequest : Window
    {
        public GuestRequest()
        {
            InitializeComponent();
        }
        private void addRequestButton_Click(object sender, RoutedEventArgs e)
        {
            Window addRequestWindow = new AddGuestRequest();
            addRequestWindow.Show();
            this.Close();

        }
        private void updateRequestButton_Click(object sender, RoutedEventArgs e)
        {
            Window updateRequestWindow = new UpdateGuestRequest();
            updateRequestWindow.Show();
            this.Close();

        }
        private void deleteRequestButton_Click(object sender, RoutedEventArgs e)
        {
            Window deleteRequestWindow = new DeleteGuestRequest();
            deleteRequestWindow.Show();
            this.Close();

        }
    }
}
