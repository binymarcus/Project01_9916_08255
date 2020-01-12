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
    /// Interaction logic for AddGuestrequest.xaml
    /// </summary>
    public partial class AddGuestRequest : Window
    {
        BE.GuestRequest guest;
        BL.IBL bl;
        public AddGuestRequest()
        {
            InitializeComponent();
            guest = new BE.GuestRequest();
            this.GuestRequestDetailsGrid.DataContext = guest;
            //guest.FamilyName1 = this.familyName1TextBox.Text;
            //need to finsih adding all the properties
            bl = BL.FactoryBL.getIBL();
            
        }
       
        
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.AddGuestRequest(guest);
                MessageBox.Show("Guest Request Added, Key:" + guest.GuestRequestKey1);
                this.GuestRequestDetailsGrid.DataContext = guest;
                Window GuestRequestWindow = new GuestRequest();
                GuestRequestWindow.Show();

                this.Close();
            }

            catch (FormatException)
            {

                MessageBox.Show("Please check your input and try again");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_4(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_5(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged_6(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        
        private void btOrder_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window guestRequestWindow = new GuestRequest();
            guestRequestWindow.Show();
            this.Close();
        }

        private void numOfAdults_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource guestRequestViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("guestRequestViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // guestRequestViewSource.Source = [generic data source]
        }

        private void adults1TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void privateName1TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
