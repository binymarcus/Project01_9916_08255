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
            guest.FamilyName1 = this.FNameTextBox.Text;
            guest.MailAddress1 = this.EmailtextBox.Text;
            //need to finsih adding all the properties
            bl = BL.FactoryBL.getIBL();
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.AddGuestRequest(guest);
                this.GuestRequestDetailsGrid.DataContext = guest;
                //this.PNameTextBox.ClearValue(TextBox.TextProperty);
                //  this.FNameTextBox.ClearValue(TextBox.TextProperty);
                MessageBox.Show("Guest Request Added, Key:" + guest.GuestRequestKey1);
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

    }
}
