using PLWPF.AdminFolder;
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
using PLWPF.AdminFolder.Hosting_Unit;
using BL;


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AdminHUfunctions.xaml
    /// </summary>
    public partial class AdminHUfunctions : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<BE.HostingUnit> unitList = new List<BE.HostingUnit>();
        public AdminHUfunctions()
        {
            InitializeComponent();
            if (hebEnglish.hebrew)
                hebChange();
        }
        private void hebChange()
        {
            GetAllHU.Content = "הבא כל יחידות האירוח";
            Title = "אדמיןיחידותאירוח";
            getcritiria.Content = "הבא על פי קרטיריה";
            calc.Content = "חשב מספר יחידות אירוח";
            BackButton.Content = "חזור";
        }
        private void GetAllHU_Click(object sender, RoutedEventArgs e)
        {
            Window hu = new showAllUnits();
            hu.Show();
            this.Close();
             
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window adminMainWindow = new AdminMainWindow();
            adminMainWindow.Show();
            this.Close();
        }

        private void getcritiria_Click(object sender, RoutedEventArgs e)
        {
            Window hu = new HUbyCritiriaForAdmin();
            hu.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<BE.HostingUnit> L = new List<BE.HostingUnit>();
            int amount = 0;
            try
            {
                L = bl.GetAllHostingUnits();
                amount = L.Count();
                MessageBox.Show("number of guest requests in the system:" + amount);
            }
            catch
            {
                MessageBox.Show("error!");
            }
        }
    }
}
