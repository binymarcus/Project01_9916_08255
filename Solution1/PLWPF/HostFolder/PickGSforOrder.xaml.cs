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
using BE;
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for PickGSforOrder.xaml
    /// </summary>
    public partial class PickGSforOrder : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<BE.GuestRequest> grList = new List<BE.GuestRequest>();
        long key1;
        long hostkey1;

        private void hide()
        {
            poolGR.Visibility =
              jaccuzziGR.Visibility =
              gardenGR.Visibility =
              childrenGR.Visibility =
              centerGR.Visibility =
              southGR.Visibility =
              northGR.Visibility =
              jemGR.Visibility =
              allGR.Visibility = Visibility.Hidden;
        }
        public PickGSforOrder()
        {
            InitializeComponent();
            if (hebEnglish.hebrew)
                hebChange();
        }
        private void hebChange()
        {
            poolGR.Content = "כל הבקשות עם בריכה";
            jaccuzziGR.Content = "כל הבקשות עם גקוזי";
            southGR.Content = "כל הבקשות דרום";
            northGR.Content = "כל הבקשות בצפון";
            centerGR.Content = "כל הבקשות במרכז";
            jemGR.Content = "כל הבקשות בירושלים";
            allGR.Content = "כל הבקשות";
            childrenGR.Content = "כל הבקשות עם אטרקציות לילדים";
            gardenGR.Content = "כל הבקשות עם גינה";
            BackB.Content = "חזור";
            header.Content = "היחידת אירוח שבחרת";
            hukey.Content = "מספר יחידת אירוח";
            huname.Content = "שם יחידת אירוח";
            area.Content = "איזור יחידת האירוח";
            commis.Content = "גבייה";
            garden.Content = "יש גינה?";
            hca.Content = "יש אטרקציות לילדים?";
            jac.Content = "יש גקוזי?";
            pool.Content = "יש בריכה?";
            Title = "תבחרבקשהלהזמנה";
                }
        public PickGSforOrder(long hoeunitkey,long hostkey)
        {
            InitializeComponent();
            key1 = hoeunitkey;
            hostkey1 = hostkey;
            HostingUnit hoeunit;
            hoeunit = bl.GetHostingUnitByKey(hoeunitkey);
            grid2.DataContext = hoeunit;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
        }

        private void BackB_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void childrenGR_Click(object sender, RoutedEventArgs e)
        {
            hide();
            scrollview1 = new ScrollViewer();
            try
            {
                grList = bl.allGRsWithchildrensattractions();

                foreach (BE.GuestRequest item in grList)
                {
                    GRuserControlForAddOrder gruc = new GRuserControlForAddOrder(item, key1, hostkey1);
                    b.Children.Add(gruc);
                }

                scrollview1.Content = b;
            }
            catch (Exception)
            {
                MessageBox.Show("no guest requests fit critiria");
            }
        }

        private void gardenGR_Click(object sender, RoutedEventArgs e)
        {
            hide();
            scrollview1 = new ScrollViewer();
            try
            {
                grList = bl.allGRsWithGardens();

                foreach (BE.GuestRequest item in grList)
                {
                    GRuserControlForAddOrder gruc = new GRuserControlForAddOrder(item, key1, hostkey1);
                    b.Children.Add(gruc);
                }

                scrollview1.Content = b;
            }
            catch (Exception)
            {
                MessageBox.Show("no guest requests fit critiria");
            }
        }

        private void jaccuzziGR_Click(object sender, RoutedEventArgs e)
        {
            hide();
            scrollview1 = new ScrollViewer();
            try
            {
                grList = bl.allGRsWithJaccuzzis();

                foreach (BE.GuestRequest item in grList)
                {
                    GRuserControlForAddOrder gruc = new GRuserControlForAddOrder(item, key1, hostkey1);
                    b.Children.Add(gruc);
                }

                scrollview1.Content = b;
            }
            catch (Exception)
            {
                MessageBox.Show("no guest requests fit critiria");
            }
        }

        private void poolGR_Click(object sender, RoutedEventArgs e)
        {
            hide();

            scrollview1 = new ScrollViewer();
            try
            {
                grList = bl.allGRsWithPools();

                foreach (BE.GuestRequest item in grList)
                {
                    GRuserControlForAddOrder gruc = new GRuserControlForAddOrder(item, key1, hostkey1);
                    b.Children.Add(gruc);
                }

                scrollview1.Content = b;
            }
            catch (Exception)
            {
                MessageBox.Show("no guest requests fit critiria");
            }
        }

        private void southGR_Click(object sender, RoutedEventArgs e)
        {
            hide();
            scrollview1 = new ScrollViewer();
            try
            {
                grList = bl.allGRsInSouth();

                foreach (BE.GuestRequest item in grList)
                {
                    GRuserControlForAddOrder gruc = new GRuserControlForAddOrder(item, key1, hostkey1);
                    b.Children.Add(gruc);
                }

                scrollview1.Content = b;
            }
            catch (Exception)
            {
                MessageBox.Show("no guest requests fit critiria");
            }
        }

        private void northGR_Click(object sender, RoutedEventArgs e)
        {
            hide();
            scrollview1 = new ScrollViewer();
            try
            {
                grList = bl.allGRsInNorth();

                foreach (BE.GuestRequest item in grList)
                {
                    GRuserControlForAddOrder gruc = new GRuserControlForAddOrder(item, key1, hostkey1);
                    b.Children.Add(gruc);
                }

                scrollview1.Content = b;
            }
            catch (Exception)
            {
                MessageBox.Show("no guest requests fit critiria");
            }
        }

        private void centerGR_Click(object sender, RoutedEventArgs e)
        {
            hide();
            scrollview1 = new ScrollViewer();
            try
            {
                grList = bl.allGRsInCenter();

                foreach (BE.GuestRequest item in grList)
                {
                    GRuserControlForAddOrder gruc = new GRuserControlForAddOrder(item, key1, hostkey1);
                    b.Children.Add(gruc);
                }

                scrollview1.Content = b;
            }
            catch (Exception)
            {
                MessageBox.Show("no guest requests fit critiria");
            }
        }

        private void jemGR_Click(object sender, RoutedEventArgs e)
        {
            hide();
            scrollview1 = new ScrollViewer();
            try
            {
                grList = bl.allGRsInJem();

                foreach (BE.GuestRequest item in grList)
                {
                    GRuserControlForAddOrder gruc = new GRuserControlForAddOrder(item, key1, hostkey1);
                    b.Children.Add(gruc);
                }

                scrollview1.Content = b;
            }
            catch (Exception)
            {
                MessageBox.Show("no guest requests fit critiria");
            }
        }

        private void allGR_Click(object sender, RoutedEventArgs e)
        {
            hide();
            grList = bl.allAvailableGR();
            scrollview1 = new ScrollViewer();

            foreach (BE.GuestRequest item in grList)
            {
                GRuserControlForAddOrder gruc = new GRuserControlForAddOrder(item, key1, hostkey1);
                b.Children.Add(gruc);
            }

            scrollview1.Content = b;
        }
    }
}
