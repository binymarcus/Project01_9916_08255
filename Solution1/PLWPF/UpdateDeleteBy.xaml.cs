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
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UpdateDeleteBy.xaml
    /// </summary>
    public partial class UpdateDeleteBy : Window
    {
        BE.GuestRequest guest;
        //BL.IBL bl;
        IBL bl = FactoryBL.getIBL();

        public UpdateDeleteBy()
        {
            InitializeComponent();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if ((this.UpdatePrivateNameTextBox.Text != "" || this.UpdatefamilyNameTextBox.Text != "" ) && this.UpdateKey.Text != "")
            {
                MessageBox.Show("please enter only one field, byname or by key.");
                Window UpdateDeleteByWindow = new UpdateDeleteBy();
                UpdateDeleteByWindow.Show();
                this.Close();
            }
            else if (this.UpdatefamilyNameTextBox.Text != "" && this.UpdatePrivateNameTextBox.Text != "")
            {
                try
                {
                   //sends to a window whith a scroll box and then the user has to pick which gs he wants to update
                    Window UpdateByNameChooseWindow = new UpdateByNameChoose(this.UpdatePrivateNameTextBox.Text, this.UpdatefamilyNameTextBox.Text);
                    UpdateByNameChooseWindow.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("Guest Requests for this user don't exist");
                }               
            }
            else if (this.UpdateKey.Text != "")
            {
                try
                {
                    Window updateRequestWindow = new UpdateGuestRequest(long.Parse(this.UpdateKey.Text));
                    updateRequestWindow.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("Guest Request does not exist");
                }
                
            }
            else
            {
                MessageBox.Show("Guest Request does not exist, " +
                   "or you entered info into wrong fields");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.DeleteFamilyNameTextBox.Text != "" && this.DeletePrivateNameTextBox.Text != "" && this.DeleteKeyTextBox.Text != "")
            {
                MessageBox.Show("please enter only one field, byname or by key.");
                Window UpdateDeleteByWindow = new UpdateDeleteBy();
                UpdateDeleteByWindow.Show();
                this.Close();
            }

           /*else if (this.DeleteFamilyNameTextBox.Text != "" && this.DeletePrivateNameTextBox.Text != "")
           {
                try
                {
                    guest = bl.GetallGuestRequestByName(this.DeletePrivateNameTextBox.Text, this.DeleteFamilyNameTextBox.Text);
                    long tempkey = guest.GuestRequestKey1;
                    bl.DeleteGuestRequest(guest);
                    MessageBox.Show("Guest Request deleted, Key: " + tempkey);
                    Window GuestRequestWindow = new GuestRequest();
                    GuestRequestWindow.Show();
                    this.Close();
                }
                catch(Exception)
                {
                    MessageBox.Show("Guest Request does not exist");
                    Window GuestRequestWindow = new GuestRequest();
                    GuestRequestWindow.Show();
                    this.Close();
                }               
                
           }*/
            else if (this.DeleteKeyTextBox.Text != "")
            {
                try
                {
                    guest = bl.GetGuestRequestByKey(long.Parse(this.DeleteKeyTextBox.Text));
                    long tempkey = guest.GuestRequestKey1;
                    bl.DeleteGuestRequest(guest);
                    MessageBox.Show("Guest Request deleted, Key: " + tempkey);
                    Window GuestRequestWindow = new GuestRequest();
                    GuestRequestWindow.Show();
                    this.Close();
                }
                catch(Exception)
                {
                    MessageBox.Show("Guest Request does not exist");
                    Window GuestRequestWindow = new GuestRequest();
                    GuestRequestWindow.Show();
                    this.Close();
                }
               
            }
            else
            {
                MessageBox.Show("Guest Request does not exist, " +
                    "or you entered info into wrong fields");
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
