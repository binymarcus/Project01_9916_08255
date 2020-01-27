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

namespace PLWPF.AdminFolder.GuestRequest
{
    /// <summary>
    /// Interaction logic for GRbyCritiriaForAdmin.xaml
    /// </summary>
    public partial class GRbyCritiriaForAdmin : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<BE.GuestRequest> grList = new List<BE.GuestRequest>();

        public GRbyCritiriaForAdmin()
        {
            InitializeComponent();
        }

        private void BackB_Click(object sender, RoutedEventArgs e)
        {
            Window win = new AdminGRfunctions();
            win.Show();
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
                    GRUserControl gruc = new GRUserControl(item);
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
                    GRUserControl gruc = new GRUserControl(item);
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
                    GRUserControl gruc = new GRUserControl(item);
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
                    GRUserControl gruc = new GRUserControl(item);
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
                    GRUserControl gruc = new GRUserControl(item);
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
                    GRUserControl gruc = new GRUserControl(item);
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
                    GRUserControl gruc = new GRUserControl(item);
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
                    GRUserControl gruc = new GRUserControl(item);
                    b.Children.Add(gruc);
                }

                scrollview1.Content = b;
            }
            catch (Exception)
            {
                MessageBox.Show("no guest requests fit critiria");
            }
        }
    }
}
