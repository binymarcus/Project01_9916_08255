﻿using System;
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
using System.IO;

namespace PLWPF
{
    /// <summary>  
    /// Interaction logic for Registration.xaml  
    /// </summary>  
    public partial class Registration : Window
    {
        XElement guestRoot=new XElement("guestsInfo");
        string guestPath = "@GuestXml.xml";
        XElement HostRoot = new XElement("hostsInfo");

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
            if (hebEnglish.hebrew)
                hebChange();
            if (!File.Exists("@GuestXml.xml"))
                CreateFilesGuest();
            if (!File.Exists("@HostXml.xml"))
                CreateFilesHost();
            else
                LoadData();
        }
        private void hebChange()
        {
            textBlockFirstname.Text = " שם משתמש";
            textBlockPassword.Text = "סיסמה";
            textBlockConfirmPwd.Text = "אישור סיסמה";
            Host.Content = "הירשם כמארח";
            Submit.Content = "הירשם";
            button2.Content = "נקה";
            login.Content = "כניסה";
            Title = "הרשמה למערכת כמתארח";
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
                    if (checkInputGuest() || checkInputHost())
                    {
                        MessageBox.Show("user name already exists, please try again");
                        Reset();
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
        private bool checkInputGuest()
        {
            var v = from use in guestRoot.Elements()
                    where use.Element("username").Value == textBoxFirstName.Text
                    select use;
            if (v.Count() == 1)
                return true;
            else return false;
        }
        private bool checkInputHost()
        {
            var v = from use in HostRoot.Elements()
                    where use.Element("username").Value == textBoxFirstName.Text
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
                HostRoot = XElement.Load("@HostXml.xml");
            }
            catch
            {

                throw new Exception("File upload problem");
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