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
using System.Xml.Linq;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for HostingUnit.xaml
    /// </summary>
    public partial class HostWindow : Window
    {
        string user;
       XElement HostRoot = new XElement("hostsInfo");
        IBL bl = FactoryBL.getIBL();
        public HostWindow()
        {
            InitializeComponent();
        }
        public HostWindow(string username)
        {
            InitializeComponent();
            user = username;
        }
        private void addUnitButton_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
            BE.Host host = getHost();
            Window addUnitWindow = new AddUnit(host);
            addUnitWindow.Show();
            this.Close();

        }
        private void updateUnitButton_Click(object sender, RoutedEventArgs e)
        {
            Window updateUnitWindow = new UpdateDeleteBy();
            updateUnitWindow.Show();
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
        private BE.Host getHost()
        {
                var v = (from use in HostRoot.Elements()
                         where use.Element("username").Value == user
                         select new BE.Host()
                         {
                             PrivateName1 = use.Element("Host").Element("firstName").Value,
                             FamilyName1 = use.Element("Host").Element("lastName").Value,
                             MailAddress1 = use.Element("Host").Element("Email").Value,
                             PhoneNumber1 = int.Parse(use.Element("Host").Element("PhoneNumber").Value),
                             BankAccountNumber1 = int.Parse(use.Element("Host").Element("BankAccountNumber").Value),
                             CollectionClearance1 = bool.Parse(use.Element("Host").Element("Clearance").Value)
                         }).FirstOrDefault();
            bl.AddHost(v);
            return v;

        }
        private void LoadData()
        {
            try
            {
                HostRoot = XElement.Load("@HostXml.xml");
            }
            catch
            {

                throw new Exception("File upload problem");
            }
        }
    }
}
