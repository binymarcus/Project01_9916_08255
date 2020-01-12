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
    /// Interaction logic for AddUnit.xaml
    /// </summary>
    public partial class AddUnit : Window
    {
        BE.HostingUnit unit;
        BL.IBL bl;
        public AddUnit()
        {
            InitializeComponent();
            unit = new BE.HostingUnit();
            this.DataContext = unit;
            bl = BL.FactoryBL.getIBL();
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.AddHostingUnit(unit);
                MessageBox.Show("Hosting Unit Added, Key:" + unit.HostingUnitKey1);
                this.DataContext = unit;
                Window HostingUnitWindow = new HostingUnit();
                HostingUnitWindow.Show();
                this.Close();
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


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Window HostingUnitWindow = new HostingUnit();
            HostingUnitWindow.Show();
            this.Close();
        }
    }
}
