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
using BL;
using BE;
using System.Net.Mail;


namespace PLWPF
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        IBL bl = FactoryBL.getIBL();
        List<BE.HostingUnit> grList = new List<BE.HostingUnit>();
        int commission = 10;
        public AdminMainWindow()
        {
            InitializeComponent();
        }

        private void GRfunctions_Click(object sender, RoutedEventArgs e)
        {
            Window adminGRfunctions = new AdminGRfunctions();
            adminGRfunctions.Show();
            this.Close();
        }

        private void HostFunctions_Click(object sender, RoutedEventArgs e)
        {
            Window hostFunctionWindow = new AdminHostFunctions();
            hostFunctionWindow.Show();
            this.Close();
        }

        private void HUFunctions_Click(object sender, RoutedEventArgs e)
        {
            Window hostinUnitsFunctionWindow = new AdminHUfunctions();
            hostinUnitsFunctionWindow.Show();
            this.Close();
        }

        private void OrderFunctions_Click(object sender, RoutedEventArgs e)
        {
            Window orderFunctionWindow = new AdminOrderFunctions();
            orderFunctionWindow.Show();
            this.Close();
        }

        private void SignOut_Click(object sender, RoutedEventArgs e)
        {
            SignInPage signInPage = new SignInPage();
            signInPage.Show();
            this.Close();
        }

        private void calcmoney_Click(object sender, RoutedEventArgs e)
        {
            int amount = bl.getallbusydays();
            MessageBox.Show("amount of busy days: "+amount+" * "+"commision "+commission+
                "\n"+"amount of money:" + amount * commission);
            commish.Visibility = Visibility.Hidden;
            calcmoney.Visibility = Visibility.Hidden;
            money.Visibility = Visibility.Visible;
        }

        private void commish_Click(object sender, RoutedEventArgs e)
        {
            newCommish.Visibility = Visibility.Visible;
            okbutton.Visibility = Visibility.Visible;
        }

        private void money_Click(object sender, RoutedEventArgs e)
        {
            commish.Visibility = Visibility.Visible;
            calcmoney.Visibility = Visibility.Visible;
            money.Visibility = Visibility.Hidden;
        }

        private void okbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                commission = Convert.ToInt32(newCommish.Text);
                MessageBox.Show("commission changed sucsesfully!");
                commish.Visibility = Visibility.Hidden;
                calcmoney.Visibility = Visibility.Hidden;
                money.Visibility = Visibility.Visible;

                newCommish.Visibility = Visibility.Hidden;
                okbutton.Visibility = Visibility.Hidden;

                //sending mail - (how do we send to all the hosts?)

                //MailMessage mail = new MailMessage();
                //mail.To.Add("moshesspam@gmail.com");//we want it to be to all of the hosts
                //mail.From = new MailAddress("miniproject@gmail.com");
                //mail.Subject = "order added";
                //mail.Body = "<p>attention! the commission has changed!</p>";
                //mail.IsBodyHtml = true;
                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com";
                //smtp.Credentials = new System.Net.NetworkCredential("moshesspam@gmail.com", "ihatespam");
                //smtp.EnableSsl = true;
                //try
                //{
                //    smtp.Send(mail);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.ToString());
                //}
            }
            catch
            {
                MessageBox.Show("commission must be a number!");
                newCommish.Clear();
                newCommish.Focus();
            }
           
        }
    }
}
