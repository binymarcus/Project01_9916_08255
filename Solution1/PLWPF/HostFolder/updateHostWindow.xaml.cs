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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for updateHostWindow.xaml
    /// </summary>
    public partial class updateHostWindow : Window
    {
        private BE.HostingUnit unit;
        IBL bl = FactoryBL.getIBL();
        string username;
        public updateHostWindow()
        {
            InitializeComponent();
            if (hebEnglish.hebrew)
                hebChange();
        }
        private void hebChange()
        {
            Title = "עדכןמארח";
            hun.Content = "שם יחידת האירוח";
            area.Content = "איזור יחידת האירוח";
            commission.Content = "גבייה";
            childA.Content = "יש אטרקציות לילדים";
            garden.Content = "גינה";
            pool.Content = "בריכה";
            jac.Content = "גקוזי";
            back.Content = "חזור";
            update.Content = "עדכן";
        }
        public updateHostWindow(BE.HostingUnit uni,string user)
        {
            InitializeComponent();
            unit = uni;
            this.grid1.DataContext = uni;
            username = user;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
            //System.Windows.Data.CollectionViewSource hostingUnitViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("hostingUnitViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // hostingUnitViewSource.Source = [generic data source]
        }

        private void hostingUnitDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int error = 0;
            try
            {
                if (hostingUnitName1TextBox.Text == "" && error == 0)//need to fill out name (we dont care if his name is a number)
                {
                    MessageBox.Show("need to fill out  name");
                    error++;
                }
                else if (commission1TextBox.Text == "" && error == 0)
                {
                    MessageBox.Show("need to fill out comission");
                    error++;
                }



                if (error == 0)
                {
                    bl.UpdateHostingUnit(unit);
                    MessageBox.Show("Guest Request updated, Key: " + unit.HostingUnitKey1);
                    Window hWindow = new HostWindow(username);
                    hWindow.Show();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window hostwindow = new HostWindow(username);
            hostwindow.Show();
            this.Close();
        }
    }
}
