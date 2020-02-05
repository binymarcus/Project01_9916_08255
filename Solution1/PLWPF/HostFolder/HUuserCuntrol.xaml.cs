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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for HUuserCuntrol.xaml
    /// </summary>
    public partial class HUuserCuntrol : UserControl
    {
        IBL bl = FactoryBL.getIBL();
        //List<HostingUnit> L = new List<HostingUnit>();
        long hostkey1;
        public HUuserCuntrol()
        {
            InitializeComponent();
            if (hebEnglish.hebrew)
                hebChange();
        }
        private void hebChange()
        {
            hukey.Content = "מספר יחידת אירוח";
            huname.Content = "שם יחידת אירוח";
            ahu.Content = "איזור יחידת אירוח";
            commis.Content = "גבייה";
            childA.Content = "אטרקציות לילדים";
            pool.Content = "יש בריכה";
            jac.Content = "גקוזי";
            garden.Content = "גינה";
            HUChoose.Content = "תבחר אותי";
        }
        public HUuserCuntrol(BE.HostingUnit gruc, long hostkey)
        {
            InitializeComponent();
            hostkey1 = hostkey;
            grid1.DataContext = gruc;
        }

        private void HUChoose_Click(object sender, RoutedEventArgs e)
        {
            Window pickGS = new PickGSforOrder(Convert.ToInt64(hostingUnitKey1Label.Content),hostkey1);
            pickGS.Show();
            //send the hosting unit info to the window with the list of gr.
            //var myWindow = Window.GetWindow(this);
            //myWindow.Close();
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

        

    }
}
