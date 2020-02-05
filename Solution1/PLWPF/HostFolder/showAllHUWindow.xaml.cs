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
using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for showAllHUWindow.xaml
    /// </summary>
    public partial class showAllHUWindow : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<HostingUnit> L = new List<HostingUnit>();
        long hostkey;
        string username;
        public showAllHUWindow(long key1,string user)
        {
            InitializeComponent();
            if (hebEnglish.hebrew)
                hebChange();
            //gets a guest request and uses function to get a list with all HU by Host name and then shows all of them
            username = user;
            try
            {
                L = bl.GetAllHostingUnitsByHostKey(key1);
                hostingUnitListView.DataContext = L;
                hostkey = key1;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void hebChange()
        {
            Title = "הראהכליחידותאירוח";
            BackButton.Content = "חזור";
            areaOfHostingUnitColumn.Header = "איזור יחידת האירוח";
            commission1Column.Header = "גבייה";
            hasChildrensAttractions1Column.Header = "יש אטרקציות לילדים";
            hasGarden1Column.Header = "יש גינה";
            hasJaccuzzi1Column.Header = "יש גקוזי";
            hasPool1Column.Header = "יש בריכה";
            hostingUnitName1Column.Header = "שם יחידת האירוח";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window hosty = new HostWindow(username);
            hosty.Show();
            this.Close();
        }

        private void hostingUnitListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
