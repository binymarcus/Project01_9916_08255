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
        public UpdateOrderUC()
        {
            InitializeComponent();
        }
        public UpdateOrderUC(BE.Order orderuc,string user)
        {
            InitializeComponent();
            or = orderuc;
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
            bl.UpdateOrder(or);
            Window HostWindow = new HostWindow(username);
            HostWindow.Show();
        }

        private void status1ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(status1ComboBox.ToString() == "mailSent")
            {
                or.Status1 = BEEnum.Status.mailSent;
                try
                {
                    bl.UpdateOrder(or);
                }
                catch
                {
                    MessageBox.Show("cannot update order");
                }
            }
            if (status1ComboBox.ToString() == "dealMade")
            {
                or.Status1 = BEEnum.Status.dealMade;
                or.OrderDate1 = DateTime.Now;
                try
                {
                    bl.UpdateOrder(or);
                }
                catch
                {
                    MessageBox.Show("cannot update order");
                }
            }
        }
    }
}
