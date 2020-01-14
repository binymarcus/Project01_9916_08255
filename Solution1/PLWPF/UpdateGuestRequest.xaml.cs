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
    /// Interaction logic for UpdateGuestRequest.xaml
    /// </summary>
    public partial class UpdateGuestRequest : Window
    {
        BE.GuestRequest guest;
       // BL.IBL bl;
       IBL bl = FactoryBL.getIBL(); //is this what we need?

        public UpdateGuestRequest(long key)
        {
            InitializeComponent();
            try
            {
                guest = bl.GetGuestRequestByKey(key);
            }
            catch (Exception)
            {
                throw;
            }
            this.UpdateGuestRequestDetailsGrid.DataContext = guest;
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {


            int int1;
            int error = 0;
            try
            {
                if (PrivateName1TextBox.Text == "" && error == 0)//need to fill out name (we dont care if his name is a number)
                {
                    MessageBox.Show("need to fill out private name");
                    error++;
                    PrivateName1TextBox.Clear();
                }
                else if (FamilyName1TextBox.Text == "" && error == 0)//need to fill out name (we dont care if his name is a number)
                {
                    MessageBox.Show("need to fill out family name");
                    error++;
                    FamilyName1TextBox.Clear();
                }
                else if ((adults1TextBox.Text != "") && (!(int.TryParse(adults1TextBox.Text, out int1))) && (error == 0))//num of adults has to be a number
                {
                    MessageBox.Show("num of adults has to be filled with a number");
                    error++;
                    adults1TextBox.Clear( );
                }

                if ((children1TextBox.Text != "") && (!(int.TryParse(children1TextBox.Text, out int1))) && (error == 0))//num of adults has to be a number
                {
                    MessageBox.Show("num of children has to be filled with a number");
                    error++;
                    children1TextBox.Clear();
                    
                }

                if (error == 0)
                {
                    bl.UpdateGuestRequest(guest);
                    MessageBox.Show("Guest Request updated, Key: " + guest.GuestRequestKey1);
                    Window GuestRequestWindow = new GuestRequest();
                    GuestRequestWindow.Show();
                    this.Close();
                }
            }
            catch (FormatException)
            {

                MessageBox.Show("Please check your input and try again");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource guestRequestViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("guestRequestViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // guestRequestViewSource.Source = [generic data source]
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window GuestRequestWindow = new GuestRequest();
            GuestRequestWindow.Show();
            this.Close();
        }
    }
}
