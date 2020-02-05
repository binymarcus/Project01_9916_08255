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
            if (hebEnglish.hebrew)
                hebChange();
            this.ByNameUpdateDetailsGrid.DataContext = gruc;
            gr = gruc;
        }
        private void hebChange()
        {
            pname.Content = "שם פרטי";
            fname.Content = "שם משפחה";
            edate.Content = "תאריך כניסה";
            rdate.Content = "תאריך יציאה";
            garden.Content = "גינה";
            jac.Content = "גקוזי";
            childA.Content = "אטרקציות לילדים";
            children.Content = "ילדים";
            adults.Content = "מבוגרים";
            mail.Content = "מייל";
            pool.Content = "בריכה";
            area.Content = "איזור";
            sub.Content = "תת איזור";
            type.Content = "סוג";
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
