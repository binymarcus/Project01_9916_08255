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
    /// Interaction logic for updateHostWindow.xaml
    /// </summary>
    public partial class updateHostWindow : Window
    {
        private BE.HostingUnit unit;

        public updateHostWindow()
        {
            InitializeComponent();
            
        }

        public updateHostWindow(BE.HostingUnit uni)
        {
            this.unit = uni;
            this.DataContext = unit;
            hostingUnitKey1TextBox.IsReadOnly = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {

                int int1;
                int error = 0;
                try
                {
                    //if (hostingUnitName1TextBox.Text == "" && error == 0)//need to fill out name (we dont care if his name is a number)
                    //{
                    //    MessageBox.Show("need to fill out private name");
                    //    error++;
                    //}
                    //else if (FamilyName1TextBox.Text == "" && error == 0)//need to fill out name (we dont care if his name is a number)
                    //{
                    //    MessageBox.Show("need to fill out family name");
                    //    error++;
                    //    FamilyName1TextBox.Clear();
                    //}
                    //else if ((adults1TextBox.Text != "") && (!(int.TryParse(adults1TextBox.Text, out int1))) && (error == 0))//num of adults has to be a number
                    //{
                    //    MessageBox.Show("num of adults has to be filled with a number");
                    //    error++;
                    //    adults1TextBox.Clear();
                    //}

                    //if ((children1TextBox.Text != "") && (!(int.TryParse(children1TextBox.Text, out int1))) && (error == 0))//num of adults has to be a number
                    //{
                    //    MessageBox.Show("num of children has to be filled with a number");
                    //    error++;
                    //    children1TextBox.Clear();

                    //}

                    //if (error == 0)
                    //{
                    //    bl.UpdateGuestRequest(guest);
                    //    MessageBox.Show("Guest Request updated, Key: " + guest.GuestRequestKey1);
                    //    Window GuestRequestWindow = new GuestRequest();
                    //    GuestRequestWindow.Show();
                    //    this.Close();
                    //}
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
    }
}
