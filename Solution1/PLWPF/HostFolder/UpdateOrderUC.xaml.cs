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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using BE;

namespace PLWPF.HostFolder
{
    /// <summary>
    /// Interaction logic for UpdateOrderUC.xaml
    /// </summary>
    public partial class UpdateOrderUC : UserControl
    {
        IBL bl = FactoryBL.getIBL();
        Order or;
        string username;
        long hostkey;
        string selected1;
        public UpdateOrderUC()
        {
            InitializeComponent();
        }
        public UpdateOrderUC(BE.Order orderuc,string user)
        {
            InitializeComponent();
            or = orderuc;
            hostkey = bl.GetHostingUnitByKey(orderuc.HostingUnitKey1).Owner1.HostKey1;
            or.hostKey1 = hostkey;
            grid1.DataContext = or;
            username = user;
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            selected1 = status1ComboBox.SelectedItem.ToString();
            selected1 = selected1.Substring(selected1.IndexOf(' '));
            if (selected1 == " dealMade")
            {
                or.Status1 = BEEnum.Status.dealMade;
                or.OrderDate1 = DateTime.Now;
                try
                {
                    bl.UpdateOrder(or);
                }
                catch
                {
                    MessageBox.Show("this should work");
                }
                BE.GuestRequest guesty = bl.GetGuestRequestByKey(Convert.ToInt64(guestRequestKey1Label.Content));
                guesty.status1 = BEEnum.Status.dealMade;
                try
                {
                    bl.UpdateGuestRequest(guesty);

                }
                catch
                {
                    MessageBox.Show("this should work2");
                }
            }          
            
            Window HostWindow = new HostWindow(username);
            HostWindow.Show();
           
        }

        private void status1ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
