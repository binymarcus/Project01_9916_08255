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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for GRUserControl.xaml
    /// </summary>
    public partial class GRUserControl : UserControl
    {
        private BE.GuestRequest gr;
        public GRUserControl(BE.GuestRequest gruc)
        {
            InitializeComponent();
            this.ByNameUpdateDetailsGrid.DataContext = gruc;
            gr = gruc;
        }

        private void entryDate1TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            entryDate1TextBox.Text = gr.EntryDate1.ToString("dd/MM/yyyy");
        }

        private void releaseDate1TextBox_Loaded(object sender, RoutedEventArgs e)
        {
            releaseDate1TextBox.Text = gr.ReleaseDate1.ToString("dd/MM/yyyy");
        }
    }
}
