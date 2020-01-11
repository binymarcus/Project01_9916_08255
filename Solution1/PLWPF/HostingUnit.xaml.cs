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
    /// Interaction logic for HostingUnit.xaml
    /// </summary>
    public partial class HostingUnit : Window
    {
        public HostingUnit()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window AddUnitWindow = new AddUnit();
            AddUnitWindow.Show();
            this.Close();
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Window UpdateUnitWindow = new UpdateDeleteBy();
            UpdateUnitWindow.Show();
            this.Close();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Window DeleteUnitWindow = new UpdateDeleteBy();
            DeleteUnitWindow.Show();
            this.Close();
        }
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window mWindow = new MainWindow();
            mWindow.Show();
            this.Close();

        }
    }
}
