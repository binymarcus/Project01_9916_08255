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

        public PickGSforOrder()
        {
            InitializeComponent();
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
