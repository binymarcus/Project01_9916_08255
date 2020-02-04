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
using PLWPF.GRfolder;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for UpdateByNameChoose.xaml
    /// </summary>
    public partial class UpdateByNameChoose : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<BE.GuestRequest> guestList = new List<BE.GuestRequest>();
        public UpdateByNameChoose(string pname, string fname)
        {
            InitializeComponent();
            if (hebEnglish.hebrew)
                hebChange();
            guestList = bl.GetallGuestRequestByName( pname, fname);

            scrollview1 = new ScrollViewer();

            foreach (BE.GuestRequest item in guestList)
            {
                GRUCforUpdate gruc = new GRUCforUpdate(item);
                b.Children.Add(gruc);
            }

            scrollview1.Content = b;
        }
        private void hebChange()
        {
            updatebyNameupdateButton.Content = "עדכן";
            BackButton.Content = "חזור";
        }
      
        private void updatebyNameupdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (BE.GuestRequest item in guestList)
                {
                    bl.UpdateGuestRequest(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("update error");
            }
            Window GRMain = new GuestRequest();
            GRMain.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window GRMain = new GuestRequest();
            GRMain.Show();
            this.Close();
        }
    }
}
    

