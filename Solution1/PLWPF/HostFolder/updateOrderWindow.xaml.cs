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
using BE;
using BL;

namespace PLWPF.HostFolder
{
    /// <summary>
    /// Interaction logic for updateOrderWindow.xaml
    /// </summary>
    public partial class updateOrderWindow : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<BE.Order> orderList = new List<BE.Order>();

        public updateOrderWindow()
        {
            InitializeComponent();
        }
        public updateOrderWindow(long hostkey)
        {         
                InitializeComponent();
                scrollview1 = new ScrollViewer();

                try
                {
                    orderList = bl.GetAllOrdersByHostKey(hostkey);

                    foreach (BE.Order item in orderList)
                    {
                        OrderUC gruc = new OrderUC(item);
                        b.Children.Add(gruc);
                    }

                    scrollview1.Content = b;
                }
                catch (Exception)
                {
                 MessageBox.Show("no orders found");
                 this.Close();
                }
        }

            private void BackButton_Click(object sender, RoutedEventArgs e)
            {
                Window GRMain = new AdminOrderFunctions();
                GRMain.Show();
                this.Close();
            }
    }
}
