﻿using BL;
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
        BE.Host host;
       XElement HostRoot = new XElement("hostsInfo");
        IBL bl = FactoryBL.getIBL();
        public HostWindow()
        {
            InitializeComponent();
            LoadData();
            host = new BE.Host();
            try
            {
                host = getOldestHostKey();

            }
            catch 
            {

                
            }
        }
        public HostWindow(string username)
        {
            InitializeComponent();
            LoadData();
            user = username;
            host = new BE.Host();
            host = getHost();

        }
        private BE.Host getOldestHostKey()
        {
            BE.HostingUnit temp=new BE.HostingUnit();
            temp.Owner1 = new BE.Host();
            foreach (var item in bl.GetAllHostingUnits())
            {
                if (item.HostingUnitKey1 > temp.HostingUnitKey1)
                    temp = item;
            }
          foreach( var item  in bl.GetAllHosts())
            {
                if (item.HostKey1 == temp.Owner1.HostKey1)
                    return item;
            }
            return null;
        }
        private void addUnitButton_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
            Window addUnitWindow = new AddUnit(host);
            addUnitWindow.Show();
            this.Close();

        }
        private void updateUnitButton_Click(object sender, RoutedEventArgs e)
        {
            Window updateUnitWindow = new updeletebyunit();
            updateUnitWindow.Show();
            this.Close();

        }
        
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Window mWindow = new SignInPage();
            mWindow.Show();
            this.Close();

        }
        private BE.Host getHost()
        {
            BE.Host host= new BE.Host();

            host = (from use in HostRoot.Elements()
                    where use.Element("username").Value == user
                    select new BE.Host()
                    {
                        PrivateName1 = use.Element("firstName").Value,
                        FamilyName1 = use.Element("lastName").Value,
                        MailAddress1 = use.Element("Email").Value,
                        PhoneNumber1 = int.Parse(use.Element("PhoneNumber").Value),
                        BankAccountNumber1 = int.Parse(use.Element("BankAccountNumber").Value),
                        CollectionClearance1 = bool.Parse(use.Element("Clearance").Value)
                    }).Single();
                       host.HostKey1 = getHostKey(host);
            if(host.HostKey1==0)
                 bl.AddHost(host);

            
            return host;

        }
        private long getHostKey(BE.Host host)
        {

            foreach (var item in bl.GetAllHosts())
            {
                if (host.FamilyName1 == item.FamilyName1 && host.PrivateName1 == item.PrivateName1 && host.MailAddress1 == item.MailAddress1)
                    return item.HostKey1;
            }
            return 0;
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

        private void DeleteUnitButton_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void OrderUnitButton_Click(object sender, RoutedEventArgs e)
        {
            this.OrderUnitButton.Visibility= Visibility.Hidden;
            this.AddORder.Visibility = Visibility.Visible;
            this.UpdateOrder.Visibility = Visibility.Visible;
        }
    }
}