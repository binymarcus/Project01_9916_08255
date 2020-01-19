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
    /// Interaction logic for ShowAllHosts.xaml
    /// </summary>
    public partial class ShowAllHosts : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<BE.Host> hostList = new List<BE.Host>();
        public ShowAllHosts()
        {
            InitializeComponent();
            scrollview1 = new ScrollViewer();

            try
            {
                hostList = bl.GetAllHosts();



                foreach (BE.Host item in hostList)
                {
                    GRUserControl gruc = new GRUserControl(item);
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
            Window GRMain = new AdminGRfunctions();
            GRMain.Show();
            this.Close();
        }
    }
}
