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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Mail;
using BE;
using BL;
using System.Threading;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for GRuserControlForAddOrder.xaml
    /// </summary>
    public partial class GRuserControlForAddOrder : UserControl
    {
        BE.Order order;
        long key2;
        long hostkey1;
        BE.HostingUnit hu;
        BE.GuestRequest gr;
        IBL bl = FactoryBL.getIBL();
        public GRuserControlForAddOrder(BE.GuestRequest guesty, long key1,long hostkey)
        {
            InitializeComponent();
            key2 = key1;
            hostkey1 = hostkey;
            gr = guesty;
            hu = bl.GetHostingUnitByKey(key2);
            grid1.DataContext = guesty;
            order = new BE.Order();
        }
        private void GSpick_Click(object sender, RoutedEventArgs e)
        {
            //we need to make the occupied dates set as occupied in the diary of the hosting unit
            int error = 0;
            for (DateTime date = gr.EntryDate1; date <= gr.ReleaseDate1; date = date.AddDays(1))
            {
               if( hu.Diary1[date.Month - 1, date.Day - 1] == true)
                {
                    MessageBox.Show("cannot preform order, the dates are allready occupied");
                    error++;
                }
            }
            if (error == 0)
            {
                for (DateTime date = gr.EntryDate1; date <= gr.ReleaseDate1; date = date.AddDays(1))
                {
                    hu.Diary1[date.Month - 1, date.Day - 1] = true;
                }
                bl.UpdateHostingUnit(hu);
                order.HostingUnitKey1 = key2;
                order.hostKey1 = hostkey1;
                order.GuestRequestKey1 = Convert.ToInt64(guestRequestKey1Label.Content);
                bl.AddOrder(order);
                MessageBox.Show("order added, order key:" + order.OrderKey1);
                //sending mail
                Thread mailThread= new Thread(()=>SendMail());
                mailThread.Start();
                bl.UpdateGuestRequest(gr);

            }
        }

        private void SendMail()
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(gr.MailAddress1);//the guest email
            mail.From = new MailAddress(hu.Owner1.MailAddress1);//the HU owners email
            mail.Subject = "order added";
            mail.Body = "your guest request has been added to an order, hosting unit name:" + hu.HostingUnitName1 + "\n" +
                "hosting unit info:" + "\n" +
                "hostin unit owner's name:" + hu.Owner1.PrivateName1 + " " + hu.Owner1.FamilyName1 + "\n" +
                "location:" + hu.AreaOfHostingUnit.ToString() + "\n" +
                "has pool:" + hu.hasPool1.ToString() + "\n" +
                "has Garden:" + hu.hasGarden1.ToString() + "\n" +
                "has Jaccuzzi:" + hu.hasJaccuzzi1.ToString() + "\n" +
                "has Childrens Attractions:" + hu.hasChildrensAttractions1.ToString() + "\n" +
                "commission:" + hu.Commission1 + "\n" +
                "have a good day!";
            mail.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("moshesspam@gmail.com", "ihatespam");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
                //changing the gr status to mail sent
                gr.status1 = BEEnum.Status.mailSent;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded_1(object sender, RoutedEventArgs e)
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
