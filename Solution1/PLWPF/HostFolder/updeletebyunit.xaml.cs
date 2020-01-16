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
    public partial class updeletebyunit : Window
    {
        BE.HostingUnit unit;
        //BL.IBL bl;
        IBL bl = FactoryBL.getIBL();
        public updeletebyunit()
        {
            InitializeComponent();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.UpdatePrivateNameTextBox.Text != ""  && this.UpdateKey.Text != "")
            {
                MessageBox.Show("please enter only one field, byname or by key.");
                Window UpdateDeleteByWindow = new UpdateDeleteBy();
                UpdateDeleteByWindow.Show();
                this.Close();
            }
            else if ( this.UpdatePrivateNameTextBox.Text != "")
            {
                try
                {
                    //sends to a window with a scroll box and then the user updates the gs he wants to update
                    Window UpdateByNameChooseWindow = new updateHostWindow(bl.GetHostingUnitByName(this.UpdatePrivateNameTextBox.Text));
                    UpdateByNameChooseWindow.Show();
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("units for this host don't exist");
                }
            }
            else if (this.UpdateKey.Text != "")
            {
                try
                {
                    Window UpdateHostWindow = new updateHostWindow(bl.GetHostingUnitByKey(long.Parse(this.UpdateKey.Text)));
                    UpdateHostWindow.Show();
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("unit with this key does not exist");
                }

            }
            else
            {
                MessageBox.Show("unit does not exist, " +
                   "or you entered info into wrong fields");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.DeletePrivateNameTextBox.Text != "" && this.DeleteKeyTextBox.Text != "")
            {
                MessageBox.Show("please enter only one field, byname or by key.");
                Window UpdateDeleteByWindow = new updeletebyunit();
                UpdateDeleteByWindow.Show();
                this.Close();
            }

            else if (this.DeletePrivateNameTextBox.Text != "")
            {
                 try
                 {
                     unit = bl.GetHostingUnitByName(this.DeletePrivateNameTextBox.Text);
                     long tempkey = unit.HostingUnitKey1;
                     bl.DeleteHostingUnit(unit);
                     MessageBox.Show("Unit deleted, Key: " + tempkey);
                     Window GuestRequestWindow = new HostWindow();
                     GuestRequestWindow.Show();
                     this.Close();
                 }
                 catch(Exception)
                 {
                     MessageBox.Show("unit does not exist");
                     Window GuestRequestWindow = new HostWindow();
                     GuestRequestWindow.Show();
                     this.Close();
                 }               

            }
            else if (this.DeleteKeyTextBox.Text != "")
            {
                try
                {
                    unit = bl.GetHostingUnitByKey(long.Parse(this.DeleteKeyTextBox.Text));
                    long tempkey = unit.HostingUnitKey1;
                    bl.DeleteHostingUnit(unit);
                    MessageBox.Show("unit deleted, Key: " + tempkey);
                    Window hostWindow = new HostWindow();
                    hostWindow.Show();
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("unit does not exist");
                    Window GuestRequestWindow = new HostWindow();
                    GuestRequestWindow.Show();
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("unit does not exist, " +
                    "or you entered info into wrong fields");
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window hosttWindow = new HostWindow();
            hosttWindow.Show();
            this.Close();
        }
    }
}
