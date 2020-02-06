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

namespace PLWPF.AdminFolder.Host
{
    /// <summary>
    /// Interaction logic for numOfHUforEachHostForAdmin.xaml
    /// </summary>
    public partial class numOfHUforEachHostForAdmin : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<BE.Host> unitList = new List<BE.Host>();
        public numOfHUforEachHostForAdmin()
        {
            InitializeComponent();
            if (hebEnglish.hebrew)
                hebChange();
        }
        private void hebChange()
        {
            Title = "מספר יחידות אירוח לכל מאחר";
            head.Watermark = "הכנס מספר יחידות אירוח למציאה";
            showB.Content = "הראה";
            backB.Content = "חזור";
        }
        private void backB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void showB_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
