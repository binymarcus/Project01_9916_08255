using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace PLWPF
{
    /// <summary>  
    /// Interaction logic for Registration.xaml  
    /// </summary>  
    public partial class Registration : Window
    {
        XElement guestRoot=new XElement("guestsInfo");
        string guestPath = "@GuestXml.xml";
        public void SaveGuest()
        {
            XElement username = new XElement("username", textBoxFirstName.Text);
            XElement password = new XElement("password", passwordBox1.Password);
            XElement signIn = new XElement("SIgnInInfo", username, password);
            guestRoot.Add(signIn);
            guestRoot.Save(guestPath);
        }

        public Registration()
        {
            InitializeComponent();
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
            textBoxFirstName.Text = "";
            passwordBox1.Password = "";
            passwordBoxConfirm.Password = "";
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (textBlockFirstname.Text.Length == 0)
            {
                errormessage.Text = "Enter a username.";
                textBlockFirstname.Focus();
            }
            else if(passwordBox1.Password.Length==0)
            {
                errormessage.Text = "enter a password";
                passwordBox1.Focus();
            }
            else
            {
                if(passwordBox1.Password!=passwordBoxConfirm.Password)
                {
                    errormessage.Text = " password do not match";
                    passwordBoxConfirm.Focus();
                }
                else
                {
                    SaveGuest();
                    MessageBox.Show("added to the system");
                    SignInPage login = new SignInPage();
                    login.Show();
                    Close();
                }
                    
            }
        }

        private void Host_Click(object sender, RoutedEventArgs e)
        {
            HostRegistraion host = new HostRegistraion();
            host.Show();
            this.Close();

        }

    }
}