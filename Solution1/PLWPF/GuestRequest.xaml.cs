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
            Window mWindow = new MainWindow();
            mWindow.Show();
            this.Close();

        }

        private void ShowAllButton_Click(object sender, RoutedEventArgs e)
        {
            this.privatenameinput.Visibility = Visibility.Visible;
            this.familyenameinput.Visibility = Visibility.Visible;
            this.showbutton.Visibility = Visibility.Visible;
            this.cancelbutton.Visibility = Visibility.Visible;
            this.ShowAllButton.Visibility = Visibility.Hidden;
            this.BackButton.Visibility = Visibility.Hidden;

        }

        private void showbutton_Click(object sender, RoutedEventArgs e)
        {

            this.privatenameinput.Visibility = Visibility.Hidden;
            this.familyenameinput.Visibility = Visibility.Hidden;
            this.showbutton.Visibility = Visibility.Hidden;
            this.cancelbutton.Visibility = Visibility.Hidden;

            this.AddRequestButton.Visibility = Visibility.Hidden;
            this.UpdateRequestButton.Visibility = Visibility.Hidden;
            this.DeleteRequestButton.Visibility = Visibility.Hidden;
            this.ShowAllButton.Visibility = Visibility.Hidden;
            this.BackButton.Visibility = Visibility.Hidden;

            this.BackButton2.Visibility = Visibility.Visible;
            this.scrollview1.Visibility = Visibility.Visible;
            this.b.Visibility = Visibility.Visible;
            this.b.Visibility = Visibility.Visible;

            guestList = bl.GetallGuestRequestByName(this.privatenameinput.Text, this.familyenameinput.Text);

            scrollview1 = new ScrollViewer();

            foreach (BE.GuestRequest item in guestList)
            {
                TextBox text = new TextBox();
                GRUserControl gruc = new GRUserControl(item);
                b.Children.Add(gruc);
                b.Children.Add(text);

            }

            scrollview1.Content = b;
        }

        private void cancelbutton_Click(object sender, RoutedEventArgs e)
        {
            this.privatenameinput.Visibility = Visibility.Hidden;
            this.familyenameinput.Visibility = Visibility.Hidden;
            this.showbutton.Visibility = Visibility.Hidden;
            this.cancelbutton.Visibility = Visibility.Hidden;
            this.ShowAllButton.Visibility = Visibility.Visible;
            this.BackButton.Visibility = Visibility.Visible;
        }

        private void BackButton2_Click(object sender, RoutedEventArgs e)
        {
            this.AddRequestButton.Visibility = Visibility.Visible;
            this.UpdateRequestButton.Visibility = Visibility.Visible;
            this.DeleteRequestButton.Visibility = Visibility.Visible;
            this.ShowAllButton.Visibility = Visibility.Visible;
            this.BackButton.Visibility = Visibility.Visible;

            this.BackButton2.Visibility = Visibility.Hidden;
            this.scrollview1.Visibility = Visibility.Hidden;
            this.b.Visibility = Visibility.Hidden;
            this.b.Visibility = Visibility.Hidden;
        }
    }
}
