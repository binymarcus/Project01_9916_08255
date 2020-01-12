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
        BE.GuestRequest guest;
        BL.IBL bl;
        public UpdateDeleteBy()
        {
            InitializeComponent();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

            if (this.UpdatefamilyNameTextBox.Text != null && this.UpdatePrivateNameTextBox.Text != null)
            {
                Window updateRequestWindow = new UpdateGuestRequest(this.UpdatefamilyNameTextBox.Text, this.UpdatePrivateNameTextBox.Text);
                updateRequestWindow.Show();
                this.Close();
            }
            else if (this.UpdateKey.Text != null)
            {
                Window updateRequestWindow = new UpdateGuestRequest(long.Parse(this.UpdateKey.Text));
                updateRequestWindow.Show();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.DeleteFamilyNameTextBox.Text != null && this.DeletePrivateNameTextBox.Text != null)//what is the watermark considard as?
            {
                guest = bl.GetGuestRequestByName(this.DeletePrivateNameTextBox.Text, this.DeleteFamilyNameTextBox.Text);
                bl.DeleteGuestRequest(guest);
                long tempkey = guest.GuestRequestKey1;
                MessageBox.Show("Guest Request deleted, Key: " + tempkey);
                this.Close();
            }
            else if (this.UpdateKey != null)//what is the watermark considard as?
            {             
                guest = bl.GetGuestRequestByKey(long.Parse(this.DeleteKeyTextBox.Text));
                bl.DeleteGuestRequest(guest);
                MessageBox.Show("Guest Request deleted, Key: " + guest.GuestRequestKey1);
                this.Close();
            }
            else
            {
                MessageBox.Show("Guest Request does not exist" +
                    "or you entered info into wrong fields");
                this.Close();
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window GuestRequestWindow = new GuestRequest();
            GuestRequestWindow.Show();

            this.Close();
        }
    }
}
