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
    /// Interaction logic for AddGuestRequest.xaml
    /// </summary>
    public partial class GuestRequest : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<BE.GuestRequest> guestList = new List<BE.GuestRequest>();
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
            Window UpdateBYWindow = new UpdateDeleteBy();
            UpdateBYWindow.Show();
            //Window updateRequestWindow = new UpdateGuestRequest();
            //updateRequestWindow.Show();
            this.Close();

        }
        private void deleteRequestButton_Click(object sender, RoutedEventArgs e)
        {
            Window UpdateBYWindow = new UpdateDeleteBy();
            UpdateBYWindow.Show();
            this.Close();

           // Window deleteRequestWindow = new DeleteGuestRequest();
           //deleteRequestWindow.Show();
           //this.Close();

        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window signinwindow = new SignInPage();
            signinwindow.Show();
            this.Close();

        }

        private void ShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            this.alllabal.Visibility = Visibility.Visible;
            this.privatenameinput.Visibility = Visibility.Visible;
            this.familyenameinput.Visibility = Visibility.Visible;
            this.showbutton.Visibility = Visibility.Visible;
            this.cancelbutton.Visibility = Visibility.Visible;

            this.AddRequestButton.Visibility = Visibility.Hidden;
            this.UpdateRequestButton.Visibility = Visibility.Hidden;
            this.DeleteRequestButton.Visibility = Visibility.Hidden;
            this.ShowAllButton.Visibility = Visibility.Hidden;
            this.SignOutButton.Visibility = Visibility.Hidden;
        }

        private void showbutton_Click(object sender, RoutedEventArgs e)
        {
            this.alllabal.Visibility = Visibility.Hidden;
            this.privatenameinput.Visibility = Visibility.Hidden;
            this.familyenameinput.Visibility = Visibility.Hidden;
            this.showbutton.Visibility = Visibility.Hidden;
            this.cancelbutton.Visibility = Visibility.Hidden;

            this.AddRequestButton.Visibility = Visibility.Hidden;
            this.UpdateRequestButton.Visibility = Visibility.Hidden;
            this.DeleteRequestButton.Visibility = Visibility.Hidden;
            this.ShowAllButton.Visibility = Visibility.Hidden;
            this.SignOutButton.Visibility = Visibility.Hidden;

            try
            {
                guestList = bl.GetallGuestRequestByName(this.privatenameinput.Text, this.familyenameinput.Text);

                this.BackButton2.Visibility = Visibility.Visible;
                this.scrollview1.Visibility = Visibility.Visible;
                this.b.Visibility = Visibility.Visible;

                scrollview1 = new ScrollViewer();

                foreach (BE.GuestRequest item in guestList)
                {
                    GRUserControl gruc = new GRUserControl(item);
                    b.Children.Add(gruc);
                }
                scrollview1.Content = b;
            }
            catch(Exception)
            {
                MessageBox.Show("user doesn't exist");
                this.AddRequestButton.Visibility = Visibility.Visible;
                this.UpdateRequestButton.Visibility = Visibility.Visible;
                this.DeleteRequestButton.Visibility = Visibility.Visible;
                this.ShowAllButton.Visibility = Visibility.Visible;
                this.SignOutButton.Visibility = Visibility.Visible;
                //this.privatenameinput.Clear;
                //this.familyenameinput.Clear;
            }
            
        }

        private void cancelbutton_Click(object sender, RoutedEventArgs e)
        {
            this.privatenameinput.Visibility = Visibility.Hidden;
            this.familyenameinput.Visibility = Visibility.Hidden;
            this.showbutton.Visibility = Visibility.Hidden;
            this.alllabal.Visibility = Visibility.Hidden;
            this.cancelbutton.Visibility = Visibility.Hidden;

            this.AddRequestButton.Visibility = Visibility.Visible;
            this.UpdateRequestButton.Visibility = Visibility.Visible;
            this.DeleteRequestButton.Visibility = Visibility.Visible;
            this.ShowAllButton.Visibility = Visibility.Visible;
            this.SignOutButton.Visibility = Visibility.Visible;
        }

        private void BackButton2_Click(object sender, RoutedEventArgs e)
        {
            this.BackButton2.Visibility = Visibility.Hidden;
            this.scrollview1.Visibility = Visibility.Hidden;
            this.scrollview1.Visibility = Visibility.Collapsed;
            this.b.Visibility = Visibility.Hidden;


            this.AddRequestButton.Visibility = Visibility.Visible;
            this.UpdateRequestButton.Visibility = Visibility.Visible;
            this.DeleteRequestButton.Visibility = Visibility.Visible;
            this.ShowAllButton.Visibility = Visibility.Visible;
            this.SignOutButton.Visibility = Visibility.Visible;

            
        }
    }
}
