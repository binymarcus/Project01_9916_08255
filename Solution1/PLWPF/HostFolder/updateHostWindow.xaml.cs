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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for updateHostWindow.xaml
    /// </summary>
    public partial class updateHostWindow : Window
    {
        private BE.HostingUnit unit;
        IBL bl = FactoryBL.getIBL();
        public updateHostWindow()
        {
            InitializeComponent();
            
        }

        public updateHostWindow(BE.HostingUnit uni)
        {
            this.unit = uni;
            this.DataContext = unit;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {

                int error = 0;
                try
                {
                if (hostingUnitName1TextBox.Text == "" && error == 0)//need to fill out name (we dont care if his name is a number)
                {
                    MessageBox.Show("need to fill out  name");
                    error++;
                }
                else if (commission1TextBox.Text == "" && error == 0)
                {
                    MessageBox.Show("need to fill out comission");
                    error++;
                }

                

                if (error == 0)
                {
                    bl.UpdateHostingUnit(unit);
                    MessageBox.Show("Guest Request updated, Key: " + unit.HostingUnitKey1);
                    Window hWindow = new HostWindow();
                    hWindow.Show();
                    this.Close();
                }
            }
                catch (FormatException)
                {

                    MessageBox.Show("Please check your input and try again");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            
        }
    }
}
