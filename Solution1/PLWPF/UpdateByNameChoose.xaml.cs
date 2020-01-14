﻿using System;
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
            guestList = bl.GetallGuestRequestByName( pname, fname);

            scrollview1 = new ScrollViewer();

            foreach (BE.GuestRequest item in guestList)
            {
                TextBox text = new TextBox(); 
                GRUserControl gruc = new GRUserControl(item);
                b.Children.Add(gruc);
                b.Children.Add(text);

            }

            scrollview1.Content = b;
        }
      
        private void updatebyNameupdateButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (BE.GuestRequest item in guestList)
            {
                bl.UpdateGuestRequest(item);
            }
                this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
    
