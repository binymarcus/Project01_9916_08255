using BL;
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

namespace PLWPF.AdminFolder
{
    /// <summary>
    /// Interaction logic for showAllUnits.xaml
    /// </summary>
    public partial class showAllUnits : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<BE.HostingUnit> unitList = new List<BE.HostingUnit>();
        public showAllUnits()
        {
            InitializeComponent();
            scrollview1 = new ScrollViewer();
            long notreallykey = 0;
            try
            {
                unitList = bl.GetAllHostingUnits();

                foreach (BE.HostingUnit item in unitList)
                {
                    HUuserCuntrol gruc = new HUuserCuntrol(item, notreallykey);
                    gruc.HUChoose.Visibility = Visibility.Hidden;
                    b.Children.Add(gruc);
                }

                scrollview1.Content = b;
            }
            catch (Exception)
            {
                textBlock.Visibility = Visibility.Visible;

            }
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window GRMain = new AdminHUfunctions();
            GRMain.Show();
            this.Close();
        }
    }
}
