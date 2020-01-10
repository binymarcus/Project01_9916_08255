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
    /// Interaction logic for UpdateDeleteBy.xaml
    /// </summary>
    public partial class UpdateDeleteBy : Window
    {
        public UpdateDeleteBy()
        {
            InitializeComponent();
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {            
            Window updateRequestWindow = new UpdateGuestRequest();
            updateRequestWindow.Show();
            this.Close();

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            //find the guest request by name or key
            //the delete the guest request
            MessageBox.Show("Guest Request deleted, Key:" );
            this.Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window GuestRequestWindow = new GuestRequest();
            GuestRequestWindow.Show();

            this.Close();
        }
    }
}
