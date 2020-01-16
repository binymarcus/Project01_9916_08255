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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.IO;

namespace PLWPF   {
    /// <summary>  
    /// Interaction logic for MainWindow.xaml  
    /// </summary>   
    public partial class SignInPage : Window
    {
        XElement guestRoot;
        XElement HostRoot;
        public SignInPage()
        {
            InitializeComponent();
            if (!File.Exists("@GuestXml.xml"))
                CreateFilesGuest();
            if (!File.Exists("@HostXml.xml"))
                CreateFilesHost();
            else
                LoadData();
        }
        private void CreateFilesGuest()
        {
            guestRoot = new XElement("guestsInfo");
            guestRoot.Save("@GuestXml.xml");
        }
        private void CreateFilesHost()
        {
            HostRoot = new XElement("hostsInfo");
            HostRoot.Save("@HostXml.xml");
        }
        Registration registration = new Registration();
        Welcome welcome = new Welcome();
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text.Length == 0)
            {
                MessageBox.Show("Enter a username");
            }
            else
            {
                if (txtPassword.Password.Length == 0)
                {
                    MessageBox.Show("Enter a password.");
                }
                if (txtUsername.Text == "Admin" && txtPassword.Password == "admin")
                {
                    AdminMainWindow admin = new AdminMainWindow();
                    admin.Show();
                    this.Close();
                }
                else
                {
                    if (!checkInputGuest() && !checkInputHost())
                        MessageBox.Show("username or password incorrect, fix or register");
                    else
                    {
                        if (checkInputHost())
                        {
                            HostWindow ho = new HostWindow(txtUsername.Text);
                            ho.Show();
                            this.Close();
                        }

                        if (checkInputGuest())
                        {
                            GuestRequest gu = new GuestRequest();
                            gu.Show();
                            this.Close();
                        }
                    }
                }
            }
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            registration.Show();
            Close();
        }
        private void LoadData()
        {
            try
            {
                guestRoot=XElement.Load("@GuestXml.xml");
                HostRoot = XElement.Load("@HostXml.xml");
            }
            catch 
            {

                throw new Exception("File upload problem");
            }
        }
        private bool checkInputGuest()
        {
               var v=  from use in guestRoot.Elements()
                where (use.Element("username").Value == txtUsername.Text)&&(use.Element("password").Value == txtPassword.Password)
                select use;
                if (v.Count() == 1)
                    return true;
                else return false;         
        }
        private bool checkInputHost()
        {

            var v = from use in HostRoot.Elements()
                    where (use.Element("username").Value == txtUsername.Text)&&(use.Element("password").Value == txtPassword.Password)
                    select use;
            if (v.Count() == 1)
                return true;
            else return false;
        }
    }
}