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
using BE;

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
        string username;
        public AddUnit()
        {
            InitializeComponent();
        }
        private void hebChange()
        {
            Title = "הוסףיחידה";
            Add.Content = "הוסף";
            Cancel.Content = "בטל";
            commission.Content = "עמלה";
            name.Content = "שם יחידת הארוח";
            pool.Content = "בריכה";
            garden.Content = "גינה";
            jac.Content = "גקוזי";
            childA.Content = "אטרקציות לילדים";
            area.Content = "איזור ליחידת אירוח";
            hostingUnitNameTextBox.Watermark = "נא להכניס שם ליחידת אירוח";
            commission1TextBox.Watermark = "נא להכניס עמלה";
        }

        public AddUnit(BE.Host host,string user)
        {
            InitializeComponent();
            if (hebEnglish.hebrew)
                hebChange();
            owner = host;
            unit = new BE.HostingUnit();
            this.addunit.DataContext = unit;
            username = user;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            int commish;
            int numVal = Int32.Parse(commission1TextBox.Text);
            try
            {
                unit.Owner1 = new BE.Host();
                unit.Owner1 = owner;
                if (hostingUnitNameTextBox.Text == "")
                {
                    MessageBox.Show("must enter a HostingUnit name!");
                    hostingUnitNameTextBox.Clear();
                    hostingUnitNameTextBox.Focus();
                }
                else if (commission1TextBox.Text == "" || (!(int.TryParse(commission1TextBox.Text, out commish)))||(numVal<=0))
                {
                    MessageBox.Show("must enter HostingUnit Commision!");
                    commission1TextBox.Clear();
                    commission1TextBox.Focus();
                }
                else if(Area1.Text == "Please Select")
                {
                    MessageBox.Show("must enter HostingUnit Area!");
                    Area1.Focus();
                }
                else
                {
                    string selected1 = Area1.SelectedItem.ToString();
                    selected1 = selected1.Substring(selected1.IndexOf(' ')); 
                    
                    if (selected1 == " North")
                    {
                        unit.AreaOfHostingUnit = BEEnum.Area.North;
                    }
                    else if (selected1 == " South")
                    {
                        unit.AreaOfHostingUnit = BEEnum.Area.South;
                    }
                    else if (selected1 == " Center")
                    {
                        unit.AreaOfHostingUnit = BEEnum.Area.Center;
                    }
                    else if (selected1 == " Jerusalem")
                    {
                        unit.AreaOfHostingUnit = BEEnum.Area.Jerusalem;
                    }

                    bl.AddHostingUnit(unit);
                    MessageBox.Show("Hosting Unit Added, Key:" + unit.HostingUnitKey1);
                    this.DataContext = unit;
                    Window HostingUnitWindow = new HostWindow(username);
                    HostingUnitWindow.Show();
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
            Window HostingUnitWindow = new HostWindow(username);
            HostingUnitWindow.Show();
            this.Close();
        }

        private void commission1TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Area1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
