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
        public showAllHUWindow(long key1)
        {
            InitializeComponent();
            //gets a guest request and uses function to get a list with all HU by Host name and then shows all of them
            L = bl.GetAllHostingUnitsByHostKey(key1);
            hostingUnitListView.DataContext = L;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
        }
    }
}
