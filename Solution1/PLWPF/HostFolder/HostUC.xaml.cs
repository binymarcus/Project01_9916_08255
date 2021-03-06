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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLWPF.HostFolder
{
    /// <summary>
    /// Interaction logic for HostUC.xaml
    /// </summary>
    public partial class HostUC : UserControl
    {
        public HostUC( BE.Host huc)
        {
            InitializeComponent();
            if (hebEnglish.hebrew)
                hebChange();
            this.hostGrid.DataContext = huc;
        }
        private void hebChange()
        {
            pname.Content = "שם פרטי";
            fname.Content = "שם משפחה";
            hkey.Content = "מספר מארח";
            bank.Content = "מספר חשבון בנק";
            mail.Content = "מייל";
            phone.Content = "מספר פלאפון";
            num.Content = "מספר יחידות אירוח";
            collection.Content = "אישור גבייה";
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // Do not load your data at design time.
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//Load your data here and assign the result to the CollectionViewSource.
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }
    }
}
