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
    /// Interaction logic for HostRegistraion.xaml
    /// </summary>
    public partial class HostRegistraion : Window
    {
        String hostPath="@HostXml.xml";
        XElement guestRoot = new XElement("guestsInfo");
        XElement hostRoot = new XElement("hostsInfo");
        public HostRegistraion()
        {
            InitializeComponent();
            LoadData();
        }
        public void saveHost()
        {
            hostRoot = new XElement("host");
            XElement username = new XElement("username", textBoxUserName.Text);
            XElement password = new XElement("password", passwordBox1.Password);
            XElement Pname = new XElement("firstName", privateName1TextBox.Text);
            XElement Fname = new XElement("lastName", familyName1TextBox.Text);
            XElement email = new XElement("Email", mailAddress1TextBox.Text);
            XElement phone = new XElement("PhoneNumber", phoneNumber1TextBox.Text);
            XElement bank = new XElement("BankAccountNumber", bankAccountNumber1TextBox.Text);
            XElement clearance = new XElement("Clearance", collectionClearance1CheckBox.IsChecked.ToString());
            XElement Host = new XElement("Host",username,password,Pname, Fname, email, phone, bank, clearance);
            hostRoot.Add(Host);
            hostRoot.Save(hostPath);
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            int int1;
            if (textBoxUserName.Text.Length == 0)
            {
                MessageBox.Show("Enter a username.");
                textBoxUserName.Focus();
            }
            else if (passwordBox1.Password.Length == 0)
            {
                MessageBox.Show("Enter a password.");
                passwordBox1.Focus();
            }
            
                else if (passwordBoxConfirm.Password.Length == 0)
            {
                MessageBox.Show("confirm your password.");
                passwordBoxConfirm.Focus();
            }
            else if (privateName1TextBox.Text.Length == 0)
            {
                MessageBox.Show("enter your private name.");
                privateName1TextBox.Focus();
            }
            else if (familyName1TextBox.Text.Length == 0)
            {
                MessageBox.Show("enter your family name.");
                familyName1TextBox.Focus();
            }
            else if (mailAddress1TextBox.Text.Length == 0)
            {
                MessageBox.Show("enter your email address.");
                mailAddress1TextBox.Focus();
            }
            else if (phoneNumber1TextBox.Text.Length == 0)
            {
                MessageBox.Show("enter your phone number.");
                phoneNumber1TextBox.Focus();
            }
            else if (bankAccountNumber1TextBox.Text.Length == 0)
            {
                MessageBox.Show("enter your bank account number.");
                bankAccountNumber1TextBox.Focus();
            }
            else if(!(int.TryParse(bankAccountNumber1TextBox.Text, out int1)))
            {
                MessageBox.Show("bank account number has to ba a number.");
                bankAccountNumber1TextBox.Clear();
                bankAccountNumber1TextBox.Focus();
            }
            else if (!(int.TryParse(phoneNumber1TextBox.Text, out int1)))
            {
                MessageBox.Show("phone number has to ba a number.");
                phoneNumber1TextBox.Clear();
                phoneNumber1TextBox.Focus();
            }
            else
            {
                if (passwordBox1.Password != passwordBoxConfirm.Password)
                {
                    MessageBox.Show("password do not match.");
                    passwordBoxConfirm.Clear();
                    passwordBoxConfirm.Focus();
                }
                else {
                    if(checkInputGuest()||checkInputHost())
                    {
                        MessageBox.Show("user already exists, try again");
                    }
                   else {
                        saveHost();
                        MessageBox.Show("added to the system");
                        SignInPage login = new SignInPage();
                        login.Show();
                        Close();
                    } 
                }

            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            SignInPage login = new SignInPage();
            login.Show();
            Close();
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
        public void Reset()
        {
            privateName1TextBox.Text = "";
            textBoxUserName.Text = "";
            familyName1TextBox.Text = "";
            mailAddress1TextBox.Text = "";
            phoneNumber1TextBox.Text = "";
            bankAccountNumber1TextBox.Text = "";
            passwordBox1.Password = "";
            passwordBoxConfirm.Password = "";
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private bool checkInputGuest()
        {
            var v = from use in guestRoot.Elements()
                    where use.Element("username").Value == textBoxUserName.Text
                    select use;
            if (v.Count() == 1)
                return true;
            else return false;
        }
        private bool checkInputHost()
        {
            var v = from use in hostRoot.Elements()
                    where use.Element("username").Value == textBoxUserName.Text
                    select use;
            if (v.Count() == 1)
                return true;
            else return false;
        }
        private void LoadData()
        {
            try
            {
                guestRoot = XElement.Load("@GuestXml.xml");
                hostRoot = XElement.Load("@HostXml.xml");
            }
            catch
            {

                throw new Exception("File upload problem");
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostViewSource.Source = [generic data source]
        }
    }
}
