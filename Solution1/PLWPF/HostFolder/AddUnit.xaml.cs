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
    /// Interaction logic for AddUnit.xaml
    /// </summary>
    public partial class AddUnit : Window
    {
        BE.HostingUnit unit;
         IBL bl = BL.FactoryBL.getIBL();
        BE.Host owner;
        public AddUnit()
        {
            InitializeComponent();
            unit = new BE.HostingUnit();
        }

        public AddUnit(BE.Host host)
        {
            InitializeComponent();
            owner = host;
            unit = new BE.HostingUnit();
            this.addunit.DataContext = unit;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                unit.Owner1 = new BE.Host();
                unit.Owner1 = owner;
                bl.AddHostingUnit(unit);
                MessageBox.Show("Hosting Unit Added, Key:" + unit.HostingUnitKey1);
                this.DataContext = unit;
                Window HostingUnitWindow = new HostWindow();
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
            Window HostingUnitWindow = new HostWindow();
            HostingUnitWindow.Show();
            this.Close();
        }
    }
}
