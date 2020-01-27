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

namespace PLWPF.AdminFolder.Hosting_Unit
{
    /// <summary>
    /// Interaction logic for HUbyCritiriaForAdmin.xaml
    /// </summary>
    public partial class HUbyCritiriaForAdmin : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<BE.HostingUnit> unitList = new List<BE.HostingUnit>();
        public HUbyCritiriaForAdmin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//pools
        {
            scrollview1 = new ScrollViewer();
            long notreallykey = 0;
            try
            {
                unitList = bl.allUnitsWithPools();

                foreach (BE.HostingUnit item in unitList)
                {
                    HUuserCuntrol gruc = new HUuserCuntrol(item, notreallykey);
                    b.Children.Add(gruc);
                }

                scrollview1.Content = b;
            }
            catch (Exception)
            {
                MessageBox.Show("no hosting units fit critiria");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//jaccuzzis
        {
            scrollview1 = new ScrollViewer();
            long notreallykey = 0;
            try
            {
                unitList = bl.allUnitsWithJaccuzzis();

                foreach (BE.HostingUnit item in unitList)
                {
                    HUuserCuntrol gruc = new HUuserCuntrol(item, notreallykey);
                    b.Children.Add(gruc);
                }

                scrollview1.Content = b;
            }
            catch (Exception)
            {
                MessageBox.Show("no hosting units fit critiria");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//gardens
        {
            scrollview1 = new ScrollViewer();
            long notreallykey = 0;
            try
            {
                unitList = bl.allUnitsWithGardens();

                foreach (BE.HostingUnit item in unitList)
                {
                    HUuserCuntrol gruc = new HUuserCuntrol(item, notreallykey);
                    b.Children.Add(gruc);
                }

                scrollview1.Content = b;
            }
            catch (Exception)
            {
                MessageBox.Show("no hosting units fit critiria");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)//children attractions
        {
            scrollview1 = new ScrollViewer();
            long notreallykey = 0;
            try
            {
                unitList = bl.allUnitsWithchildrensattractions();

                foreach (BE.HostingUnit item in unitList)
                {
                    HUuserCuntrol gruc = new HUuserCuntrol(item, notreallykey);
                    b.Children.Add(gruc);
                }

                scrollview1.Content = b;
            }
            catch (Exception)
            {
                MessageBox.Show("no hosting units fit critiria");
            }
        }

        private void BackB_Click(object sender, RoutedEventArgs e)
        {
            Window win = new AdminHUfunctions();
            win.Show();
            this.Close();
        }
    }
}
